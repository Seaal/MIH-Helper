using System;
using System.Xml.Linq;
namespace Matt.Mih.Helper
{
    interface ISettingsManager
    {
        Settings Get();
        void Save(Settings settings);
        XDocument SettingsXml { get; set; }
    }
}
