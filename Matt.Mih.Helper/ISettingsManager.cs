using System;
using System.Xml.Linq;
namespace Matt.Mih.Helper
{
    public interface ISettingsManager
    {
        Settings Get();
        void Save(Settings settings);
        XDocument SettingsXml { get; set; }
    }
}
