using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Matt.Mih.Helper
{
    public class SettingsService : ISettingsService
    {
        public XDocument SettingsXml { get; set; }

        private static readonly string xmlFile = "settings.xml";

        public SettingsService()
        {
            if (File.Exists(xmlFile))
            {
                SettingsXml = XDocument.Load(xmlFile);
            }
        }
        
        public Settings Get()
        {
            if(File.Exists(xmlFile))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                XmlReader reader = SettingsXml.CreateReader();
                return (Settings)serializer.Deserialize(reader);
            }
            else
            {
                return new Settings()
                    {
                        ApiKey = "",
                        LeagueFolder = "",
                        Region = "na"
                    };
            }
        }

        public void Save(Settings settings)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));

            StringBuilder stringBuilder = new StringBuilder();

            using(XmlWriter writer = XmlWriter.Create(stringBuilder))
            {
                serializer.Serialize(writer, settings);
            }

            string xmlDoc = stringBuilder.ToString();

            SettingsXml = XDocument.Parse(stringBuilder.ToString());

            SettingsXml.Save(xmlFile);
        }
    }
}
