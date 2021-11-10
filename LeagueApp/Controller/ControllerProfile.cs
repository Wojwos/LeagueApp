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
        public object GetContext(SummonerDTO summoner)
        {
            var entry = GetEntry(summoner);
            return null;
        }

        private EntryDTO GetEntry(SummonerDTO summoner)
        {
            League_V4 league = new League_V4(Constans.Region);
            var entry = league.GetEntryById(summoner.id).Where(p => p.QueueType.Equals("RANKED_SOLO_5x5")).FirstOrDefault();
            return entry ?? new EntryDTO();
        }
    }
}
