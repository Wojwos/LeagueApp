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
        public List<(string, string, int, int, int, bool)> GetContext(string region, string summonerName, string summonerPuuid)
        {
            if(region == "EUW1" || region == "EUN1")
            {
                region = "EUROPE";
            }
            List<MatchDTO> matchList = GetMatchList(region, GetMatchesId(region, summonerPuuid), summonerName);
            var contextList = new List<(string, string, int, int, int, bool)>();
            foreach (var match in matchList)
            {
                ParticipantDTO participantMatch = match.Info.Participants.Where(p => p.SummonerName.Equals(summonerName)).FirstOrDefault();
                contextList.Add((participantMatch.SummonerName, participantMatch.ChampionName, participantMatch.Kills, participantMatch.Deaths, participantMatch.Assists, participantMatch.Win));
            }
            return contextList;
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
        private List<MatchDTO> GetMatchList(string region, List<string> matchId, string summonerName)
        {
            Match_V5 match_v5 = new Match_V5(region);
            var match = match_v5.GetMatchListById(matchId);
            return match ?? new List<MatchDTO>();
        }
    }
}
