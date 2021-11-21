using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LeagueApp.API;
using LeagueApp.Commands;
using LeagueApp.Controller;
using LeagueApp.Model;

namespace LeagueApp.ViewModels
{
    class AccountStatsViewModel : INotifyPropertyChanged
    {
        private ControllerMain controller;
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand SearchPlayerCommand { get; set; }
        public AccountStatsViewModel()
        {
            controller = new ControllerMain();
            SearchPlayerCommand = new RelayCommand(SearchPlayer);
        }
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void SearchPlayer(Object obj)
        {
            if (controller.GetSummoner(Region, SearchedSummonerName))
            {
                SummonerName = searchedSummonerName;
                var entry = controller.GetContext(Region, controller.GetSummonerId(Region, SearchedSummonerName));
                SummonerTier = entry.Item1;
                SummonerRank = entry.Item2;
                SummonerWins = entry.Item3.ToString();
                SummonerLosses = entry.Item4.ToString();
            }
            else
                SummonerName = "Doesn't exist";
        }

        private string region;
        public string Region
        {
            get { return region; }
            set
            {
                region = value;
                OnPropertyChanged();
            }
        }

        private string searchedSummonerName;
        public string SearchedSummonerName
        {
            get { return searchedSummonerName; }
            set
            {
                searchedSummonerName = value;
                OnPropertyChanged();
            }
        }

        private string summonerName;
        public string SummonerName
        {
            get { return summonerName; }
            set
            {
                summonerName = value;
                OnPropertyChanged();
            }
        }

        private string summonerTier;
        public string SummonerTier
        {
            get { return summonerTier; }
            set
            {
                summonerTier = value;
                OnPropertyChanged();
            }
        }

        private string summonerRank;
        public string SummonerRank
        {
            get { return summonerRank; }
            set
            {
                summonerRank = value;
                OnPropertyChanged();
            }
        }
        private string summonerWins;
        public string SummonerWins
        {
            get { return summonerWins; }
            set
            {
                summonerWins = value;
                OnPropertyChanged();
            }
        }

        private string summonerLosses;
        public string SummonerLosses
        {
            get { return summonerLosses; }
            set
            {
                summonerLosses = value;
                OnPropertyChanged();
            }
        }

        private string summonerWinRatio;
        public string SummonerWinRatio
        {
            get { return summonerWinRatio; }
            set
            {
                summonerWinRatio = value;
                OnPropertyChanged();
            }
        }
    }
}
