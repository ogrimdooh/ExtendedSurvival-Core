using Sandbox.Definitions;
using System.Collections.Generic;
using VRage.Game;
using VRageMath;

namespace ExtendedSurvival.Core
{
    public static class IngotsConstants
    {

        public static readonly UniqueEntityId SOIL_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), OreConstants.SOIL_SUBTYPEID);

        public const string SAND_SUBTYPEID = "Sand";
        public static readonly UniqueEntityId SAND_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), SAND_SUBTYPEID);

        public const string CARBON_SUBTYPEID = "Carbon";
        public static readonly UniqueEntityId CARBON_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), CARBON_SUBTYPEID);

        public const string SILVERPOWDER_SUBTYPEID = "SilverPowder";
        public static readonly UniqueEntityId SILVERPOWDER_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), SILVERPOWDER_SUBTYPEID);

        public const string GRAVEL_SUBTYPEID = "Stone";
        public static readonly UniqueEntityId GRAVEL_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), GRAVEL_SUBTYPEID);

        public static readonly IngotDefinition SOIL_DEFINITION = new IngotDefinition()
        {
            Id = SOIL_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.SOIL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.SOIL_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 25,
            OfferAmount = new Vector2I(10000, 30000),
            OrderAmount = new Vector2I(2500, 7500),
            AcquisitionAmount = new Vector2I(5000, 15000),
            Mass = 1f,
            Volume = 0.2f
        };

        public static readonly IngotDefinition SAND_DEFINITION = new IngotDefinition()
        {
            Id = SAND_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.SAND_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.SAND_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 50,
            OfferAmount = new Vector2I(10000, 30000),
            OrderAmount = new Vector2I(2500, 7500),
            AcquisitionAmount = new Vector2I(5000, 15000),
            Mass = 1f,
            Volume = 0.2f
        };

        public static readonly IngotDefinition CARBON_DEFINITION = new IngotDefinition()
        {
            Id = CARBON_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.CARBON_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.CARBON_DESCRIPTION),
            CanPlayerOrder = true,
            OfferAmount = new Vector2I(1000, 3000),
            OrderAmount = new Vector2I(250, 750),
            AcquisitionAmount = new Vector2I(500, 1500),
            Mass = 1f,
            Volume = 0.05f
        };

        public static readonly IngotDefinition SILVERPOWDER_DEFINITION = new IngotDefinition()
        {
            Id = SILVERPOWDER_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.SILVERPOWDER_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.SILVERPOWDER_DESCRIPTION),
            CanPlayerOrder = true,
            OfferAmount = new Vector2I(100, 300),
            OrderAmount = new Vector2I(25, 75),
            AcquisitionAmount = new Vector2I(50, 150),
            Mass = 1f,
            Volume = 0.025f
        };

        public static readonly Dictionary<UniqueEntityId, IngotDefinition> INGOTS_DEFINITIONS = new Dictionary<UniqueEntityId, IngotDefinition>()
        {
            { SOIL_ID, SOIL_DEFINITION },
            { SAND_ID, SAND_DEFINITION },
            { CARBON_ID, CARBON_DEFINITION },
            { SILVERPOWDER_ID, SILVERPOWDER_DEFINITION }
        };

        public static void TryOverrideDefinitions()
        {
            PhysicalItemDefinitionOverride.TryOverrideDefinitions<IngotDefinition, MyPhysicalItemDefinition>(INGOTS_DEFINITIONS, FactionTypeConstants.MINER_ID);
        }

    }

}