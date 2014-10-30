using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;
namespace Matt.Mih.Helper
{
    public interface INameManager
    {
        void Add(string name);
        AutoCompleteStringCollection Names { get; set; }
        XDocument NamesXml { get; set; }
    }
}
