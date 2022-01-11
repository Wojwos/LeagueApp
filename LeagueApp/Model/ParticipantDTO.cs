using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueApp.Model
{
    class ParticipantDTO
    {
        public string SummonerName { get; set; }
        public string ChampionName { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Assists { get; set; }
        public bool Win { get; set; }
    }
}
