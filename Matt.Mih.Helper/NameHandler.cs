using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Matt.Mih.Helper
{
    public class NameHandler
    {
        public XDocument NamesXml { get; set; }

        public AutoCompleteStringCollection AutoCompleteNames { get; set; }

        private static readonly string xmlFile = "names.xml";

        public NameHandler()
        {
            AutoCompleteNames = new AutoCompleteStringCollection();

            if(File.Exists(xmlFile))
            {
                NamesXml = XDocument.Load(xmlFile);

                String[] names = (from name in NamesXml.Descendants("Name")
                                  select (string)name).ToArray();

                AutoCompleteNames.AddRange(names);
            }
            else
            {
                NamesXml = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("SummonerNames"));
                NamesXml.Save(xmlFile);
            }
        }

        public void Add(string name)
        {
            if (!NamesXml.Descendants("Name").Where(x => x.Value == name).Any())
            {
                XElement newName = new XElement("Name");

                newName.Add(name);

                NamesXml.Element("SummonerNames").Add(newName);

                AutoCompleteNames.Add(name);

                NamesXml.Save(xmlFile);
            }
        }
    }
}
