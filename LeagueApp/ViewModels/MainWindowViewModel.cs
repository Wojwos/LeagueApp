using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using LeagueApp.Commands;
using System.Windows;
using System.Windows.Input;
using LeagueApp.Utils;
using LeagueApp.Controller;

namespace LeagueApp.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private ControllerProfile controllerProfile;
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand SearchPlayerCommand { get; set; }
        public MainWindowViewModel()
        {
            controllerProfile = new ControllerProfile();
            SearchPlayerCommand = new RelayCommand(SearchPlayer);
        }
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void SearchPlayer(Object obj)
        {
            controllerProfile = new ControllerProfile();
            if (controllerProfile.SummonerExists(Region, SearchedSummonerName))
            {
                var summoner = controllerProfile.GetContext(Region, searchedSummonerName);
                SummonerIconId = summoner.Item1;
                SummonerName = summoner.Item2;
                SummonerId = summoner.Item3;
                SummonerLevel = summoner.Item4;
                Constans.Name = SummonerName;
                Constans.Region = region;
                Constans.Level = SummonerLevel;
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

        private int summonerIconId;
        public int SummonerIconId
        {
            get { return summonerIconId; }
            set
            {
                summonerIconId = value;
                OnPropertyChanged();
            }
        }

        private string summonerId;
        public string SummonerId
        {
            get { return summonerId; }
            set
            {
                summonerId = value;
                OnPropertyChanged();
            }
        }

        private long summonerLevel;
        public long SummonerLevel
        {
            get { return summonerLevel; }
            set
            {
                summonerLevel = value;
                OnPropertyChanged();
            }
        }
    }
}
