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
			AddEntry(
				LanguageEntries.CUBEBLOCK_ALCHEMYBENCH_BASIC,
				"Grundlabor"
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_ALCHEMYBENCH,
				"Labor"
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_ALCHEMYBENCH_INDUSTRIAL,
				"Industrielles Labor"
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_ALCHEMYBENCH_DESCRIPTION,
				"Laborblöcke sind dafür verantwortlich, Substanzen und Erze zu kombinieren, " + Environment.NewLine +
				"um Medikamente, Metalllegierungen und Munition herzustellen."
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_GRINDER_BASIC,
				"Grundlegende Mühle"
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_GRINDER,
				"Schleifer"
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_GRINDER_INDUSTRIAL,
				"Industrieller Schleifer"
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_GRINDER_DESCRIPTION,
				"Grinder Blocks sind für den Abbau von Erzen und das Recycling " + Environment.NewLine +
				"von Komponenten verantwortlich."
			);

			#endregion
			#region INGOTS
			AddEntry(
				LanguageEntries.SOIL_NAME,
				"Bodenpulver"
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
				"Feiner, sauberer Sand kann zur Herstellung von Glas verwendet " + Environment.NewLine +
				"werden."
			);
			AddEntry(
				LanguageEntries.CARBON_NAME,
				"Kohlepulver"
			);
			AddEntry(
				LanguageEntries.CARBON_DESCRIPTION,
				"Es kann bei der Herstellung von Metalllegierungen, Munition und " + Environment.NewLine +
				"Komponenten verwendet werden."
			);
			AddEntry(
				LanguageEntries.SILVERPOWDER_NAME,
				"Silberpulver"
			);
			AddEntry(
				LanguageEntries.SILVERPOWDER_DESCRIPTION,
				"Es kann zur Herstellung von Medikamenten und Gesundheitsartikeln " + Environment.NewLine +
				"verwendet werden."
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
				LanguageEntries.ASTEROIDSOIL_NAME,
				"Asteroidenboden"
			);
			AddEntry(
				LanguageEntries.ASTEROIDSOIL_DESCRIPTION,
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
				"Es kann bei der Herstellung von Biokraftstoffen und mit großer " + Environment.NewLine +
				"Anwendung in der Landwirtschaft verwendet werden."
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
			AddEntry(
				LanguageEntries.WOOD_NAME,
				"Holzstamm"
			);
			AddEntry(
				LanguageEntries.WOOD_DESCRIPTION,
				"Es ist eine einfache Energiequelle und der Grundstoff für " + Environment.NewLine +
				"viele andere Ressourcen."
			);
			AddEntry(
				LanguageEntries.TWIG_NAME,
				"Kleiner Zweig"
			);
			AddEntry(
				LanguageEntries.TWIG_DESCRIPTION,
				"Kann verwendet werden, um Sägemehl zu erhalten."
			);
			AddEntry(
				LanguageEntries.SAWDUST_NAME,
				"Sägespäne"
			);
			AddEntry(
				LanguageEntries.SAWDUST_DESCRIPTION,
				"Kann für die Kohlenstoff- und Latexherstellung verwendet " + Environment.NewLine +
				"werden."
			);
			AddEntry(
				LanguageEntries.LEAF_NAME,
				"Blatt"
			);
			AddEntry(
				LanguageEntries.LEAF_DESCRIPTION,
				"Kann verwendet werden, um Bio zu erhalten."
			);
			AddEntry(
				LanguageEntries.BRANCH_NAME,
				"Zweig"
			);
			AddEntry(
				LanguageEntries.BRANCH_DESCRIPTION,
				"Kann verwendet werden, um Sägemehl zu erhalten."
			);
			AddEntry(
				LanguageEntries.SAWDUSTTOCARBONPOWDER_NAME,
				"Kohlepulver aus Sägemehl"
			);
			AddEntry(
				LanguageEntries.LEAFTOORGANIC_NAME,
				"Organisch vom Blatt"
			);
			AddEntry(
				LanguageEntries.BRANCHTOSAWDUST_NAME,
				"Sägemehl vom Zweig"
			);
			AddEntry(
				LanguageEntries.TWIGTOSAWDUST_NAME,
				"Sägemehl von Kleiner Zweig"
			);
			AddEntry(
				LanguageEntries.WOODLOGTOSAWDUST_NAME,
				"Sägemehl aus Holzscheit"
			);
			#endregion
			#region RECIPIENTS
			AddEntry(
				LanguageEntries.FLASK_SMALL_NAME,
				"Kleine Flasche"
			);
			AddEntry(
				LanguageEntries.FLASK_SMALL_DESCRIPTION,
				"Eine kleine Flasche."
			);
			AddEntry(
				LanguageEntries.FLASK_MEDIUM_NAME,
				"Mittlere Flasche"
			);
			AddEntry(
				LanguageEntries.FLASK_MEDIUM_DESCRIPTION,
				"Eine mittlere Flasche."
			);
			AddEntry(
				LanguageEntries.FLASK_BIG_NAME,
				"Große Flasche"
			);
			AddEntry(
				LanguageEntries.FLASK_BIG_DESCRIPTION,
				"Eine große Flasche."
			);
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
			AddEntry(
				LanguageEntries.POLIETILENOGLICOL_NAME,
				"Polietilenoglicol"
			);
			AddEntry(
				LanguageEntries.POLIETILENOGLICOL_DESCRIPTION,
				"Synthetischer Polyether, hydrophil und biokompatibel."
			);
			AddEntry(
				LanguageEntries.SILVERSULFADIAZINE_NAME,
				"Silber Sulfadiazin"
			);
			AddEntry(
				LanguageEntries.SILVERSULFADIAZINE_DESCRIPTION,
				"Verbindung auf Silberbasis für medizinische Zwecke."
			);
			#endregion
		}

	}

}
