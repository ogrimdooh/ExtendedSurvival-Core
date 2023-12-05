using System;
using VRage;

namespace ExtendedSurvival.Core
{

    public class EnglishLanguageTemplate : BaseLanguageTemplate
    {

        public EnglishLanguageTemplate() 
            : base(MyLanguagesEnum.English)
        {
        }

        protected override void DoLoadEntries()
        {
			#region GENERALS
			AddEntry(
				LanguageEntries.TERMS_YES_NAME,
				"Yes"
			);
			AddEntry(
				LanguageEntries.TERMS_NO_NAME,
				"No"
			);
			#endregion
			#region CUBE_BLOCKS
			AddEntry(
				LanguageEntries.CUBEBLOCK_ALCHEMYBENCH_BASIC,
				"Basic Laboratory"
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_ALCHEMYBENCH,
				"Laboratory"
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_ALCHEMYBENCH_INDUSTRIAL,
				"Industrial Laboratory"
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_ALCHEMYBENCH_DESCRIPTION,
				"Laboratory blocks are responsible for combining substances and " + Environment.NewLine +
				"ores to produce medicines, metal alloys and ammunition."
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_GRINDER_BASIC,
				"Basic Grinder"
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_GRINDER,
				"Grinder"
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_GRINDER_INDUSTRIAL,
				"Industrial Grinder"
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_GRINDER_DESCRIPTION,
				"Grinder blocks are responsible for deconstructing ores and " + Environment.NewLine +
				"recycling components."
			);

			#endregion
			#region INGOTS
			AddEntry(
				LanguageEntries.SOIL_NAME,
				"Soil Powder"
			);
			AddEntry(
				LanguageEntries.SOIL_DESCRIPTION,
				"Processed soil, ideal for growing plants."
			);
			AddEntry(
				LanguageEntries.SAND_NAME,
				"Sand"
			);
			AddEntry(
				LanguageEntries.SAND_DESCRIPTION,
				"Fine, clean sand can be used to make glass."
			);
			AddEntry(
				LanguageEntries.CARBON_NAME,
				"Carbon Powder"
			);
			AddEntry(
				LanguageEntries.CARBON_DESCRIPTION,
				"It can be used in the manufacture of metal alloys, " + Environment.NewLine +
				"ammunition and components."
			);
			AddEntry(
				LanguageEntries.SILVERPOWDER_NAME,
				"Silver Powder"
			);
			AddEntry(
				LanguageEntries.SILVERPOWDER_DESCRIPTION,
				"It can be used in manufacturing medicine and health " + Environment.NewLine +
				"items."
			);
			#endregion
			#region ORES
			AddEntry(
				LanguageEntries.SOIL_ORE_NAME,
				"Soil"
			);
			AddEntry(
				LanguageEntries.SOIL_ORE_DESCRIPTION,
				"Raw soil, needs to be processed to be used."
			);
			AddEntry(
				LanguageEntries.ALIENSOIL_NAME,
				"Alien Soil"
			);
			AddEntry(
				LanguageEntries.ALIENSOIL_DESCRIPTION,
				"Raw soil, needs to be processed to be used."
			);
			AddEntry(
				LanguageEntries.ASTEROIDSOIL_NAME,
				"Asteroid Soil"
			);
			AddEntry(
				LanguageEntries.ASTEROIDSOIL_DESCRIPTION,
				"Raw soil, needs to be processed to be used."
			);
			AddEntry(
				LanguageEntries.DESERTSOIL_NAME,
				"Desert Soil"
			);
			AddEntry(
				LanguageEntries.DESERTSOIL_DESCRIPTION,
				"Raw soil, needs to be processed to be used."
			);
			AddEntry(
				LanguageEntries.MOONSOIL_NAME,
				"Moon Soil"
			);
			AddEntry(
				LanguageEntries.MOONSOIL_DESCRIPTION,
				"Raw soil, needs to be processed to be used."
			);
			AddEntry(
				LanguageEntries.ORGANIC_NAME,
				"Organic"
			);
			AddEntry(
				LanguageEntries.ORGANIC_DESCRIPTION,
				"It can be used in the manufacture of biofuels and " + Environment.NewLine +
				"with great application in agriculture."
			);
			AddEntry(
				LanguageEntries.ICE_NAME,
				"Ice"
			);
			AddEntry(
				LanguageEntries.ICE_DESCRIPTION,
				"Ice is water frozen into a solid state."
			);
			AddEntry(
				LanguageEntries.STONEICE_NAME,
				"Dirty Ice"
			);
			AddEntry(
				LanguageEntries.STONEICE_DESCRIPTION,
				"Soil with a fair concentration of ice."
			);
			AddEntry(
				LanguageEntries.TOXICICE_NAME,
				"Toxic Ice"
			);
			AddEntry(
				LanguageEntries.TOXICICE_DESCRIPTION,
				"Ice contaminated with organic substances."
			);
			AddEntry(
				LanguageEntries.WOOD_NAME,
				"Wood Log"
			);
			AddEntry(
				LanguageEntries.WOOD_DESCRIPTION,
				"It is a simple source of energy and the base material " + Environment.NewLine +
				"for many other resources."
			);
			AddEntry(
				LanguageEntries.TWIG_NAME,
				"Twig"
			);
			AddEntry(
				LanguageEntries.TWIG_DESCRIPTION,
				"Can be used to obtain sawdust."
			);
			AddEntry(
				LanguageEntries.SAWDUST_NAME,
				"Sawdust"
			);
			AddEntry(
				LanguageEntries.SAWDUST_DESCRIPTION,
				"Can be used for carbon and latex production."
			);
			AddEntry(
				LanguageEntries.LEAF_NAME,
				"Leaf"
			);
			AddEntry(
				LanguageEntries.LEAF_DESCRIPTION,
				"Can be used to obtain organic."
			);
			AddEntry(
				LanguageEntries.BRANCH_NAME,
				"Branch"
			);
			AddEntry(
				LanguageEntries.BRANCH_DESCRIPTION,
				"Can be used to obtain sawdust."
			);
			AddEntry(
				LanguageEntries.SAWDUSTTOCARBONPOWDER_NAME,
				"Carbon Powder From Sawdust"
			);
			AddEntry(
				LanguageEntries.LEAFTOORGANIC_NAME,
				"Organic From Leaf"
			);
			AddEntry(
				LanguageEntries.BRANCHTOSAWDUST_NAME,
				"Sawdust From Branch"
			);
			AddEntry(
				LanguageEntries.TWIGTOSAWDUST_NAME,
				"Sawdust From Twig"
			);
			AddEntry(
				LanguageEntries.WOODLOGTOSAWDUST_NAME,
				"Sawdust From Wood Log"
			);
			#endregion
			#region RECIPIENTS
			AddEntry(
				LanguageEntries.FLASK_SMALL_NAME,
				"Small Flask"
			);
			AddEntry(
				LanguageEntries.FLASK_SMALL_DESCRIPTION,
				"A small flask."
			);
			AddEntry(
				LanguageEntries.FLASK_MEDIUM_NAME,
				"Medium Flask"
			);
			AddEntry(
				LanguageEntries.FLASK_MEDIUM_DESCRIPTION,
				"A medium flask."
			);
			AddEntry(
				LanguageEntries.FLASK_BIG_NAME,
				"Big Flask"
			);
			AddEntry(
				LanguageEntries.FLASK_BIG_DESCRIPTION,
				"A big flask."
			);
			AddEntry(
				LanguageEntries.WATER_FLASK_SMALL_NAME,
				"Small Water Flask"
			);
			AddEntry(
				LanguageEntries.WATER_FLASK_SMALL_DESCRIPTION,
				"A small flask with water."
			);
			AddEntry(
				LanguageEntries.WATER_FLASK_MEDIUM_NAME,
				"Medium Water Flask"
			);
			AddEntry(
				LanguageEntries.WATER_FLASK_MEDIUM_DESCRIPTION,
				"A medium flask with water."
			);
			AddEntry(
				LanguageEntries.WATER_FLASK_BIG_NAME,
				"Big Water Flask"
			);
			AddEntry(
				LanguageEntries.WATER_FLASK_BIG_DESCRIPTION,
				"A big flask with water."
			);
			AddEntry(
				LanguageEntries.POLIETILENOGLICOL_NAME,
				"Polietilenoglicol"
			);
			AddEntry(
				LanguageEntries.POLIETILENOGLICOL_DESCRIPTION,
				"Synthetic polyether, hydrophilic and biocompatible."
			);
			AddEntry(
				LanguageEntries.SILVERSULFADIAZINE_NAME,
				"Silver Sulfadiazine"
			);
			AddEntry(
				LanguageEntries.SILVERSULFADIAZINE_DESCRIPTION,
				"Silver-based compound for medical use."
			);
			#endregion

			#region HELP

			AddEntry(
				LanguageEntries.HELP_TOPIC_RECIPIENTS_TITLE,
				"Extended Survival - Recipients"
			);
			AddEntry(
				LanguageEntries.HELP_TOPIC_RECIPIENTS_DESCRIPTION,
				"Recipients are the subset of items that are used in Survival Mode to store " + Environment.NewLine +
				"Foods and Substances." + Environment.NewLine +
				"Recipients are acquired by crafting them from refined materials in an " + Environment.NewLine +
				"Assembler, or looted from the inventories of container blocks onboard " + Environment.NewLine +
				"Pre - Built Ships."
			);

			AddEntry(
				LanguageEntries.HELP_TOPIC_ORES_TITLE,
				"Extended Survival - Ores"
			);
			AddEntry(
				LanguageEntries.HELP_TOPIC_ORES_DESCRIPTION,
				"Ores are mined from Asteroids or Planets, and are processed into ingots " + Environment.NewLine +
				"in one of the Refineries. Grids are made of blocks, blocks are made of " + Environment.NewLine +
				"components, components are made of materials, materials are made of ores." + Environment.NewLine +
				"You mine ores from voxels using either a ship - mounted drill or Hand Drill. " + Environment.NewLine +
				"Ores can also be looted from the cargo holds of some pre-built ships, " + Environment.NewLine +
				"especially mining ships." + Environment.NewLine +
				"Ice is mined just like ore, but processed in an O2 H2 Generator which " + Environment.NewLine +
				"is not covered here."
			);

			AddEntry(
				LanguageEntries.HELP_TOPIC_INGOTS_TITLE,
				"Extended Survival - Ingots"
			);
			AddEntry(
				LanguageEntries.HELP_TOPIC_INGOTS_DESCRIPTION,
				"Materials are the subset of items that are produced by the Refineries " + Environment.NewLine +
				"and used up by Assemblers. Grids are made of blocks, blocks are made " + Environment.NewLine +
				"of components, components are made of materials, materials are made " + Environment.NewLine +
				"of ores."
			);

			AddEntry(
				LanguageEntries.HELP_TOPIC_SYSTEM_TITLE,
				"Extended Survival: Core - Systems"
			);
			AddEntry(
				LanguageEntries.HELP_TOPIC_SYSTEM_DESCRIPTION,
				""
			);

			AddEntry(
				LanguageEntries.HELP_TOPIC_CONFIGURATION_TITLE,
				"Extended Survival: Core - Configurations"
			);
			AddEntry(
				LanguageEntries.HELP_TOPIC_CONFIGURATION_DESCRIPTION,
				"Each module of the Extended Survival mod has its configuration file where values " + Environment.NewLine +
				"can be defined that change the behavior of the modified systems.The configuration " + Environment.NewLine +
				"file is located at:" + Environment.NewLine +
				"" + Environment.NewLine +
				"<SAVE>\\Storage\\ExtendedSurvival-Core_ExtendedSurvival-Core\\" + Environment.NewLine +
				"ExtendedSurvival.Core.Settings.xml" + Environment.NewLine +
				"" + Environment.NewLine +
				"It is recommended to always make a backup of the file when changed and changes " + Environment.NewLine +
				"will only take effect if the server/save is unloaded."
			);

			AddEntry(
				LanguageEntries.HELP_SETTINGS_DEBUG_DESCRIPTION,
				"This configuration increases the mod's log level, showing more operation points " + Environment.NewLine +
				"in the server console." + Environment.NewLine +
				"This increase in log operations can increase the size of log files, and slow down " + Environment.NewLine +
				"the game."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_DINAMICWOODGRIDENABLED_DESCRIPTION,
				"This configuration enable the possibility to build dynamic grids (not stations) " + Environment.NewLine +
				"using wood blocks."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_DINAMICSTONEGRIDENABLED_DESCRIPTION,
				"This configuration enable the possibility to build dynamic grids (not stations) " + Environment.NewLine +
				"using stone blocks."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_DINAMICCONCRETEGRIDENABLED_DESCRIPTION,
				"This configuration enable the possibility to build dynamic grids (not stations) " + Environment.NewLine +
				"using concrete blocks."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_ROTENABLED_DESCRIPTION,
				"This configuration enable the decay system of inventory itens, when enable foods " + Environment.NewLine +
				"will root and turn into organic waste."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_DISABLEWATERMODFREEICE_DESCRIPTION,
				"This configuration disable the water mod default collector ice generation when " + Environment.NewLine +
				"submerge, the amount of ice is too unbalanced."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_RESPAWNSPACEPODENABLED_DESCRIPTION,
				"This configuration enable the possibility to respawn in a space pod. If using " + Environment.NewLine +
				"a world generate with starsystem command and using a asteroid belt, it will" + Environment.NewLine +
				"spawn around asteroids in the belt."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_RESPAWNLARGEPODENABLED_DESCRIPTION,
				"This configuration enable the possibility to respawn in a large grid rover."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETDEPLOYALTITUDE_DESCRIPTION,
				"This configuration set the altitute that will spawn the start rover in planets " + Environment.NewLine +
				"with atmosphere and high gravity."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_MOONDEPLOYALTITUDE_DESCRIPTION,
				"This configuration set the altitute that will spawn the start rover in planets " + Environment.NewLine +
				"with no atmosphere or low gravity."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_DROPCONTAINERDEPLOYHEIGHT_DESCRIPTION,
				"This configuration set the altitute that drop containers will open parachutes. " + Environment.NewLine +
				"High values ​​can make a container take a long time to reach the ground, but " + Environment.NewLine +
				"they can guarantee the integrity of the grid."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_TRADESTATIONS_DESCRIPTION,
				"This configuration group define the behavior of exchange stations created by " + Environment.NewLine +
				"the starsystem command."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_TRADESTATIONS_COMERCIALCYCLE_DESCRIPTION,
				"This configuration set the time in seconds of each economy cycle, when a cycle " + Environment.NewLine +
				"ends all stations will got new trade offers." 
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_TRADESTATIONS_TRADEFACTIONSAMOUNT_DESCRIPTION,
				"This configuration set the range amount of factions when generate a world " +
				"when usign the starsystem command."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_METEORIMPACT_DESCRIPTION,
				"This configuration group define the behavior of the meteor impact system."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_METEORIMPACT_ENABLED_DESCRIPTION,
				"This configuration enable the meteor impact system."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_METEORIMPACT_DISTANCETOSPAWN_DESCRIPTION,
				"This configuration set the max distance from a player to spawn a stone in a " + Environment.NewLine +
				"asteroid crater."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_METEORIMPACT_STONELIFETIME_DESCRIPTION,
				"This configuration set the time in seconds to remove generate stones when no " + Environment.NewLine +
				"players around it."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_DESCRIPTION,
				"This configuration group define the behavior of each planet type."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_ID_DESCRIPTION,
				"The planet type id from the configuration, used as identification to the " + Environment.NewLine +
				"definitions override."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_USINGTECHNOLOGY_DESCRIPTION,
				"The identification that this configuration was created with the Extended " + Environment.NewLine +
				"Sruvival Technology Module added to the save."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_RESPAWNENABLED_DESCRIPTION,
				"This configuration enable the possibility to respawn in a planet of the " + Environment.NewLine +
				"configuration type."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_SEED_DESCRIPTION,
				"The seed used to generate the ore map of the planet configuration type. " + Environment.NewLine +
				"Change this value will not impact in the ore map created."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_VERSION_DESCRIPTION,
				"The version of the template of the planet configuration type."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_DEEPMULTIPLIER_DESCRIPTION,
				"The deep multiplier used to generate the ore map of the planet configuration " + Environment.NewLine +
				"type." + Environment.NewLine +
				"Change this value will not impact in the ore map created."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_TYPE_DESCRIPTION,
				"This configuration set the planet categorization type, this value is used " + Environment.NewLine +
				"by the starsystem command to generate consistent worlds. " + Environment.NewLine +
				" " + Environment.NewLine +
				"Valid categorization types: " + Environment.NewLine +
				"- Planet = 0 " + Environment.NewLine +
				"- Moon = 1 " + Environment.NewLine +
				"- GiantGas = 2 " + Environment.NewLine +
				"- Star = 4"
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_ADDEDORES_DESCRIPTION,
				"The added ores used to generate the ore map of the planet configuration type. " + Environment.NewLine +
				"Change this value will not impact in the ore map created."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_REMOVEDORES_DESCRIPTION,
				"The removed ores used to generate the ore map of the planet configuration type. " + Environment.NewLine +
				"Change this value will not impact in the ore map created."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_CLEARORESBEFOREADD_DESCRIPTION,
				"Inform if default ores were removed before to generate the ore map of the planet " + Environment.NewLine +
				"configuration type. " + Environment.NewLine +
				"Change this value will not impact in the ore map created."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_TARGETCOLOR_DESCRIPTION,
				"The target color used to generate the ore map of the planet configuration type. " + Environment.NewLine +
				"Change this value will not impact in the ore map created."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_USECOLORINFLUENCE_DESCRIPTION,
				"Inform if was used a target color to generate the ore map of the planet " + Environment.NewLine +
				"configuration type. " + Environment.NewLine +
				"Change this value will not impact in the ore map created."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_OREGROUPTYPE_DESCRIPTION,
				"The ore group type used to generate the ore map of the planet configuration type. " + Environment.NewLine +
				"Change this value will not impact in the ore map created." + Environment.NewLine +
				"" + Environment.NewLine +
				"Valid types: " + Environment.NewLine +
				"- Large Group = 0 : A group with many ores, can stack 6 ores in a same spot." + Environment.NewLine +
				"- Small Group = 1 : A group with less ores, can stack 4 ores in a same spot." + Environment.NewLine +
				"- Large Group Short Space = 2 : A group with many ores, can stack 6 ores in a same " + Environment.NewLine +
				"spot, try to space the spots to not had many ores spots together." + Environment.NewLine +
				"- Small Group Short Space = 3 : A group with less ores, can stack 4 ores in a same " + Environment.NewLine +
				"spot, try to space the spots to not had many ores spots together." + Environment.NewLine +
				"- Concentrated = 4 : Will try to create isolated ores spots, can stack 4 ores in " + Environment.NewLine +
				"a same spot."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_COLORINFLUENCE_DESCRIPTION,
				"The color influence used to generate the ore map of the planet configuration type. " + Environment.NewLine +
				"Change this value will not impact in the ore map created."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_SIZERANGE_DESCRIPTION,
				"This configuration set the planet size range (minimum and maximum) to be used in " + Environment.NewLine +
				"planet generation routines."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_ATMOSPHERE_DESCRIPTION,
				"This configuration group define the behavior of the atmosphere of the planet " + Environment.NewLine +
				"type."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_ATMOSPHERE_ENABLED_DESCRIPTION,
				"This configuration enable the atmosphere in the planet of the configuration " + Environment.NewLine +
				"type."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_ATMOSPHERE_BREATHABLE_DESCRIPTION,
				"This configuration set the atmosphere as breathable in the planet of the " + Environment.NewLine +
				"configuration type."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_ATMOSPHERE_OXYGENDENSITY_DESCRIPTION,
				"This configuration set the oxygen density in the atmosphere of the planet " + Environment.NewLine +
				"of the configuration type."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_ATMOSPHERE_DENSITY_DESCRIPTION,
				"This configuration set the air density in the atmosphere of the planet of " + Environment.NewLine +
				"the configuration type."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_ATMOSPHERE_LIMITALTITUDE_DESCRIPTION,
				"This configuration set the oxygen density in the atmosphere of the planet of " + Environment.NewLine +
				"the configuration type."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_ATMOSPHERE_MAXWINDSPEED_DESCRIPTION,
				"This configuration set the max wind speed in the atmosphere of the planet of " + Environment.NewLine +
				"the configuration type."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_ATMOSPHERE_TEMPERATURELEVEL_DESCRIPTION,
				"This configuration set the temperature level in the atmosphere of the planet of " + Environment.NewLine +
				"the configuration type." + Environment.NewLine +
				" " + Environment.NewLine +
				"Valid Temperature Levels: " + Environment.NewLine +
				"- Extreme Freeze = 0 " + Environment.NewLine +
				"- Freeze = 1 " + Environment.NewLine +
				"- Cozy = 2 " + Environment.NewLine +
				"- Hot = 3 " + Environment.NewLine +
				"- Extreme Hot = 4"
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_ATMOSPHERE_TEMPERATURERANGE_DESCRIPTION,
				"This configuration set the temperature range (minimum and maximum) in the " + Environment.NewLine +
				"atmosphere the planet of the configuration type."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_ATMOSPHERE_TOXICLEVEL_DESCRIPTION,
				"This configuration set the toxic level in the atmosphere of the planet of " + Environment.NewLine +
				"the configuration type."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_ATMOSPHERE_RADIATIONLEVEL_DESCRIPTION,
				"This configuration set the radiation level in the atmosphere of the planet of " + Environment.NewLine +
				"the configuration type."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_GEOTHERMAL_DESCRIPTION,
				"This configuration group define the behavior of the geothermal power of the " + Environment.NewLine +
				"planet type." + Environment.NewLine +
				"You can read more about the geothermal in the systems topics."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_GEOTHERMAL_ENABLED_DESCRIPTION,
				"This configuration enable the geothermal in the planet of the configuration " + Environment.NewLine +
				"type."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_GEOTHERMAL_START_DESCRIPTION,
				"This configuration set the start depth in meters to generate geothermal power " + Environment.NewLine +
				"in the planet of the configuration type."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_GEOTHERMAL_ROWSIZE_DESCRIPTION,
				"This configuration set the row size in meters to increment geothermal power " + Environment.NewLine +
				"in the planet of the configuration type."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_GEOTHERMAL_POWER_DESCRIPTION,
				"This configuration set the base power generate by geothermal power " + Environment.NewLine +
				"in the planet of the configuration type."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_GEOTHERMAL_MAXPOWER_DESCRIPTION,
				"This configuration set the max power generate by geothermal power " + Environment.NewLine +
				"in the planet of the configuration type."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_GEOTHERMAL_INCREMENT_DESCRIPTION,
				"This configuration set the increment power by each row generate by " + Environment.NewLine +
				"geothermal power in the planet of the configuration type."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_GRAVITY_DESCRIPTION,
				"This configuration group define the behavior of the gravity of the " + Environment.NewLine +
				"planet type."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_GRAVITY_SURFACEGRAVITY_DESCRIPTION,
				"This configuration set the surface gravity in the planet of the " + Environment.NewLine +
				"configuration type."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_GRAVITY_GRAVITYFALLOFFPOWER_DESCRIPTION,
				"This configuration set the gravity fall off power in the planet of the " + Environment.NewLine +
				"configuration type." + Environment.NewLine +
				"This value make the gravity area bigger."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_WATER_DESCRIPTION,
				"This configuration group define the behavior of the water of the " + Environment.NewLine +
				"planet type." + Environment.NewLine +
				"Need Water Mod added to the save."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_WATER_ENABLED_DESCRIPTION,
				"This configuration enable the water in the planet of the configuration " + Environment.NewLine +
				"type." + Environment.NewLine +
				"When a admin player comes close to a planet with water enabled, the water " + Environment.NewLine +
				"will be added automaticaly."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_WATER_SIZE_DESCRIPTION,
				"This configuration set the water size in the planet of the configuration " + Environment.NewLine +
				"type."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_WATER_TEMPERATUREFACTOR_DESCRIPTION,
				"This configuration set the water temperature factor in the planet of the " + Environment.NewLine +
				"configuration type." + Environment.NewLine +
				"This value will change the enviroment temperature when player submerge."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_WATER_TOXICLEVEL_DESCRIPTION,
				"This configuration set the toxic level in the water of the planet of " + Environment.NewLine +
				"the configuration type."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_WATER_RADIATIONLEVEL_DESCRIPTION,
				"This configuration set the radiation level in the water of the planet of " + Environment.NewLine +
				"the configuration type."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_ANIMAL_DESCRIPTION,
				"This configuration group define the behavior of the animal spawn of the " + Environment.NewLine +
				"planet type."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_ANIMAL_ANIMALS_DESCRIPTION,
				"This configuration set the valid animals to spawn in the planet." + Environment.NewLine +
				"" + Environment.NewLine +
				"Valid animals:" + Environment.NewLine +
				"- SpaceSpider" + Environment.NewLine +
				"- SpaceSpiderGreen" + Environment.NewLine +
				"- SpaceSpiderBrown" + Environment.NewLine +
				"- SpaceSpiderBlack" + Environment.NewLine +
				"- Wolf" + Environment.NewLine +
				"- deer_bot" + Environment.NewLine +
				"- deerbuck_bot" + Environment.NewLine +
				"- Horse_Bot" + Environment.NewLine +
				"- Cow_Bot" + Environment.NewLine +
				"- Sheep_Bot"
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_ANIMAL_DAYSPAWN_DESCRIPTION,
				"This configuration group define the behavior of the spawn system during " + Environment.NewLine +
				"the day of the planet type."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_ANIMAL_NIGHTSPAWN_DESCRIPTION,
				"This configuration group define the behavior of the spawn system during " + Environment.NewLine +
				"the night of the planet type."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_ANIMALSPAWN_ENABLED_DESCRIPTION,
				"This configuration enable the spawn during the {0} in the planet of the " + Environment.NewLine +
				"configuration type."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_ANIMALSPAWN_SPAWNDELAY_DESCRIPTION,
				"This configuration set de spawn delay during the {0} in the planet of the " + Environment.NewLine +
				"configuration type."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_ANIMALSPAWN_SPAWNDIST_DESCRIPTION,
				"This configuration set de spawn distance during the {0} in the planet of the " + Environment.NewLine +
				"configuration type."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_ANIMALSPAWN_WAVECOUNT_DESCRIPTION,
				"This configuration set de wave count during the {0} in the planet of the " + Environment.NewLine +
				"configuration type."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_METEORIMPACT_DESCRIPTION,
				"This configuration group define the behavior of the meteor impact system " + Environment.NewLine +
				"of the planet type." + Environment.NewLine +
				"You can read more about the meteor impact in the systems topics."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_METEORIMPACT_ENABLED_DESCRIPTION,
				"This configuration enable the meteor impact system in the planet of the " + Environment.NewLine +
				"configuration type."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_METEORIMPACT_CHANCETOSPAWN_DESCRIPTION,
				"This configuration set the chance to spawn a stone at a meteor crater in the " + Environment.NewLine +
				"planet of the configuration type."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_METEORIMPACT_STONES_DESCRIPTION,
				"This configuration group set the valids voxels and modifiers to spawn at a " + Environment.NewLine +
				"meteor crater in the planet of the configuration type."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_METEORIMPACT_STONES_GROUPID_DESCRIPTION,
				"This configuration set the voxel that will spawn at the metor crater, named " + Environment.NewLine +
				"by the Keens as GroupId." + Environment.NewLine +
				"" + Environment.NewLine +
				"Valid Keen GroupId:" + Environment.NewLine +
				"- StoneCoverageIronCore" + Environment.NewLine +
				"- SnowCoverageIronCore"
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_METEORIMPACT_STONES_MODIFIERID_DESCRIPTION,
				"This configuration set the voxel modifier that will be aplied to the voxel " + Environment.NewLine +
				"created by the GroupId property."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_METEORIMPACT_STONES_CHANCETOSPAWN_DESCRIPTION,
				"This configuration set the chance to spawn this stone at a meteor crater in the " + Environment.NewLine +
				"planet of the configuration type."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_SUPERFICIALMINING_DESCRIPTION,
				"This configuration group define the behavior of the superficial mining system " + Environment.NewLine +
				"of the planet type." + Environment.NewLine +
				"You can read more about the superficial mining in the systems topics."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_SUPERFICIALMINING_ENABLED_DESCRIPTION,
				"This configuration enable the superficial mining system in the planet of the " + Environment.NewLine +
				"configuration type."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_SUPERFICIALMINING_DROPS_DESCRIPTION,
				"This configuration group set the valid drops to the superficial mining system " + Environment.NewLine +
				"of the planet type."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_SUPERFICIALMINING_DROPS_ITEMID_DESCRIPTION,
				"This configuration set the item id that can spawn by the superficial mining " + Environment.NewLine +
				"system."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_SUPERFICIALMINING_DROPS_AMMOUNT_DESCRIPTION,
				"This configuration set the item amount (minimum and maximum) that can spawn by " + Environment.NewLine +
				"the superficial mining system."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_SUPERFICIALMINING_DROPS_CHANCE_DESCRIPTION,
				"This configuration set the item chance (0-100) that can spawn by the superficial " + Environment.NewLine +
				"mining system."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_SUPERFICIALMINING_DROPS_ALOWFRAC_DESCRIPTION,
				"This configuration set if the spaw item can had a fractioned amount."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_SUPERFICIALMINING_DROPS_VALIDSUBTYPE_DESCRIPTION,
				"This configuration set the targets ore subtype that will be used by the " + Environment.NewLine +
				"superficial mining system."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_OREMAP_DESCRIPTION,
				"This configuration group define the behavior of the ore map system " + Environment.NewLine +
				"of the planet type." + Environment.NewLine +
				"You can read more about the ore map in the systems topics."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_OREMAP_VALUE_DESCRIPTION,
				"This configuration set the index of the ore map, values can be between " + Environment.NewLine +
				"0 - 255, and will impact in the ore distribution."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_OREMAP_TYPE_DESCRIPTION,
				"This configuration set the type of the ore that will be use in this " + Environment.NewLine +
				"target value of the ore map."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_OREMAP_START_DESCRIPTION,
				"This configuration set the start depth of the ore that will be use in " + Environment.NewLine +
				"this target value of the ore map."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_OREMAP_DEPTH_DESCRIPTION,
				"This configuration set the base depth after start of the ore that will " + Environment.NewLine +
				"be use in this target value of the ore map."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_OREMAP_TARGETCOLOR_DESCRIPTION,
				"This configuration set the target color of the ore that will be use in this " + Environment.NewLine +
				"target value of the ore map." + Environment.NewLine +
				"The ore map system is based in a RGB texture."
			);
			AddEntry(
				LanguageEntries.HELP_SETTINGS_PLANETS_OREMAP_COLORINFLUENCE_DESCRIPTION,
				"This configuration set the color influence of the ore that will be use in this " + Environment.NewLine +
				"target value of the ore map." + Environment.NewLine +
				"The ore map system is based in a RGB texture."
			);





			AddEntry(
				LanguageEntries.HELP_TOPIC_COMMAND_TITLE,
				"Extended Survival: Core - Commands"
			);
			AddEntry(
				LanguageEntries.HELP_TOPIC_COMMAND_DESCRIPTION,
				""
			);

			#endregion

			AddEntry(
				LanguageEntries.TERMS_MASS,
				"Mass"
			);
			AddEntry(
				LanguageEntries.TERMS_VOLUME,
				"Volume"
			);
			AddEntry(
				LanguageEntries.TERMS_RARITY,
				"Rarity"
			);
			AddEntry(
				LanguageEntries.TERMS_CANBUY,
				"Can buy"
			);
			AddEntry(
				LanguageEntries.TERMS_CANSELL,
				"Can sell"
			);
			AddEntry(
				LanguageEntries.TERMS_CANORDER,
				"Can order"
			);
			AddEntry(
				LanguageEntries.TERMS_BASEVALUE,
				"Base value"
			);
			AddEntry(
				LanguageEntries.TERMS_TARGETFACTIONS,
				"Target factions"
			);
			AddEntry(
				LanguageEntries.TERMS_ECONOMY_INFO,
				"Economy information:"
			);
			AddEntry(
				LanguageEntries.TERMS_RECIPE,
				"Recipe"
			);
			AddEntry(
				LanguageEntries.TERMS_PRODUCTIONTIME,
				"Production Time"
			);
			AddEntry(
				LanguageEntries.TERMS_INGREDIENTS,
				"Ingredients"
			);
			AddEntry(
				LanguageEntries.TERMS_RESULTS,
				"Results"
			);
			AddEntry(
				LanguageEntries.TERMS_CRAFTAT,
				"Craft at"
			);
			AddEntry(
				LanguageEntries.TERMS_REFINEAT,
				"Refine at"
			);
			AddEntry(
				LanguageEntries.TERMS_CONSUMEAT,
				"Consume at"
			);
			AddEntry(
				LanguageEntries.TERMS_SMALL,
				"Small"
			);
			AddEntry(
				LanguageEntries.TERMS_LARGE,
				"Large"
			);
			AddEntry(
				LanguageEntries.TERMS_DEFAULTVALUE,
				"Default value"
			);
			AddEntry(
				LanguageEntries.TERMS_NEEDRESTART,
				"Need restart to apply"
			);
			AddEntry(
				LanguageEntries.TERMS_TAKEIMMEDIATELY,
				"Take effect immediately"
			);
			AddEntry(
				LanguageEntries.TERMS_CANUSEADMINCOMMAND,
				"Can be change using admin command"
			);
			AddEntry(
				LanguageEntries.TERMS_DAY,
				"Day"
			);
			AddEntry(
				LanguageEntries.TERMS_NIGHT,
				"Night"
			);




			AddEntry(
				LanguageEntries.ITEMRARITY_COMMON,
				"Common"
			);
			AddEntry(
				LanguageEntries.ITEMRARITY_UNCOMMON,
				"Uncommon"
			);
			AddEntry(
				LanguageEntries.ITEMRARITY_NORMAL,
				"Normal"
			);
			AddEntry(
				LanguageEntries.ITEMRARITY_RARE,
				"Rare"
			);
			AddEntry(
				LanguageEntries.ITEMRARITY_EPIC,
				"Epic"
			);
			AddEntry(
				LanguageEntries.FACTIONTYPE_MINER,
				"Miner"
			);
			AddEntry(
				LanguageEntries.FACTIONTYPE_LUMBER,
				"Lumber"
			);
			AddEntry(
				LanguageEntries.FACTIONTYPE_SHIPYARD,
				"Shipyard"
			);
			AddEntry(
				LanguageEntries.FACTIONTYPE_ARMORY,
				"Armory"
			);
			AddEntry(
				LanguageEntries.FACTIONTYPE_TRADER,
				"Trader"
			);
			AddEntry(
				LanguageEntries.FACTIONTYPE_FARMING,
				"Farming"
			);
			AddEntry(
				LanguageEntries.FACTIONTYPE_LIVESTOCK,
				"Livestock"
			);
			AddEntry(
				LanguageEntries.FACTIONTYPE_MARKET,
				"Market"
			);



	

		}

    }

}
