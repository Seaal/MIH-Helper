using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;
namespace Matt.Mih.Helper
{
    public interface INameManager
    {
        void Add(string name);
        List<String> Names { get; set; }
        XDocument NamesXml { get; set; }
    }
}
