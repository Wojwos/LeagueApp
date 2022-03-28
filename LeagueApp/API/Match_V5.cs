using LeagueApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueApp.API
{
    class Match_V5: Api
    {
        public Match_V5(string region) : base(region)
        {
        }
        public List<MatchDTO> GetMatchListById(List<string> matchIdList)
        {
            List<string> urlList = new List<string>();
            foreach(var matchId in matchIdList)
            {
                urlList.Add(GetURL("match/v5/matches/" + matchId));
            }

            var responseList = GET(urlList);
            List<MatchDTO> matchList = new List<MatchDTO>();
            foreach (var response in responseList)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    matchList.Add(JsonConvert.DeserializeObject<MatchDTO>(content));
                }
            }
            return matchList;
        }
        public List<string> GetMatchesIdByPuuid(string summonerPuuid)
        {
            string path = "match/v5/matches/by-puuid/" + summonerPuuid + "/ids";

            var response = GET(GetURL(path));
            string content = response.Content.ReadAsStringAsync().Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<List<string>>(content);
            }
            else
            {
                return null;
            }
        }
    }
}
