using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueApp.API;
using LeagueApp.Model;
using LeagueApp.Utils;

namespace LeagueApp.Controller
{
    public class ControllerMain
    {
        public bool GetSummoner(string region, string summonerName)
        {
            Summoner_V4 summoner_V4 = new Summoner_V4(region);

            var summoner = summoner_V4.GetSummonerByName(summonerName);

            return summoner != null;
        }
        public string GetSummonerId(string region, string summonerName)
        {
            Summoner_V4 summoner_V4 = new Summoner_V4(region);
            var summoner = summoner_V4.GetSummonerByName(summonerName);
            return summoner.Id;
        }
        public (string, string, int, int) GetContext(string region, string summonerId)
        {
            var entry = GetEntry(region, summonerId);
            return (entry.Tier, entry.Rank, entry.Wins, entry.Losses);
        }
        private EntryDTO GetEntry(string region, string summonerId)
        {
            League_V4 league = new League_V4(region);
            var entry = league.GetEntryById(summonerId).Where(p => p.QueueType.Equals("RANKED_SOLO_5x5")).FirstOrDefault();
            return entry ?? new EntryDTO();
        }
    }
}
