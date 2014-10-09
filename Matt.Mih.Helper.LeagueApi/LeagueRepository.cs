﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Matt.Mih.Helper.LeagueApi
{
    public class LeagueRepository : ILeagueRepository
    {
        private readonly LeagueApiDAO dao;

        private List<Summoner> summonerCache;
        private List<Champion> championCache;
        private List<Rune> runeCache;

        public string ApiKey
        {
            set
            {
                dao.ApiKey = value;
            }
        }

        public string Region
        {
            set
            {
                dao.Region = value;
            }
        }

        public LeagueRepository(string apiKey, string region)
        {
            dao = new LeagueApiDAO(apiKey, region);
            summonerCache = new List<Summoner>();
        }


        public List<Champion> GetChampions()
        {
            if(championCache == null)
            {
                championCache = dao.GetChampions().data.Values.ToList();
            }

            return championCache;
        }

        public List<Rune> GetRunes()
        {
            if(runeCache == null)
            {
                RuneListDTO runeListDto = dao.GetRunes();

                runeCache = new List<Rune>(runeListDto.data.Count);

                foreach (RuneDTO dto in runeListDto.data.Values)
                {
                    runeCache.Add(new Rune(dto));
                }
            }
            
            return runeCache;
        }

        public Runepage GetCurrentRunepage(int summonerId)
        {
            Summoner seaal = GetSummoner("Seaal");
            RunepageDTO runepageDto = dao.GetCurrentRunepage(seaal.Id);

            List<Rune> runesUsed = new List<Rune>(30);

            foreach(RuneSlotDTO slot in runepageDto.slots)
            {
                runesUsed.Add(getRuneFromSlot(slot));
            }

            return new Runepage(runepageDto, runesUsed);
        }

        private Rune getRuneFromSlot(RuneSlotDTO slot)
        {
            return GetRunes().Where(o => o.Id == slot.runeId).First();
        }

        public Summoner GetSummoner(string summonerName)
        {
            Summoner summonerFromCache = summonerCache.FirstOrDefault(o => o.Name == summonerName);

            if(summonerFromCache != null)
            {
                return summonerFromCache;
            }

            SummonerDTO summonerDto = dao.GetSummoner(summonerName);

            try
            {
                LeagueInfoDTO leagueDto = dao.GetSoloQueueLeagueInfo(summonerDto.id);

                return new Summoner(summonerDto, leagueDto);
            }
            catch (WebException exception)
            {
                if (exception.Status == WebExceptionStatus.ProtocolError && ((HttpWebResponse)exception.Response).StatusCode == HttpStatusCode.NotFound)
                {
                    return new Summoner(summonerDto);
                }
                else
                {
                    throw;
                }
            }
            catch (InvalidOperationException)
            {
                return new Summoner(summonerDto);
            }
        }
    }
}
