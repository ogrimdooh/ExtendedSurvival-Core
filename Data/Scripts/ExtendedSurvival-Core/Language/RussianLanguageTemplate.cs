using System;
using VRage;

namespace ExtendedSurvival.Core
{

    public class RussianLanguageTemplate : BaseLanguageTemplate
    {

        public RussianLanguageTemplate() 
            : base(MyLanguagesEnum.Russian)
        {
        }

        protected override void DoLoadEntries()
        {
			#region GENERALS
			AddEntry(
				LanguageEntries.TERMS_YES_NAME,
				"Да"
			);
			AddEntry(
				LanguageEntries.TERMS_NO_NAME,
				"Нет"
			);
			#endregion
			#region CUBE_BLOCKS
			AddEntry(
				LanguageEntries.CUBEBLOCK_ALCHEMYBENCH_BASIC,
				"Базовая лаборатория"
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_ALCHEMYBENCH,
				"Лаборатория"
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_ALCHEMYBENCH_INDUSTRIAL,
				"Промышленная лаборатория"
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_ALCHEMYBENCH_DESCRIPTION,
				"Блоки лаборатории отвечают за смешивание веществ и " + Environment.NewLine +
				"руд для создания лекарств, металлических сплавов и боеприпасов."
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_GRINDER_BASIC,
				"Базовый измельчитель"
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_GRINDER,
				"Измельчитель"
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_GRINDER_INDUSTRIAL,
				"Промышленный измельчитель"
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_GRINDER_DESCRIPTION,
				"Блоки измельчителя отвечают за разрушение руд и " + Environment.NewLine +
				"переработку компонентов."
			);
			#endregion
			#region INGOTS
			AddEntry(
				LanguageEntries.SOIL_NAME,
				"образец почвы"
			);
			AddEntry(
				LanguageEntries.SOIL_DESCRIPTION,
				"Обработанная почва, идеальная для выращивания растений."
			);
			AddEntry(
				LanguageEntries.SAND_NAME,
				"Песок"
			);
			AddEntry(
				LanguageEntries.SAND_DESCRIPTION,
				"Мелкий, чистый песок, который можно использовать для производства стекла."
			);
			AddEntry(
				LanguageEntries.CARBON_NAME,
				"Угольный порошок"
			);
			AddEntry(
				LanguageEntries.CARBON_DESCRIPTION,
				"Его можно использовать при производстве металлических сплавов, " + Environment.NewLine +
				"боеприпасов и компонентов."
			);
			AddEntry(
				LanguageEntries.SILVERPOWDER_NAME,
				"Серебряный порошок"
			);
			AddEntry(
				LanguageEntries.SILVERPOWDER_DESCRIPTION,
				"Его можно использовать при производстве медицинских и безопасных " + Environment.NewLine +
				"продуктов."
			);
			#endregion
			#region ORES
			AddEntry(
				LanguageEntries.SOIL_ORE_NAME,
				"Почва"
			);
			AddEntry(
				LanguageEntries.SOIL_ORE_DESCRIPTION,
				"Сырая почва, нуждается в обработке для использования."
			);
			AddEntry(
				LanguageEntries.MUD_ORE_NAME,
				"Грязь"
			);
			AddEntry(
				LanguageEntries.MUD_ORE_DESCRIPTION,
				"Мягкую, влажную почву перед использованием необходимо обработать."
			);
			AddEntry(
				LanguageEntries.ALIENSOIL_NAME,
				"Инопланетная Почва"
			);
			AddEntry(
				LanguageEntries.ALIENSOIL_DESCRIPTION,
				"Сырая почва, нуждается в обработке для использования."
			);
			AddEntry(
				LanguageEntries.ASTEROIDSOIL_NAME,
				"Астероидная Почва"
			);
			AddEntry(
				LanguageEntries.ASTEROIDSOIL_DESCRIPTION,
				"Сырая почва, нуждается в обработке для использования."
			);
			AddEntry(
				LanguageEntries.DESERTSOIL_NAME,
				"Пустынная Почва"
			);
			AddEntry(
				LanguageEntries.DESERTSOIL_DESCRIPTION,
				"Сырая почва, нуждается в обработке для использования."
			);
			AddEntry(
				LanguageEntries.MOONSOIL_NAME,
				"Лунная Почва"
			);
			AddEntry(
				LanguageEntries.MOONSOIL_DESCRIPTION,
				"Сырая почва, нуждается в обработке для использования."
			);
			AddEntry(
				LanguageEntries.ORGANIC_NAME,
				"Органика"
			);
			AddEntry(
				LanguageEntries.ORGANIC_DESCRIPTION,
				"Её можно использовать для производства биотоплива и " + Environment.NewLine +
				"с большим применением в сельском хозяйстве."
			);
			AddEntry(
				LanguageEntries.ICE_NAME,
				"Лёд"
			);
			AddEntry(
				LanguageEntries.ICE_DESCRIPTION,
				"Лёд - это замороженная вода в твердом состоянии."
			);
			AddEntry(
				LanguageEntries.STONEICE_NAME,
				"Замёрзшая Земля"
			);
			AddEntry(
				LanguageEntries.STONEICE_DESCRIPTION,
				"Почва с приличным содержанием льда."
			);
			AddEntry(
				LanguageEntries.TOXICICE_NAME,
				"Токсичный Лёд"
			);
			AddEntry(
				LanguageEntries.TOXICICE_DESCRIPTION,
				"Лёд, загрязнённый органическими веществами."
			);
			AddEntry(
				LanguageEntries.WOOD_NAME,
				"Деревянный Пень"
			);
			AddEntry(
				LanguageEntries.WOOD_DESCRIPTION,
				"Это простой источник энергии и базовый материал " + Environment.NewLine +
				"для многих других ресурсов."
			);
			AddEntry(
				LanguageEntries.TWIG_NAME,
				"Веточка"
			);
			AddEntry(
				LanguageEntries.TWIG_DESCRIPTION,
				"Может использоваться для получения опилок."
			);
			AddEntry(
				LanguageEntries.SAWDUST_NAME,
				"Опилки"
			);
			AddEntry(
				LanguageEntries.SAWDUST_DESCRIPTION,
				"Может использоваться для производства угля и латекса."
			);
			AddEntry(
				LanguageEntries.LEAF_NAME,
				"Лист"
			);
			AddEntry(
				LanguageEntries.LEAF_DESCRIPTION,
				"Может использоваться для получения органики."
			);
			AddEntry(
				LanguageEntries.BRANCH_NAME,
				"Ветвь"
			);
			AddEntry(
				LanguageEntries.BRANCH_DESCRIPTION,
				"Может использоваться для получения опилок."
			);
			AddEntry(
				LanguageEntries.SAWDUSTTOCARBONPOWDER_NAME,
				"Угольный Порошок из Опилок"
			);
			AddEntry(
				LanguageEntries.LEAFTOORGANIC_NAME,
				"Органика из Листьев"
			);
			AddEntry(
				LanguageEntries.BRANCHTOSAWDUST_NAME,
				"Опилки из Ветвей"
			);
			AddEntry(
				LanguageEntries.TWIGTOSAWDUST_NAME,
				"Опилки из Веточек"
			);
			AddEntry(
				LanguageEntries.WOODLOGTOSAWDUST_NAME,
				"Опилки из бревен"
			);
			#endregion
			#region RECIPIENTS
			AddEntry(
				LanguageEntries.FLASK_SMALL_NAME,
				"Маленькая Фляжка"
			);
			AddEntry(
				LanguageEntries.FLASK_SMALL_DESCRIPTION,
				"Маленькая фляжка."
			);
			AddEntry(
				LanguageEntries.FLASK_MEDIUM_NAME,
				"Средняя Фляжка"
			);
			AddEntry(
				LanguageEntries.FLASK_MEDIUM_DESCRIPTION,
				"Средняя фляжка."
			);
			AddEntry(
				LanguageEntries.FLASK_BIG_NAME,
				"Большая Фляжка"
			);
			AddEntry(
				LanguageEntries.FLASK_BIG_DESCRIPTION,
				"Большая фляжка."
			);
			AddEntry(
				LanguageEntries.WATER_FLASK_SMALL_NAME,
				"Маленькая Фляжка с Водой"
			);
			AddEntry(
				LanguageEntries.WATER_FLASK_SMALL_DESCRIPTION,
				"Маленькая фляжка с водой."
			);
			AddEntry(
				LanguageEntries.WATER_FLASK_MEDIUM_NAME,
				"Средняя Фляжка с Водой"
			);
			AddEntry(
				LanguageEntries.WATER_FLASK_MEDIUM_DESCRIPTION,
				"Средняя фляжка с водой."
			);
			AddEntry(
				LanguageEntries.WATER_FLASK_BIG_NAME,
				"Большая Фляжка с Водой"
			);
			AddEntry(
				LanguageEntries.WATER_FLASK_BIG_DESCRIPTION,
				"Большая фляжка с водой."
			);
			AddEntry(
				LanguageEntries.POLIETILENOGLICOL_NAME,
				"Полиэтиленгликоль"
			);
			AddEntry(
				LanguageEntries.POLIETILENOGLICOL_DESCRIPTION,
				"Синтетический полиэфир, гидрофильный и биосовместимый."
			);
			AddEntry(
				LanguageEntries.SILVERSULFADIAZINE_NAME,
				"Серебро Сульфадиазин"
			);
			AddEntry(
				LanguageEntries.SILVERSULFADIAZINE_DESCRIPTION,
				"Препарат на основе серебра для медицинского использования."
			);
			#endregion

		}

	}

}
