using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueApp.API;
using LeagueApp.Model;
using LeagueApp.Utils;
using LeagueApp.ViewModels;

namespace LeagueApp.Controller
{
    class ControllerProfile
    {
        public bool SummonerExists(string region, string summonerName)
        {
            Summoner_V4 summoner_V4 = new Summoner_V4(region);

            var summoner = summoner_V4.GetSummonerByName(summonerName);

            return summoner != null;
        }
        public (int, string, string, long) GetContext(string region, string summonerName)
        {
            var summoner = GetSummoner(region, summonerName);
            return (summoner.ProfileIconId, summoner.Name, summoner.Id, summoner.SummonerLevel);
        }

        private SummonerDTO GetSummoner(string region, string summonerName)
        {
            Summoner_V4 summoner_v4 = new Summoner_V4(region);
            var summoner = summoner_v4.GetSummonerByName(summonerName);
            return summoner ?? new SummonerDTO();
        }
    }
}
