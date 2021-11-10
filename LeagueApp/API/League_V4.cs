using LeagueApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueApp.API
{
    class League_V4 : Api
    {
        public League_V4(string region) : base(region)
        {
        }
        public List<EntryDTO> GetEntryById(string summonerId)
        {
            string path = "league/v4/entries/by-summoner/" + summonerId;

            var response = GET(GetURL(path));
            string content = response.Content.ReadAsStringAsync().Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<List<EntryDTO>>(content);
            }
            else
            {
                return null;
            }
        }
    }
}
