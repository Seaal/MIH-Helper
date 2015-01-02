using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;
namespace Seaal.Mih.Helper
{
    public interface INameService
    {
        void Add(string name);
        AutoCompleteStringCollection Names { get; set; }
        XDocument NamesXml { get; set; }
    }
}
