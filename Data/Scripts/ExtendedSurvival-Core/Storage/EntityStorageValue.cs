﻿using ProtoBuf;
using System.Xml.Serialization;

namespace ExtendedSurvival.Core
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class EntityStorageValue
    {

        [XmlElement]
        public string Key { get; set; }

        [XmlElement]
        public string Value { get; set; }

    }

}
