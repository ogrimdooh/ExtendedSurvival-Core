﻿using Sandbox.Common.ObjectBuilders.Definitions;
using System.Collections.Concurrent;
using VRage.Game;
using VRage.Game.ObjectBuilders.Definitions;
using VRage.ObjectBuilders;

namespace ExtendedSurvival.Core
{

    public static class ItensConstants
    {

        public const string ASSEMBLER_BOTTLES_BLUEPRINTS = "Assembler_Bottles_Blueprints";
        public const string BASICASSEMBLER_BOTTLES_BLUEPRINTS = "BasicAssembler_Bottles_Blueprints";
        public const string SURVIVALKIT_REFINE_BLUEPRINTS = "SurvivalKit_Refine_Blueprints";
        public const string SURVIVALKIT_BOTTLES_BLUEPRINTS = "SurvivalKit_Bottles_Blueprints";
        public const string SURVIVALKIT_ALCHEMY_BLUEPRINTS = "SurvivalKit_Alchemy_Blueprints";

        public const string THERMALGAS_SUBTYPEID = "ThermalGas";
        public static readonly UniqueEntityId THERMALGAS_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasProperties), THERMALGAS_SUBTYPEID);

        public const string WOODLOG_SUBTYPEID = "Wood";
        public static readonly UniqueEntityId WOODLOG_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), WOODLOG_SUBTYPEID);

        public const string SAWDUST_SUBTYPEID = "Sawdust";
        public static readonly UniqueEntityId SAWDUST_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), SAWDUST_SUBTYPEID);

        public const string LEAF_SUBTYPEID = "Leaf";
        public static readonly UniqueEntityId LEAF_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), LEAF_SUBTYPEID);

        public const string TWIG_SUBTYPEID = "Twig";
        public static readonly UniqueEntityId TWIG_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), TWIG_SUBTYPEID);

        public const string BRANCH_SUBTYPEID = "Branch";
        public static readonly UniqueEntityId BRANCH_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), BRANCH_SUBTYPEID);

        public const string CANVAS_SUBTYPEID = "Canvas";
        public static readonly UniqueEntityId CANVAS_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), CANVAS_SUBTYPEID);

        public const string IRON_SUBTYPEID = "Iron";
        public static readonly UniqueEntityId IRON_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), IRON_SUBTYPEID);
        public static readonly UniqueEntityId IRON_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), IRON_SUBTYPEID);

        public const string NICKEL_SUBTYPEID = "Nickel";
        public static readonly UniqueEntityId NICKEL_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), NICKEL_SUBTYPEID);
        public static readonly UniqueEntityId NICKEL_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), NICKEL_SUBTYPEID);

        public const string SILICON_SUBTYPEID = "Silicon";
        public static readonly UniqueEntityId SILICON_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), SILICON_SUBTYPEID);
        public static readonly UniqueEntityId SILICON_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), SILICON_SUBTYPEID);

        public const string COBALT_SUBTYPEID = "Cobalt";
        public static readonly UniqueEntityId COBALT_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), COBALT_SUBTYPEID);
        public static readonly UniqueEntityId COBALT_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), COBALT_SUBTYPEID);

        public const string SILVER_SUBTYPEID = "Silver";
        public static readonly UniqueEntityId SILVER_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), SILVER_SUBTYPEID);
        public static readonly UniqueEntityId SILVER_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), SILVER_SUBTYPEID);

        public const string GOLD_SUBTYPEID = "Gold";
        public static readonly UniqueEntityId GOLD_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), GOLD_SUBTYPEID);
        public static readonly UniqueEntityId GOLD_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), GOLD_SUBTYPEID);

        public const string PLATINUM_SUBTYPEID = "Platinum";
        public static readonly UniqueEntityId PLATINUM_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), PLATINUM_SUBTYPEID);
        public static readonly UniqueEntityId PLATINUM_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), PLATINUM_SUBTYPEID);

        public const string URANIUM_SUBTYPEID = "Uranium";
        public static readonly UniqueEntityId URANIUM_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), URANIUM_SUBTYPEID);
        public static readonly UniqueEntityId URANIUM_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), URANIUM_SUBTYPEID);

        public const string MAGNESIUM_SUBTYPEID = "Magnesium";
        public static readonly UniqueEntityId MAGNESIUM_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), MAGNESIUM_SUBTYPEID);
        public static readonly UniqueEntityId MAGNESIUM_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), MAGNESIUM_SUBTYPEID);

        public const string CARBON_SUBTYPEID = "Carbon";
        public static readonly UniqueEntityId CARBON_POWDER_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), CARBON_SUBTYPEID);

        public const string SOIL_SUBTYPEID = "Soil";
        public static readonly UniqueEntityId SOIL_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), SOIL_SUBTYPEID);

        public const string SILVERPOWDER_SUBTYPEID = "SilverPowder";
        public static readonly UniqueEntityId SILVERPOWDER_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), SILVERPOWDER_SUBTYPEID);

        public const string SAND_SUBTYPEID = "Sand";
        public static readonly UniqueEntityId SAND_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), SAND_SUBTYPEID);

        public const string HYDROGENBOTTLE_SUBTYPEID = "HydrogenBottle";
        public static readonly UniqueEntityId HYDROGENBOTTLE_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), HYDROGENBOTTLE_SUBTYPEID);

        public const string OXYGENBOTTLE_SUBTYPEID = "OxygenBottle";
        public static readonly UniqueEntityId OXYGENBOTTLE_ID = new UniqueEntityId(typeof(MyObjectBuilder_OxygenContainerObject), OXYGENBOTTLE_SUBTYPEID);

        public const string SEMIAUTOPISTOL_SUBTYPEID = "SemiAutoPistolItem";
        public static readonly UniqueEntityId SEMIAUTOPISTOL_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalGunObject), SEMIAUTOPISTOL_SUBTYPEID);

        public const string FULLAUTOPISTOL_SUBTYPEID = "FullAutoPistolItem";
        public static readonly UniqueEntityId FULLAUTOPISTOL_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalGunObject), FULLAUTOPISTOL_SUBTYPEID);

        public const string ELITEAUTOPISTOL_SUBTYPEID = "ElitePistolItem";
        public static readonly UniqueEntityId ELITEAUTOPISTOL_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalGunObject), ELITEAUTOPISTOL_SUBTYPEID);

        public const string AUTOMATICRIFLE_SUBTYPEID = "AutomaticRifleItem";
        public static readonly UniqueEntityId AUTOMATICRIFLE_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalGunObject), AUTOMATICRIFLE_SUBTYPEID);

        public const string PRECISEAUTOMATICRIFLE_SUBTYPEID = "PreciseAutomaticRifleItem";
        public static readonly UniqueEntityId PRECISEAUTOMATICRIFLE_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalGunObject), PRECISEAUTOMATICRIFLE_SUBTYPEID);

        public const string RAPIDFIREAUTOMATICRIFLE_SUBTYPEID = "RapidFireAutomaticRifleItem";
        public static readonly UniqueEntityId RAPIDFIREAUTOMATICRIFLE_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalGunObject), RAPIDFIREAUTOMATICRIFLE_SUBTYPEID);

        public const string ULTIMATEAUTOMATICRIFLE_SUBTYPEID = "UltimateAutomaticRifleItem";
        public static readonly UniqueEntityId ULTIMATEAUTOMATICRIFLE_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalGunObject), ULTIMATEAUTOMATICRIFLE_SUBTYPEID);

        public const string BASICHANDHELDLAUNCHER_SUBTYPEID = "BasicHandHeldLauncherItem";
        public static readonly UniqueEntityId BASICHANDHELDLAUNCHER_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalGunObject), BASICHANDHELDLAUNCHER_SUBTYPEID);

        public const string ADVANCEDHANDHELDLAUNCHER_SUBTYPEID = "AdvancedHandHeldLauncherItem";
        public static readonly UniqueEntityId ADVANCEDHANDHELDLAUNCHER_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalGunObject), ADVANCEDHANDHELDLAUNCHER_SUBTYPEID);

        public const string ANGLEGRINDERITEM_SUBTYPEID = "AngleGrinderItem";
        public static readonly UniqueEntityId ANGLEGRINDERITEM_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalGunObject), ANGLEGRINDERITEM_SUBTYPEID);

        public const string ANGLEGRINDER2ITEM_SUBTYPEID = "AngleGrinder2Item";
        public static readonly UniqueEntityId ANGLEGRINDER2ITEM_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalGunObject), ANGLEGRINDER2ITEM_SUBTYPEID);

        public const string ANGLEGRINDER3ITEM_SUBTYPEID = "AngleGrinder3Item";
        public static readonly UniqueEntityId ANGLEGRINDER3ITEM_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalGunObject), ANGLEGRINDER3ITEM_SUBTYPEID);

        public const string ANGLEGRINDER4ITEM_SUBTYPEID = "AngleGrinder4Item";
        public static readonly UniqueEntityId ANGLEGRINDER4ITEM_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalGunObject), ANGLEGRINDER4ITEM_SUBTYPEID);

        public const string HANDDRILLITEM_SUBTYPEID = "HandDrillItem";
        public static readonly UniqueEntityId HANDDRILLITEM_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalGunObject), HANDDRILLITEM_SUBTYPEID);

        public const string HANDDRILL2ITEM_SUBTYPEID = "HandDrill2Item";
        public static readonly UniqueEntityId HANDDRILL2ITEM_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalGunObject), HANDDRILL2ITEM_SUBTYPEID);

        public const string HANDDRILL3ITEM_SUBTYPEID = "HandDrill3Item";
        public static readonly UniqueEntityId HANDDRILL3ITEM_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalGunObject), HANDDRILL3ITEM_SUBTYPEID);

        public const string HANDDRILL4ITEM_SUBTYPEID = "HandDrill4Item";
        public static readonly UniqueEntityId HANDDRILL4ITEM_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalGunObject), HANDDRILL4ITEM_SUBTYPEID);

        public const string WELDERITEM_SUBTYPEID = "WelderItem";
        public static readonly UniqueEntityId WELDERITEM_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalGunObject), WELDERITEM_SUBTYPEID);

        public const string WELDER2ITEM_SUBTYPEID = "Welder2Item";
        public static readonly UniqueEntityId WELDER2ITEM_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalGunObject), WELDER2ITEM_SUBTYPEID);

        public const string WELDER3ITEM_SUBTYPEID = "Welder3Item";
        public static readonly UniqueEntityId WELDER3ITEM_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalGunObject), WELDER3ITEM_SUBTYPEID);

        public const string WELDER4ITEM_SUBTYPEID = "Welder4Item";
        public static readonly UniqueEntityId WELDER4ITEM_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalGunObject), WELDER4ITEM_SUBTYPEID);

        public const string PISTOL_SA_MAGZINE_SUBTYPEID = "SemiAutoPistolMagazine";
        public static readonly UniqueEntityId PISTOL_SA_MAGZINE_ID = new UniqueEntityId(typeof(MyObjectBuilder_AmmoMagazine), PISTOL_SA_MAGZINE_SUBTYPEID);

        public const string PISTOL_RF_MAGZINE_SUBTYPEID = "FullAutoPistolMagazine";
        public static readonly UniqueEntityId PISTOL_RF_MAGZINE_ID = new UniqueEntityId(typeof(MyObjectBuilder_AmmoMagazine), PISTOL_RF_MAGZINE_SUBTYPEID);

        public const string PISTOL_PF_MAGZINE_SUBTYPEID = "ElitePistolMagazine";
        public static readonly UniqueEntityId PISTOL_PF_MAGZINE_ID = new UniqueEntityId(typeof(MyObjectBuilder_AmmoMagazine), PISTOL_PF_MAGZINE_SUBTYPEID);

        public const string RIFLE_SA_MAGZINE_SUBTYPEID = "AutomaticRifleGun_Mag_20rd";
        public static readonly UniqueEntityId RIFLE_SA_MAGZINE_ID = new UniqueEntityId(typeof(MyObjectBuilder_AmmoMagazine), RIFLE_SA_MAGZINE_SUBTYPEID);

        public const string RIFLE_RF_MAGZINE_SUBTYPEID = "RapidFireAutomaticRifleGun_Mag_50rd";
        public static readonly UniqueEntityId RIFLE_RF_MAGZINE_ID = new UniqueEntityId(typeof(MyObjectBuilder_AmmoMagazine), RIFLE_RF_MAGZINE_SUBTYPEID);

        public const string RIFLE_PF_MAGZINE_SUBTYPEID = "PreciseAutomaticRifleGun_Mag_5rd";
        public static readonly UniqueEntityId RIFLE_PF_MAGZINE_ID = new UniqueEntityId(typeof(MyObjectBuilder_AmmoMagazine), RIFLE_PF_MAGZINE_SUBTYPEID);

        public const string RIFLE_E_MAGZINE_SUBTYPEID = "UltimateAutomaticRifleGun_Mag_30rd";
        public static readonly UniqueEntityId RIFLE_E_MAGZINE_ID = new UniqueEntityId(typeof(MyObjectBuilder_AmmoMagazine), RIFLE_E_MAGZINE_SUBTYPEID);

        public const string AUTOCANNONCLIP_SUBTYPEID = "AutocannonClip";
        public static readonly UniqueEntityId AUTOCANNONCLIP_ID = new UniqueEntityId(typeof(MyObjectBuilder_AmmoMagazine), AUTOCANNONCLIP_SUBTYPEID);

        public const string NATO_25X184MM_SUBTYPEID = "NATO_25x184mm";
        public static readonly UniqueEntityId NATO_25X184MM_ID = new UniqueEntityId(typeof(MyObjectBuilder_AmmoMagazine), NATO_25X184MM_SUBTYPEID);

        public const string MEDIUMCALIBREAMMO_SUBTYPEID = "MediumCalibreAmmo";
        public static readonly UniqueEntityId MEDIUMCALIBREAMMO_ID = new UniqueEntityId(typeof(MyObjectBuilder_AmmoMagazine), MEDIUMCALIBREAMMO_SUBTYPEID);

        public const string LARGECALIBREAMMO_SUBTYPEID = "LargeCalibreAmmo";
        public static readonly UniqueEntityId LARGECALIBREAMMO_ID = new UniqueEntityId(typeof(MyObjectBuilder_AmmoMagazine), LARGECALIBREAMMO_SUBTYPEID);

        public const string SMALLRAILGUNAMMO_SUBTYPEID = "SmallRailgunAmmo";
        public static readonly UniqueEntityId SMALLRAILGUNAMMO_ID = new UniqueEntityId(typeof(MyObjectBuilder_AmmoMagazine), SMALLRAILGUNAMMO_SUBTYPEID);

        public const string LARGERAILGUNAMMO_SUBTYPEID = "LargeRailgunAmmo";
        public static readonly UniqueEntityId LARGERAILGUNAMMO_ID = new UniqueEntityId(typeof(MyObjectBuilder_AmmoMagazine), LARGERAILGUNAMMO_SUBTYPEID);

        public const string MISSILE200MM_SUBTYPEID = "Missile200mm";
        public static readonly UniqueEntityId MISSILE200MM_ID = new UniqueEntityId(typeof(MyObjectBuilder_AmmoMagazine), MISSILE200MM_SUBTYPEID);

        public const string ZONECHIP_SUBTYPEID = "ZoneChip";
        public static readonly UniqueEntityId ZONECHIP_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), ZONECHIP_SUBTYPEID);

        public const string MOTOR_SUBTYPEID = "Motor";
        public static readonly UniqueEntityId MOTOR_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), MOTOR_SUBTYPEID);

        public const string COMPUTER_SUBTYPEID = "Computer";
        public static readonly UniqueEntityId COMPUTER_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), COMPUTER_SUBTYPEID);

        public const string BULLETPROOFGLASS_SUBTYPEID = "BulletproofGlass";
        public static readonly UniqueEntityId BULLETPROOFGLASS_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), BULLETPROOFGLASS_SUBTYPEID);

        public const string RADIO_COMP_SUBTYPEID = "RadioCommunication";
        public static readonly UniqueEntityId RADIO_COMP_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), RADIO_COMP_SUBTYPEID);

        public const string POWERCELL_SUBTYPEID = "PowerCell";
        public static readonly UniqueEntityId POWERCELL_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), POWERCELL_SUBTYPEID);

        public const string DETECTOR_SUBTYPEID = "Detector";
        public static readonly UniqueEntityId DETECTOR_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), DETECTOR_SUBTYPEID);

        public const string REACTOR_SUBTYPEID = "Reactor";
        public static readonly UniqueEntityId REACTOR_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), REACTOR_SUBTYPEID);

        public const string STEELPLATE_SUBTYPEID = "SteelPlate";
        public static readonly UniqueEntityId STEELPLATE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), STEELPLATE_SUBTYPEID);

        public const string GIRDER_SUBTYPEID = "Girder";
        public static readonly UniqueEntityId GIRDER_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), GIRDER_SUBTYPEID);

        public const string DISPLAY_SUBTYPEID = "Display";
        public static readonly UniqueEntityId DISPLAY_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), DISPLAY_SUBTYPEID);

        public const string MEDICAL_SUBTYPEID = "Medical";
        public static readonly UniqueEntityId MEDICAL_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), MEDICAL_SUBTYPEID);

        public const string SUPERCONDUCTOR_SUBTYPEID = "Superconductor";
        public static readonly UniqueEntityId SUPERCONDUCTOR_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), SUPERCONDUCTOR_SUBTYPEID);

        public const string CONSTRUCTION_SUBTYPEID = "Construction";
        public static readonly UniqueEntityId CONSTRUCTION_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), CONSTRUCTION_SUBTYPEID);

        public const string SOLARCELL_SUBTYPEID = "SolarCell";
        public static readonly UniqueEntityId SOLARCELL_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), SOLARCELL_SUBTYPEID);

        public const string EXPLOSIVES_SUBTYPEID = "Explosives";
        public static readonly UniqueEntityId EXPLOSIVES_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), EXPLOSIVES_SUBTYPEID);

        public const string INTERIORPLATE_SUBTYPEID = "InteriorPlate";
        public static readonly UniqueEntityId INTERIORPLATE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), INTERIORPLATE_SUBTYPEID);

        public const string SMALLTUBE_SUBTYPEID = "SmallTube";
        public static readonly UniqueEntityId SMALLTUBE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), SMALLTUBE_SUBTYPEID);

        public const string LARGETUBE_SUBTYPEID = "LargeTube";
        public static readonly UniqueEntityId LARGETUBE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), LARGETUBE_SUBTYPEID);

        public const string THRUST_SUBTYPEID = "Thrust";
        public static readonly UniqueEntityId THRUST_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), THRUST_SUBTYPEID);

        public const string ICE_SUBTYPEID = "Ice";
        public static readonly UniqueEntityId ICE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), ICE_SUBTYPEID);

        public const string MEDKIT_SUBTYPEID = "Medkit";
        public static readonly UniqueEntityId MEDKIT_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), MEDKIT_SUBTYPEID);

        public const string DATAPAD_SUBTYPEID = "Datapad";
        public static readonly UniqueEntityId DATAPAD_ID = new UniqueEntityId(typeof(MyObjectBuilder_Datapad), DATAPAD_SUBTYPEID);

        public const string CHAMPIGNONS_SUBTYPEID = "Champignons";
        public static readonly UniqueEntityId CHAMPIGNONS_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), CHAMPIGNONS_SUBTYPEID);

        public const string SHIITAKE_SUBTYPEID = "Shiitake";
        public static readonly UniqueEntityId SHIITAKE_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), SHIITAKE_SUBTYPEID);

        public const string AMANITAMUSCARIA_SUBTYPEID = "AmanitaMuscaria";
        public static readonly UniqueEntityId AMANITAMUSCARIA_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), AMANITAMUSCARIA_SUBTYPEID);

        public const string BEETROOT_SUBTYPEID = "Beetroot";
        public static readonly UniqueEntityId BEETROOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), BEETROOT_SUBTYPEID);

        public const string CAROOT_SUBTYPEID = "Carrot";
        public static readonly UniqueEntityId CAROOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), CAROOT_SUBTYPEID);

        public const string ARNICA_SUBTYPEID = "Arnica";
        public static readonly UniqueEntityId ARNICA_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), ARNICA_SUBTYPEID);

        public const string CHAMOMILE_SUBTYPEID = "Chamomile";
        public static readonly UniqueEntityId CHAMOMILE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), CHAMOMILE_SUBTYPEID);

        public const string ALOEVERA_SUBTYPEID = "AloeVera";
        public static readonly UniqueEntityId ALOEVERA_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), ALOEVERA_SUBTYPEID);

        public const string MINT_SUBTYPEID = "Mint";
        public static readonly UniqueEntityId MINT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), MINT_SUBTYPEID);

        public const string ERYTHROXYLUM_SUBTYPEID = "Erythroxylum";
        public static readonly UniqueEntityId ERYTHROXYLUM_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), ERYTHROXYLUM_SUBTYPEID);

        public const string FISH_BAIT_SUBTYPEID = "FishBait";
        public static readonly UniqueEntityId FISH_BAIT_SMALL_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), FISH_BAIT_SUBTYPEID);

        public const string FISH_NOBLE_BAIT_SUBTYPEID = "FishNobleBait";
        public static readonly UniqueEntityId FISH_NOBLE_BAIT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), FISH_NOBLE_BAIT_SUBTYPEID);

        public const string MEAT_SUBTYPEID = "Meat";
        public static readonly UniqueEntityId MEAT_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), MEAT_SUBTYPEID);

        public const string NOBLE_MEAT_SUBTYPEID = "NobleMeat";
        public static readonly UniqueEntityId NOBLE_MEAT_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), NOBLE_MEAT_SUBTYPEID);

        public const string ALIEN_MEAT_SUBTYPEID = "AlienMeat";
        public static readonly UniqueEntityId ALIEN_MEAT_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), ALIEN_MEAT_SUBTYPEID);

        public const string ALIEN_NOBLE_MEAT_SUBTYPEID = "AlienNobleMeat";
        public static readonly UniqueEntityId ALIEN_NOBLE_MEAT_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), ALIEN_NOBLE_MEAT_SUBTYPEID);

        public const string BONES_SUBTYPEID = "Bones";
        public static readonly UniqueEntityId BONES_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), BONES_SUBTYPEID);

        public const string ALIEN_EGG_SUBTYPEID = "AlienEgg";
        public static readonly UniqueEntityId ALIEN_EGG_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), ALIEN_EGG_SUBTYPEID);

        public const string SPOILED_MATERIAL_SUBTYPEID = "Organic";
        public static readonly UniqueEntityId SPOILED_MATERIAL_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), SPOILED_MATERIAL_SUBTYPEID);

        public const string CEREAL_SUBTYPEID = "Cereal";
        public static readonly UniqueEntityId CEREAL_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), CEREAL_SUBTYPEID);

        public const string APPLE_SUBTYPEID = "Apple";
        public static readonly UniqueEntityId APPLE_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), APPLE_SUBTYPEID);

        public const string APPLETREESEEDLING_SUBTYPEID = "AppleTreeSeedling";
        public static readonly UniqueEntityId APPLETREESEEDLING_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), APPLETREESEEDLING_SUBTYPEID);

        private static ConcurrentDictionary<UniqueEntityId, MyObjectBuilder_Base> BUILDERS_CACHE = new ConcurrentDictionary<UniqueEntityId, MyObjectBuilder_Base>();

        public static T GetBuilder<T>(UniqueEntityId id, bool cache = true) where T : MyObjectBuilder_Base
        {
            if (cache && BUILDERS_CACHE.ContainsKey(id))
                return BUILDERS_CACHE[id] as T;
            var builder = MyObjectBuilderSerializer.CreateNewObject(id.DefinitionId) as T;
            BUILDERS_CACHE[id] = builder;
            return builder as T;
        }

        public static MyObjectBuilder_PhysicalObject GetPhysicalObjectBuilder(UniqueEntityId id)
        {
            return GetBuilder<MyObjectBuilder_PhysicalObject>(id);
        }

        public static MyObjectBuilder_Datapad GetDatapadObjectBuilder(UniqueEntityId id, string name, string data)
        {
            var builder = GetBuilder<MyObjectBuilder_Datapad>(id, false);
            builder.Name = name;
            builder.Data = data;
            return builder;
        }

        public static MyObjectBuilder_GasContainerObject GetGasContainerBuilder(UniqueEntityId id, float gasLevel = 0)
        {
            var builder = GetBuilder<MyObjectBuilder_GasContainerObject>(id, false);
            builder.GasLevel = gasLevel;
            return builder;
        }

    }

}
