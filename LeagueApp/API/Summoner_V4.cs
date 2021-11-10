using LeagueApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LeagueApp.API
{
    class Summoner_V4 : Api
    {
        public Summoner_V4(string region) : base(region)
        {
        }
        public SummonerDTO GetSummonerByName(string summonerName)
        {
            string path = "summoner/v4/summoners/by-name/" + summonerName;

            var response = GET(GetURL(path));
            string content = response.Content.ReadAsStringAsync().Result;
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<SummonerDTO>(content);
            }
            else
            {
                return null;
            }
        }
    }
}
