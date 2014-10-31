using System;
using System.Xml.Linq;
namespace Matt.Mih.Helper
{
    public interface ISettingsService
    {
        Settings Get();
        void Save(Settings settings);
        XDocument SettingsXml { get; set; }
    }
}
