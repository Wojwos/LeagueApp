using LeagueApp.API;
using LeagueApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueApp.Controller
{
    class ControllerMatches
    {
        public string GetSummonerPuuid(string region, string summonerName)
        {
            Summoner_V4 summoner_V4 = new Summoner_V4(region);
            var summoner = summoner_V4.GetSummonerByName(summonerName);
            return summoner.Puuid;
        }
        public (string, string, int, int, int, bool) GetContext(string region, string matchId, string summonerName)
        {
            if(region == "EUW1" || region == "EUN1")
            {
                region = "EUROPE";
            }
            MatchDTO match = GetMatch(region, matchId, summonerName);
            ParticipantDTO participantMatch =  match.Info.Participants.Where(p => p.SummonerName.Equals(summonerName)).FirstOrDefault();
            return (participantMatch.SummonerName, participantMatch.ChampionName, participantMatch.Kills, participantMatch.Deaths, participantMatch.Assists, participantMatch.Win);
        }
        public List<string> GetMatchesId(string region, string summonerPuuid)
        {
            if (region == "EUW1" || region == "EUN1")
            {
                region = "EUROPE";
            }
            Match_V5 match_v5 = new Match_V5(region);
            return match_v5.GetMatchesIdByPuuid(summonerPuuid);
        }
        private MatchDTO GetMatch(string region, string matchId, string summonerName)
        {
            Match_V5 match_v5 = new Match_V5(region);
            var match = match_v5.GetMatchById(matchId);
            return match ?? new MatchDTO();
        }
    }
}
