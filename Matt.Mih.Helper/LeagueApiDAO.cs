using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Matt.Mih.Helper
{
    class LeagueApiDAO
    {
        static readonly string API_KEY = "63965c03-965b-4cfb-bb3e-e8b0a0601bd1";

        public ChampionDTO GetChampions()
        {
            string json = MakeRequest("static-data/na/v1.2/champion");

            return JsonConvert.DeserializeObject<ChampionDTO>(json);
        }

        public Summoner GetSummoner(string summonerName)
        {
            string json = MakeRequest("na/v1.4/summoner/by-name/"+summonerName);

            Dictionary<string, Summoner> sumDto = JsonConvert.DeserializeObject<Dictionary<string, Summoner>>(json);

            return sumDto.FirstOrDefault().Value;
        }

        public LeagueInfo GetLeagueInfo(int id)
        {
            string json = MakeRequest("na/v2.4/league/by-summoner/" + id + "/entry");
            
            Dictionary<string, List<LeagueInfo>> leagueDto = JsonConvert.DeserializeObject<Dictionary<string, List<LeagueInfo>>>(json);

            return leagueDto.FirstOrDefault().Value.FirstOrDefault();
        }

        public Runepage GetCurrentRunepage(int id)
        {
            string json = MakeRequest("na/v1.4/summoner/" + id + "/runes");

            Dictionary<string, RunepageDTO> runeDto = JsonConvert.DeserializeObject<Dictionary<string, RunepageDTO>>(json);

            foreach(Runepage page in runeDto.FirstOrDefault().Value.pages)
            {
                if(page.current)
                {
                    return page;
                }
            }

            return null;
        }

        private string MakeRequest(string resource)
        {
            String urlRequest = "https://na.api.pvp.net/api/lol/" + resource + "?api_key=" + API_KEY;
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(urlRequest);
            Stream response = null;

            // Sends the HttpWebRequest and waits for the response.
            HttpWebResponse myHttpWebResponse = myReq.GetResponse() as HttpWebResponse;
            try
            {
                response = myHttpWebResponse.GetResponseStream();
                StreamReader readStream = new StreamReader(response, System.Text.Encoding.GetEncoding("utf-8"));
                return readStream.ReadToEnd();
            }
            finally
            {
                // Releases the resources of the response.
                response.Dispose();
                myHttpWebResponse.Close();
            }
        }
    }
}
