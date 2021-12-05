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
        private ControllerMain controller;
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand SearchPlayerCommand { get; set; }
        public MainWindowViewModel()
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
            controller = new ControllerMain();
            if (controller.GetSummoner(Region, SearchedSummonerName))
            {
                Constans.Name = searchedSummonerName;
                Constans.Region = region;
                SummonerName = searchedSummonerName;
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
    }
}
