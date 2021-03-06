﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Seaal.Mih.Helper
{
    [XmlRoot("Settings")]
    public class Settings
    {
        [XmlElement("ApiKey")]
        public string ApiKey { get; set; }

        [XmlElement("LeagueFolder")]
        public string LeagueFolder { get; set; }

        [XmlElement("Region")]
        public string Region { get; set; }
    }
}
