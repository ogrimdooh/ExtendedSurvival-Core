using System;
using VRage;

namespace ExtendedSurvival.Core
{

    public class GermanLanguageTemplate : BaseLanguageTemplate
    {

        public GermanLanguageTemplate() 
            : base(MyLanguagesEnum.German)
        {
        }

        protected override void DoLoadEntries()
        {
			#region GENERALS
			AddEntry(
				LanguageEntries.TERMS_YES_NAME,
				"Ja"
			);
			AddEntry(
				LanguageEntries.TERMS_NO_NAME,
				"Nein"
			);
			#endregion
			#region CUBE_BLOCKS

			#endregion
			#region INGOTS
			AddEntry(
				LanguageEntries.SOIL_NAME,
				"Boden"
			);
			AddEntry(
				LanguageEntries.SOIL_DESCRIPTION,
				"Verarbeitete Erde, ideal für den Anbau von Pflanzen."
			);
			AddEntry(
				LanguageEntries.SAND_NAME,
				"Sand"
			);
			AddEntry(
				LanguageEntries.SAND_DESCRIPTION,
				"Feiner, sauberer Sand kann zur Herstellung von Glas verwendet werden."
			);
			AddEntry(
				LanguageEntries.CARBON_NAME,
				"Kohlepulver"
			);
			AddEntry(
				LanguageEntries.CARBON_DESCRIPTION,
				"Es kann bei der Herstellung von Metalllegierungen, Munition und Komponenten verwendet werden."
			);
			AddEntry(
				LanguageEntries.SILVERPOWDER_NAME,
				"Silberpulver"
			);
			AddEntry(
				LanguageEntries.SILVERPOWDER_DESCRIPTION,
				"Es kann zur Herstellung von Medikamenten und Gesundheitsartikeln verwendet werden."
			);
			#endregion
			#region ORES
			AddEntry(
				LanguageEntries.SOIL_ORE_NAME,
				"Boden"
			);
			AddEntry(
				LanguageEntries.SOIL_ORE_DESCRIPTION,
				"Roherde, muss verarbeitet werden, um verwendet zu werden."
			);
			AddEntry(
				LanguageEntries.ALIENSOIL_NAME,
				"Fremder Boden"
			);
			AddEntry(
				LanguageEntries.ALIENSOIL_DESCRIPTION,
				"Roherde, muss verarbeitet werden, um verwendet zu werden."
			);
			AddEntry(
				LanguageEntries.DESERTSOIL_NAME,
				"Wüstenboden"
			);
			AddEntry(
				LanguageEntries.DESERTSOIL_DESCRIPTION,
				"Roherde, muss verarbeitet werden, um verwendet zu werden."
			);
			AddEntry(
				LanguageEntries.MOONSOIL_NAME,
				"Mondboden"
			);
			AddEntry(
				LanguageEntries.MOONSOIL_DESCRIPTION,
				"Roherde, muss verarbeitet werden, um verwendet zu werden."
			);
			AddEntry(
				LanguageEntries.ORGANIC_NAME,
				"Organisch"
			);
			AddEntry(
				LanguageEntries.ORGANIC_DESCRIPTION,
				"Es kann bei der Herstellung von Biokraftstoffen und mit großer Anwendung in der Landwirtschaft verwendet werden."
			);
			AddEntry(
				LanguageEntries.ICE_NAME,
				"Eis"
			);
			AddEntry(
				LanguageEntries.ICE_DESCRIPTION,
				"Eis ist in einen festen Zustand gefrorenes Wasser."
			);
			AddEntry(
				LanguageEntries.STONEICE_NAME,
				"Schmutziges Eis"
			);
			AddEntry(
				LanguageEntries.STONEICE_DESCRIPTION,
				"Boden mit einer angemessenen Eiskonzentration."
			);
			AddEntry(
				LanguageEntries.TOXICICE_NAME,
				"Giftiges Eis"
			);
			AddEntry(
				LanguageEntries.TOXICICE_DESCRIPTION,
				"Mit organischen Stoffen kontaminiertes Eis."
			);
			#endregion
			#region RECIPIENTS
			AddEntry(
				LanguageEntries.WATER_FLASK_SMALL_NAME,
				"Kleine Wasserflasche"
			);
			AddEntry(
				LanguageEntries.WATER_FLASK_SMALL_DESCRIPTION,
				"Eine kleine Flasche mit Wasser."
			);
			AddEntry(
				LanguageEntries.WATER_FLASK_MEDIUM_NAME,
				"Mittlere Wasserflasche"
			);
			AddEntry(
				LanguageEntries.WATER_FLASK_MEDIUM_DESCRIPTION,
				"Eine mittlere Flasche mit Wasser."
			);
			AddEntry(
				LanguageEntries.WATER_FLASK_BIG_NAME,
				"Große Wasserflasche"
			);
			AddEntry(
				LanguageEntries.WATER_FLASK_BIG_DESCRIPTION,
				"Eine große Flasche mit Wasser."
			);
			#endregion
		}

	}

}
