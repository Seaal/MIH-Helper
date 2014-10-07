using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Matt.Mih.Helper.LeagueApi
{
    public class LeagueApiDAO
    {
        public string ApiKey { get; set; }

        public string Region { get; set; }

        public LeagueApiDAO(string apiKey, string region)
        {
            ApiKey = apiKey;
            Region = region;
        }

        public ChampionDTO GetChampions()
        {
            string json = MakeRequest("static-data/na/v1.2/champion", "na");

            return JsonConvert.DeserializeObject<ChampionDTO>(json);
        }

        public SummonerDTO GetSummoner(string summonerName)
        {
            string json = MakeRequest(Region + "/v1.4/summoner/by-name/" + summonerName, Region);

            Dictionary<string, SummonerDTO> sumDto = JsonConvert.DeserializeObject<Dictionary<string, SummonerDTO>>(json);

            return sumDto.FirstOrDefault().Value;
        }

        public LeagueInfoDTO GetSoloQueueLeagueInfo(int id)
        {
            string json = MakeRequest(Region + "/v2.4/league/by-summoner/" + id + "/entry", Region);
            
            Dictionary<string, List<LeagueInfoDTO>> leagueDto = JsonConvert.DeserializeObject<Dictionary<string, List<LeagueInfoDTO>>>(json);

            return leagueDto.FirstOrDefault().Value.Where(o => o.queue == "RANKED_SOLO_5x5").First();
        }

        public RunepageDTO GetCurrentRunepage(int id)
        {
            string json = MakeRequest(Region + "/v1.4/summoner/" + id + "/runes", Region);

            Dictionary<string, RunepageListDTO> runeDto = JsonConvert.DeserializeObject<Dictionary<string, RunepageListDTO>>(json);

            return runeDto.FirstOrDefault().Value.pages.Where(o => o.current == true).First();
        }

        public RuneListDTO GetRunes()
        {
            string json = MakeRequest("static-data/na/v1.2/rune?runeListData=stats", "na");

            return JsonConvert.DeserializeObject<RuneListDTO>(json);
        }

        private string MakeRequest(string resource, string region)
        {
            string keySeparator = resource.Contains("?") ? "&" : "?";

            String urlRequest = "https://" + region + ".api.pvp.net/api/lol/" + resource + keySeparator + "api_key=" + ApiKey;
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
