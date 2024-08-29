using System.Collections.Generic;
using System.Linq;
using VRage.Utils;
using Sandbox.Game.Entities;
using System.Collections.Concurrent;
using VRage.Game;
using Sandbox.Definitions;
using VRageMath;
using VRage.Game.ModAPI;
using Sandbox.Game.Entities.Blocks;
using System.ComponentModel;
using VRage.Game.ModAPI.Ingame;
using Sandbox.ModAPI;
using System.Text;

namespace ExtendedSurvival.Core
{
    public static class StarShipKeyConstants
    {

        public const int TOTAL_KEYS = 100;
        public const string STARSHIPKEYBASE_SUBTYPEID = "StarshipKey_{0}";

        public class StarShipKeyInfo
        {

            public UniqueEntityId ItemId { get; set; }
            public MyCubeGrid CubeGrid { get; set; }
            public long EntityId { get; set; }
            public long Price { get; set; }

        }

        public static readonly ConcurrentDictionary<UniqueEntityId, MyPhysicalItemDefinition> STARSHIPKEYS = new ConcurrentDictionary<UniqueEntityId, MyPhysicalItemDefinition>();

        public static readonly ConcurrentDictionary<UniqueEntityId, StarShipKeyInfo> USEDKEYS = new ConcurrentDictionary<UniqueEntityId, StarShipKeyInfo>();

        public static bool Loaded { get; private set; }

        public static void LoadBaseKeys()
        {
            if (Loaded) return;
            Loaded = true;
            for (int i = 0; i < TOTAL_KEYS; i++)
            {
                var newId = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), string.Format(STARSHIPKEYBASE_SUBTYPEID, i.ToString("0000")));
                var def = MyDefinitionManager.Static.GetPhysicalItemDefinition(newId.DefinitionId);
                if (def.Id == newId.DefinitionId)
                {
                    STARSHIPKEYS[newId] = def;
                }
            }
        }

        public static void ClearPlayerInventory(IMyPlayer player)
        {
            if (!Loaded)
                LoadBaseKeys();
            var inventory = player.Character?.GetInventory();
            if (inventory != null)
            {
                List<MyInventoryItem> itens = new List<MyInventoryItem>();
                inventory.GetItems(itens, x => StarShipKeyConstants.IsStarShipKey(new UniqueEntityId(x.Type)));
                foreach (var item in itens)
                {
                    inventory.RemoveItems(item.ItemId);
                }
            }
        }

        public static StarShipKeyInfo GetStarShipKey(UniqueEntityId id)
        {
            if (USEDKEYS.ContainsKey(id))
                return USEDKEYS[id];
            return null;
        }

        public static StarShipKeyInfo GetStarShipKey(long entityId)
        {
            if (USEDKEYS.Values.Any(x => x.EntityId == entityId))
                return USEDKEYS.Values.FirstOrDefault(x => x.EntityId == entityId);
            return null;
        }

        public static bool IsStarShipKey(UniqueEntityId id)
        {
            return STARSHIPKEYS.ContainsKey(id);
        }

        public static bool IsValidStarShipKey(UniqueEntityId id)
        {
            return USEDKEYS.ContainsKey(id);
        }

        public static UniqueEntityId[] GetActiveKeys()
        {
            return STARSHIPKEYS.Keys.ToArray();
        }

        public static void FreeKeySlot(UniqueEntityId id)
        {
            if (USEDKEYS.ContainsKey(id))
                USEDKEYS.Remove(id);
        }

        public static float GetBaseKeyVolume()
        {
            if (STARSHIPKEYS.Any())
                return STARSHIPKEYS.FirstOrDefault().Value.Volume;
            return 0;
        }

        public static StarShipKeyInfo GetEmptyShipKey(MyCubeGrid cubegrid)
        {
            if (USEDKEYS.Count >= STARSHIPKEYS.Count)
                return null;
            UniqueEntityId target = null;
            var ok = false;
            do
            {
                target = STARSHIPKEYS.Keys.Where(x => !USEDKEYS.ContainsKey(x)).OrderBy(x => MyUtils.GetRandomFloat()).FirstOrDefault();
                ok = !USEDKEYS.ContainsKey(target);
            }
            while (!ok);
            USEDKEYS[target] = new StarShipKeyInfo()
            {
                ItemId = target,
                EntityId = cubegrid.EntityId,
                CubeGrid = cubegrid,
                Price = ExtendedSurvivalEntityManager.Instance.GetGridByUuid(cubegrid.EntityId)?.Price ?? 1000
            };
            USEDKEYS[target].Price = (int)(USEDKEYS[target].Price * new Vector2(0.75f, 0.9f).GetRandom());
            DoUpdateStarShipKeyDesc(target, $"Starship Key [{cubegrid.DisplayName}]");
            ComunicateNewItemDef(target);
            return USEDKEYS[target];
        }

        private static void ComunicateNewItemDef(UniqueEntityId target)
        {
            Command cmd = new Command(0, ExtendedSurvivalCoreSession.STARSHIPKEY_DEF, target.ToString(), STARSHIPKEYS[target].DisplayNameString);
            string messageToSend = MyAPIGateway.Utilities.SerializeToXML<Command>(cmd);
            if (MyAPIGateway.Utilities.IsDedicated)
            {
                var targetIds = new ulong[] { };
                var players = new List<IMyPlayer>();
                MyAPIGateway.Players.GetPlayers(players);
                if (players.Any())
                    targetIds = players.Select(x => x.SteamUserId).ToArray();
                else
                    return;
                foreach (var item in targetIds)
                {
                    MyAPIGateway.Multiplayer.SendMessageTo(
                        ExtendedSurvivalCoreSession.NETWORK_ID_CALLCLIENTSYSTEM,
                        Encoding.Unicode.GetBytes(messageToSend),
                        item
                    );
                }
            }
            else
            {
                MyAPIGateway.Multiplayer.SendMessageToOthers(
                    ExtendedSurvivalCoreSession.NETWORK_ID_CALLCLIENTSYSTEM,
                    Encoding.Unicode.GetBytes(messageToSend)
                );
            }
        }

        private static void ComunicatePlayerOpenStoreGui(long playerId)
        {
            Command cmd = new Command(0, ExtendedSurvivalCoreSession.PLAYEROPENSTOREGUI, playerId.ToString());
            string messageToSend = MyAPIGateway.Utilities.SerializeToXML<Command>(cmd);
            MyAPIGateway.Multiplayer.SendMessageToServer(
                ExtendedSurvivalCoreSession.NETWORK_ID_CALLSERVERSYSTEM,
                Encoding.Unicode.GetBytes(messageToSend)
            );
        }

        private static void ComunicatePlayerCloseStoreGui(long playerId)
        {
            Command cmd = new Command(0, ExtendedSurvivalCoreSession.PLAYERCLOSESTOREGUI, playerId.ToString());
            string messageToSend = MyAPIGateway.Utilities.SerializeToXML<Command>(cmd);
            MyAPIGateway.Multiplayer.SendMessageToServer(
                ExtendedSurvivalCoreSession.NETWORK_ID_CALLSERVERSYSTEM,
                Encoding.Unicode.GetBytes(messageToSend)
            );
        }

        public static void CallForServerKeys()
        {
            Command cmd = new Command(0, ExtendedSurvivalCoreSession.CALLSTARSHIPKEY);
            string messageToSend = MyAPIGateway.Utilities.SerializeToXML<Command>(cmd);
            MyAPIGateway.Multiplayer.SendMessageToServer(
                ExtendedSurvivalCoreSession.NETWORK_ID_CALLSERVERSYSTEM,
                Encoding.Unicode.GetBytes(messageToSend)
            );
        }

        public static void SendKeysToClient(ulong target)
        {
            var content = new List<string>
            {
                ExtendedSurvivalCoreSession.SENDSTARSHIPKEY
            };
            foreach (var key in USEDKEYS.Keys)
            {
                content.Add($"{key}={STARSHIPKEYS[key].DisplayNameString}");
            }
            Command cmd = new Command(0, content.ToArray());
            string messageToSend = MyAPIGateway.Utilities.SerializeToXML<Command>(cmd);
            MyAPIGateway.Multiplayer.SendMessageTo(
                ExtendedSurvivalCoreSession.NETWORK_ID_CALLCLIENTSYSTEM,
                Encoding.Unicode.GetBytes(messageToSend),
                target
            );
        }

        public static void LoadKeysIntoClient(List<string> keys)
        {
            foreach (var key in keys)
            {
                var keyparts = key.Split('=');
                if (keyparts.Length == 2)
                {
                    UniqueEntityId id = null;
                    if (UniqueEntityId.TryParse(keyparts[0], out id))
                    {
                        if (STARSHIPKEYS.ContainsKey(id))
                        {
                            STARSHIPKEYS[id].DisplayNameString = keyparts[1];
                            STARSHIPKEYS[id].Postprocess();
                        }
                    }
                }
            }
        }

        public static void DoUpdateStarShipKeyDesc(UniqueEntityId target, string name)
        {
            if (STARSHIPKEYS.ContainsKey(target))
            {
                STARSHIPKEYS[target].DisplayNameString = name;
                STARSHIPKEYS[target].Postprocess();
            }
        }

        public static void PlayerCloseStoreGui()
        {
            if (MyAPIGateway.Utilities.IsDedicated)
                return;
            if (MyAPIGateway.Session.IsServer)
                DoPlayerCloseStoreGui(MyAPIGateway.Session.Player);
            else
                ComunicatePlayerCloseStoreGui(MyAPIGateway.Session.Player.IdentityId);
        }

        public static void PlayerOpenStoreGui()
        {
            if (MyAPIGateway.Utilities.IsDedicated)
                return;
            if (MyAPIGateway.Session.IsServer)
                DoPlayerOpenStoreGui(MyAPIGateway.Session.Player);
            else
                ComunicatePlayerOpenStoreGui(MyAPIGateway.Session.Player.IdentityId);
        }

        public static void DoPlayerCloseStoreGui(IMyPlayer player)
        {
            if (player?.Character == null)
                return;

            var inventory = player.Character.GetInventory();
            if (inventory == null)
                return;

            foreach (var item in GetActiveKeys())
            {
                if (inventory.GetItemAmount(item.ItemType) > 0)
                {
                    inventory.RemoveItemsOfType(1, ItensConstants.GetPhysicalObjectBuilder(item));
                    break;
                }
            }
        }

        public static void DoPlayerOpenStoreGui(IMyPlayer player)
        {
            if (player?.Character == null)
                return;

            var inventory = player.Character.GetInventory();
            if (inventory == null)
                return;

            var freeVolume = (float)(inventory.MaxVolume - inventory.CurrentVolume);
            var baseVolume = GetBaseKeyVolume() * 5;

            if (freeVolume <= baseVolume)
                return;

            var area = new BoundingSphereD(player.GetPosition(), 2);
            var entities = MyAPIGateway.Entities.GetEntitiesInSphere(ref area);

            if (entities.Any(x => (x as IMyStoreBlock) != null))
            {
                var c = entities.FirstOrDefault(x => (x as IMyStoreBlock) != null) as IMyStoreBlock;
                if (c != null)
                {
                    var tag = c.GetOwnerFactionTag();
                    if (!string.IsNullOrWhiteSpace(tag))
                    {
                        var faction = MyAPIGateway.Session.Factions.TryGetFactionByTag(tag);
                        if (faction != null && faction.IsEveryoneNpc())
                        {
                            var lista = (c.CubeGrid as MyCubeGrid).GetConnectedGrids(GridLinkTypeEnum.Physical);
                            if (lista != null && lista.Any(x => x.BigOwners.Any(y => y == player.IdentityId)))
                            {
                                foreach (var grid in lista.Where(x => x.BigOwners.Any(y => y == player.IdentityId)))
                                {
                                    var keyToCreate = GetStarShipKey(grid.EntityId);
                                    if (keyToCreate != null)
                                    {
                                        inventory.AddItems(1, ItensConstants.GetPhysicalObjectBuilder(keyToCreate.ItemId));
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

    }

}