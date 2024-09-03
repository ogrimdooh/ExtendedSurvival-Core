using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class CreatureCombatSetting
    {

        [XmlElement]
        public float CreatureInhibitorArea { get; set; } = 100;

        [XmlElement]
        public bool DisableDampingAroundCreatures { get; set; } = true;

        [XmlElement]
        public bool DisableThrustsAroundCreatures { get; set; } = true;

        public bool HasInhibitorEnabled()
        {
            return (DisableDampingAroundCreatures || DisableThrustsAroundCreatures) && CreatureInhibitorArea > 0;
        }

        public float GetInhibitorArea()
        {
            return Math.Min(200, Math.Max(0, CreatureInhibitorArea));
        }

    }

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class HuntingSetting
    {

        [XmlElement]
        public float MinDistanceFromLargeOrShipGrids { get; set; } = 7500;

        [XmlElement]
        public float RoverThreatLevelCheckRange { get; set; } = 2500;

        [XmlElement]
        public float MaxRegionThreatLevelByPlayer { get; set; } = 200;

        [XmlElement]
        public float MaxPlayerAltitudeToSpawn { get; set; } = 10;

        [XmlElement]
        public DocumentedVector2 HuntCycleCountDownMinutes { get; set; } = new DocumentedVector2(1, 5);

        [XmlElement]
        public float HuntCycleSpawnChance { get; set; } = 0.75f;

        [XmlElement]
        public float HuntCycleAgressiveCreatureChance { get; set; } = 0.5f;

        [XmlElement]
        public DocumentedVector2 SpawnCreatureAmount { get; set; } = new DocumentedVector2(1, 4);

        [XmlElement]
        public DocumentedVector2 SpawnCreatureDistance { get; set; } = new DocumentedVector2(100, 250);

        [XmlElement]
        public float CreatureHuntRegionCheckRange { get; set; } = 2500;

        [XmlElement]
        public float MaxCreaturesInHuntRegion { get; set; } = 6;

        [XmlElement]
        public CreatureCombatSetting CreatureCombat { get; set; } = new CreatureCombatSetting();

        [XmlArray("Animals"), XmlArrayItem("Animal", typeof(ValidHuntAnimalSetting))]
        public List<ValidHuntAnimalSetting> Animals { get; set; } = new List<ValidHuntAnimalSetting>();

    }

}
