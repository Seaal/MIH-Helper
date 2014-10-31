using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matt.Mih.Helper
{
    public class IconPathService : IIconPathService
    {
        private readonly string CHAMP_IMAGES_LOCATION_PRE_RELEASES = @"\RADS\projects\lol_air_client\releases\";
        private readonly string CHAMP_IMAGES_LOCATION_POST_RELEASES = @"\deploy\assets\images\champions\";
        private readonly string CHAMP_IMAGES_SUFFIX = "_Square_0.png";

        public string GetIconPath(string champion, string leagueFolder)
        {
            return GetReleaseDirectory(leagueFolder) + CHAMP_IMAGES_LOCATION_POST_RELEASES + champion + CHAMP_IMAGES_SUFFIX;
        }

        public bool IsValidIconPath(string leagueFolder)
        {
            try
            {
                if(Directory.Exists(GetReleaseDirectory(leagueFolder) + CHAMP_IMAGES_LOCATION_POST_RELEASES))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(DirectoryNotFoundException)
            {
                return false;
            }
        }

        private string GetReleaseDirectory(string leagueFolder)
        {
            List<string> folders = Directory.GetDirectories(leagueFolder + CHAMP_IMAGES_LOCATION_PRE_RELEASES).ToList();

            string pattern = "\\d+.\\d+.\\d+.\\d+";

            foreach(string folder in folders)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(folder.Remove(0, leagueFolder.Length + CHAMP_IMAGES_LOCATION_PRE_RELEASES.Length), pattern))
                {
                    return folder;
                }
            }

            throw new DirectoryNotFoundException("Releases Directory Not Found");
        }
    }

    
}
