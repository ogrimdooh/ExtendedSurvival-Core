using Sandbox.Game.Entities;
using Sandbox.ModAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using VRage.Game;
using VRage.Game.ModAPI;
using VRage.Utils;
using VRageMath;

namespace ExtendedSurvival.Core
{

    public static class IMyCharacterExtensions
    {

        public static readonly string[] VALID_PLAYERS_SUBTYPES = new string[] { "Default_Astronaut", "Default_Astronaut_Female" };
         
        public static bool IsValidPlayer(this IMyCharacter character)
        {
            var player = character.GetPlayer();
            return player != null && !player.IsBot;
        }

        public static bool IsValidBot(this IMyCharacter character)
        {
            var player = character.GetPlayer();
            return player != null && player.IsBot;
        }

        public static IMyPlayer GetPlayer(this IMyCharacter character)
        {
            var playerId = character.GetPlayerId();
            var players = new List<IMyPlayer>();
            MyAPIGateway.Multiplayer.Players.GetPlayers(players, (player) => { return player.IdentityId == playerId; });
            if (players.Any())
                return players[0];
            return null;
        }

        public static bool TryGetObjectBuilder(this IMyCharacter character, out MyObjectBuilder_Character builder)
        {
            builder = null;
            if (character != null)
            {
                try
                {
                    builder = (character.GetObjectBuilder() as MyObjectBuilder_Character);
                    return true;
                }
                catch (Exception)
                {
                    builder = null;
                }
            }
            return false;
        }

        public static long GetPlayerId(this IMyCharacter character)
        {
            if (character != null)
            {
                MyObjectBuilder_Character builder;
                if (character.TryGetObjectBuilder(out builder))
                {
                    var playerId = builder?.OwningPlayerIdentityId;
                    return playerId.HasValue ? playerId.Value : -1;
                }
            }
            return -1;
        }

        public static Vector3D? GetRandomPosition(this IMyCharacter character)
        {
            if (character == null)
                return null;

            float num;
            var charPosition = character.WorldAABB.Center;
            Vector3D gravity = MyAPIGateway.Physics.CalculateNaturalGravityAt(charPosition, out num);

            MatrixD matrix;
            if (gravity.LengthSquared() > 0)
            {
                gravity.Normalize();
                matrix = MatrixD.CreateWorld(charPosition, Vector3D.CalculatePerpendicularVector(gravity), -gravity);
            }
            else
                matrix = character.WorldMatrix;

            var random = MyUtils.GetRandomInt(1, 9);

            Vector3D direction;
            switch (random)
            {
                case 1:
                    direction = matrix.Forward;
                    break;
                case 2:
                    direction = matrix.Forward + matrix.Right;
                    break;
                case 3:
                    direction = matrix.Right;
                    break;
                case 4:
                    direction = matrix.Right + matrix.Backward;
                    break;
                case 5:
                    direction = matrix.Backward;
                    break;
                case 6:
                    direction = matrix.Backward + matrix.Left;
                    break;
                case 7:
                    direction = matrix.Left;
                    break;
                case 8:
                    direction = matrix.Left + matrix.Forward;
                    break;
                default:
                    return null;
            }

            var position = charPosition + direction * 200;
            var planet = MyGamePruningStructure.GetClosestPlanet(position);
            if (planet == null)
                return position;

            var surfacePoint = planet.GetClosestSurfacePointGlobal(ref position);
            return surfacePoint - (gravity * 5);
        }

    }

}
