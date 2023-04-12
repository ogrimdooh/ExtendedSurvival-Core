using Sandbox.Definitions;
using System.Collections.Generic;
using System.Linq;
using VRage.Game.ObjectBuilders.Definitions;
using VRage.ObjectBuilders;

namespace ExtendedSurvival.Core
{

    public static class FactionTypeConstants
    {

        public class FactionTypeDefinition
        {

            public enum FactionOverrideMethod
            {

                Ignore = 0,
                Increment = 1,
                Replace = 2

            }

            public UniqueEntityId Id { get; set; }
            public List<UniqueEntityId> OffersList { get; set; } = new List<UniqueEntityId>();
            public List<UniqueEntityId> OrdersList { get; set; } = new List<UniqueEntityId>();
            public List<string> GridsForSale { get; set; } = new List<string>();
            public FactionOverrideMethod OverrideMethod { get; set; } = FactionOverrideMethod.Ignore;

            public SerializableDefinitionId[] GetOffersList(SerializableDefinitionId[] source)
            {
                switch (OverrideMethod)
                {
                    case FactionOverrideMethod.Increment:
                        return source.Concat(OffersList.Select(x => x.SerializableDefinitionId)).Distinct().ToArray();
                    case FactionOverrideMethod.Replace:
                        return OffersList.Select(x => x.SerializableDefinitionId).Distinct().ToArray();
                }
                return source;
            }

            public SerializableDefinitionId[] GetOrdersList(SerializableDefinitionId[] source)
            {
                switch (OverrideMethod)
                {
                    case FactionOverrideMethod.Increment:
                        return source.Concat(OrdersList.Select(x => x.SerializableDefinitionId)).Distinct().ToArray();
                    case FactionOverrideMethod.Replace:
                        return OrdersList.Select(x => x.SerializableDefinitionId).Distinct().ToArray();
                }
                return source;
            }

            public string[] GetGridsForSale(string[] source)
            {
                switch (OverrideMethod)
                {
                    case FactionOverrideMethod.Increment:
                        return source != null ? source.Concat(GridsForSale).Distinct().ToArray() : GridsForSale.Distinct().ToArray();
                    case FactionOverrideMethod.Replace:
                        return GridsForSale.Distinct().ToArray();
                }
                return source;
            }

        }

        public const string MINER_SUBTYPEID = "Miner";
        public static readonly UniqueEntityId MINER_ID = new UniqueEntityId(typeof(MyObjectBuilder_FactionTypeDefinition), MINER_SUBTYPEID);

        public const string TRADER_SUBTYPEID = "Trader";
        public static readonly UniqueEntityId TRADER_ID = new UniqueEntityId(typeof(MyObjectBuilder_FactionTypeDefinition), TRADER_SUBTYPEID);

        public const string BUILDER_SUBTYPEID = "Builder";
        public static readonly UniqueEntityId BUILDER_ID = new UniqueEntityId(typeof(MyObjectBuilder_FactionTypeDefinition), BUILDER_SUBTYPEID);


        public static readonly FactionTypeDefinition MINER_DEFINITION = new FactionTypeDefinition()
        {
            Id = MINER_ID
        };

        public static readonly FactionTypeDefinition TRADER_DEFINITION = new FactionTypeDefinition()
        {
            Id = TRADER_ID,
            OverrideMethod = FactionTypeDefinition.FactionOverrideMethod.Increment
        };

        public static readonly FactionTypeDefinition BUILDER_DEFINITION = new FactionTypeDefinition()
        {
            Id = BUILDER_ID
        };

        public static readonly Dictionary<UniqueEntityId, FactionTypeDefinition> FACTION_TYPES_DEFINITIONS = new Dictionary<UniqueEntityId, FactionTypeDefinition>()
        {
            { MINER_ID, MINER_DEFINITION },
            { TRADER_ID, TRADER_DEFINITION },
            { BUILDER_ID, BUILDER_DEFINITION }
        };

        public static void TryOverrideDefinitions()
        {
            try
            {
                foreach (var factionId in FACTION_TYPES_DEFINITIONS.Keys)
                {
                    var factionDef = FACTION_TYPES_DEFINITIONS[factionId];
                    if (factionDef.OverrideMethod == FactionTypeDefinition.FactionOverrideMethod.Ignore)
                        continue;
                    var definition = DefinitionUtils.TryGetDefinition<MyFactionTypeDefinition>(factionId.DefinitionId);
                    if (definition != null)
                    {
                        definition.OffersList = factionDef.GetOffersList(definition.OffersList);
                        definition.OrdersList = factionDef.GetOrdersList(definition.OrdersList);
                        definition.GridsForSale = factionDef.GetGridsForSale(definition.GridsForSale);
                        definition.Postprocess();
                    }
                    else
                        ExtendedSurvivalCoreLogging.Instance.LogInfo(typeof(FactionTypeConstants), $"FactionTypeConstants definition not found. Recipe=[{factionId.subtypeId}]");
                }
            }
            catch (System.Exception ex)
            {
                ExtendedSurvivalCoreLogging.Instance.LogError(typeof(FactionTypeConstants), ex);
            }
        }

    }

}