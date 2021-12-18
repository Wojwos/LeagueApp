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
using LeagueApp.Utils;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace LeagueApp.ViewModels
{
    class AccountStatsViewModel : INotifyPropertyChanged
    {
        private ControllerMain controller;
        public event PropertyChangedEventHandler PropertyChanged;
        public AccountStatsViewModel()
        {
            controller = new ControllerMain();
            SummonerName = Constans.Name;
            Region = Constans.Region;
            GetPlayerInfo();
            CreateWinLoseChart();
        }
        public SeriesCollection Series { get; set; }
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void GetPlayerInfo()
        {
            if(SummonerName != null && Region != null)
            {
                if (controller.GetSummoner(Region, SummonerName))
                {
                    var entry = controller.GetContext(Region, controller.GetSummonerId(Region, SummonerName));
                    SummonerTier = entry.Item1;
                    SummonerRank = entry.Item2;
                    SummonerWins = entry.Item3.ToString();
                    SummonerLosses = entry.Item4.ToString();
                }
                else
                    SummonerName = "Doesn't exist";
            }
        }

        private void CreateWinLoseChart()
        {
            Series = new SeriesCollection
            {
                new PieSeries
                {
                    Title ="Wins",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(10) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title ="Loses",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(20) },
                    DataLabels = true
                }
            };
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
