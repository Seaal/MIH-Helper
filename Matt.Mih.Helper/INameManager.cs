using System;
using System.Windows.Forms;
using System.Xml.Linq;
namespace Matt.Mih.Helper
{
    public interface INameManager
    {
        void Add(string name);
        AutoCompleteStringCollection AutoCompleteNames { get; set; }
        XDocument NamesXml { get; set; }
    }
}
