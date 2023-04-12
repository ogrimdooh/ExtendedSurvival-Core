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

			#endregion
			#region INGOTS
			AddEntry(
				LanguageEntries.SOIL_NAME,
				"Soil"
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
				"It can be used in the manufacture of metal alloys, ammunition and components."
			);
			AddEntry(
				LanguageEntries.SILVERPOWDER_NAME,
				"Silver Powder"
			);
			AddEntry(
				LanguageEntries.SILVERPOWDER_DESCRIPTION,
				"It can be used in manufacturing medicine and health items."
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
				"It can be used in the manufacture of biofuels and with great application in agriculture."
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
		}

	}

}
