﻿using System;
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
