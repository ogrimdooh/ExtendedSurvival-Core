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

        public const string ALIENSOIL_SUBTYPEID = "AlienSoil";
        public static readonly UniqueEntityId ALIENSOIL_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), ALIENSOIL_SUBTYPEID);

        public const string SOIL_SUBTYPEID = "Soil";
        public static readonly UniqueEntityId SOIL_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), SOIL_SUBTYPEID);

        public const string MOONSOIL_SUBTYPEID = "MoonSoil";
        public static readonly UniqueEntityId MOONSOIL_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), MOONSOIL_SUBTYPEID);

        public const string DESERTSOIL_SUBTYPEID = "DesertSoil";
        public static readonly UniqueEntityId DESERTSOIL_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), DESERTSOIL_SUBTYPEID);

        public const string TOXICICE_SUBTYPEID = "ToxicIce";
        public static readonly UniqueEntityId TOXICICE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), TOXICICE_SUBTYPEID);

        public const string ICE_SUBTYPEID = "Ice";
        public static readonly UniqueEntityId ICE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), ICE_SUBTYPEID);

        public const string THERMALGAS_SUBTYPEID = "ThermalGas";
        public static readonly UniqueEntityId THERMALGAS_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasProperties), THERMALGAS_SUBTYPEID);

        public const string FLASK_SMALL_SUBTYPEID = "Flask_Small";
        public static readonly UniqueEntityId FLASK_SMALL_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), FLASK_SMALL_SUBTYPEID);

        public const string FLASK_MEDIUM_SUBTYPEID = "Flask_Medium";
        public static readonly UniqueEntityId FLASK_MEDIUM_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), FLASK_MEDIUM_SUBTYPEID);

        public const string FLASK_BIG_SUBTYPEID = "Flask_Big";
        public static readonly UniqueEntityId FLASK_BIG_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), FLASK_BIG_SUBTYPEID);

        public const string WATER_FLASK_SMALL_SUBTYPEID = "Water_Flask_Small";
        public static readonly UniqueEntityId WATER_FLASK_SMALL_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), WATER_FLASK_SMALL_SUBTYPEID);

        public const string WATER_FLASK_MEDIUM_SUBTYPEID = "Water_Flask_Medium";
        public static readonly UniqueEntityId WATER_FLASK_MEDIUM_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), WATER_FLASK_MEDIUM_SUBTYPEID);

        public const string WATER_FLASK_BIG_SUBTYPEID = "Water_Flask_Big";
        public static readonly UniqueEntityId WATER_FLASK_BIG_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), WATER_FLASK_BIG_SUBTYPEID);

        public const string WOODLOG_SUBTYPEID = "Wood";
        public static readonly UniqueEntityId WOODLOG_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), WOODLOG_SUBTYPEID);

        public const string LEAF_SUBTYPEID = "Leaf";
        public static readonly UniqueEntityId LEAF_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), LEAF_SUBTYPEID);

        public const string TWIG_SUBTYPEID = "Twig";
        public static readonly UniqueEntityId TWIG_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), TWIG_SUBTYPEID);

        public const string BRANCH_SUBTYPEID = "Branch";
        public static readonly UniqueEntityId BRANCH_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), BRANCH_SUBTYPEID);

        public const string PISTOL_SA_MAGZINE_SUBTYPEID = "SemiAutoPistolMagazine";
        public static readonly UniqueEntityId PISTOL_SA_MAGZINE_ID = new UniqueEntityId(typeof(MyObjectBuilder_AmmoMagazine), PISTOL_SA_MAGZINE_SUBTYPEID);

        public const string ANGLEGRINDERITEM_SUBTYPEID = "AngleGrinderItem";
        public static readonly UniqueEntityId ANGLEGRINDERITEM_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalGunObject), ANGLEGRINDERITEM_SUBTYPEID);
        
        public const string HANDDRILLITEM_SUBTYPEID = "HandDrillItem";
        public static readonly UniqueEntityId HANDDRILLITEM_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalGunObject), HANDDRILLITEM_SUBTYPEID);

        public const string WELDERITEM_SUBTYPEID = "WelderItem";
        public static readonly UniqueEntityId WELDERITEM_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalGunObject), WELDERITEM_SUBTYPEID);

        public const string SEMIAUTOPISTOLITEM_SUBTYPEID = "SemiAutoPistolItem";
        public static readonly UniqueEntityId SEMIAUTOPISTOLITEM_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalGunObject), SEMIAUTOPISTOLITEM_SUBTYPEID);

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

        public static MyObjectBuilder_GasContainerObject GetGasContainerBuilder(UniqueEntityId id, float gasLevel = 0)
        {
            var builder = GetBuilder<MyObjectBuilder_GasContainerObject>(id, false);
            builder.GasLevel = gasLevel;
            return builder;
        }

    }

}
