using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
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
    class MatchInfo
    {
        public string SummonerName { get; set; }
        public string ChampionName { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Assists { get; set; }
        public bool Win { get; set; }
        public Brush Background => Win ? Brushes.LightGreen : Brushes.Pink;
    }
    class AccountStatsViewModel : ViewModelBase
    {
        private ControllerMain controller;
        private ControllerMatches controllerMatches;
        public AccountStatsViewModel(string name, string region)
        {
            controller = new ControllerMain();
            controllerMatches = new ControllerMatches();
            SummonerName = name;
            Region = region;
            GetPlayerInfo();
            CreateWinLoseChart();
            CreateChampionsChart();
            GetMatchInfo();
        }

        private void GetMatchInfo()
        {
            ObservableCollection<MatchInfo> items = new ObservableCollection<MatchInfo>();
            var summonerPuuid = controllerMatches.GetSummonerPuuid(Region, SummonerName);
            List<string> matchesId = controllerMatches.GetMatchesId(Region, summonerPuuid);
            foreach (var matchId in matchesId)
            {
                var participantMatch = controllerMatches.GetContext(Region, matchId, SummonerName);
                items.Add(new MatchInfo() { SummonerName = participantMatch.Item1, ChampionName = participantMatch.Item2, Kills = participantMatch.Item3, Deaths = participantMatch.Item4, Assists = participantMatch.Item5, Win = participantMatch.Item6 });
            }
            MatchesList = items;
        }

        private ObservableCollection<MatchInfo> matchesList;
        public ObservableCollection<MatchInfo> MatchesList
        { 
            get { return matchesList; }
            set
            {
                matchesList = value;
                OnPropertyChanged();
            }
        }

        private void GetPlayerInfo()
        {
            if (SummonerName != null && Region != null)
            {
                if (controller.GetSummoner(Region, SummonerName))
                {
                    var entry = controller.GetContext(Region, controller.GetSummonerId(Region, SummonerName));
                    SummonerTier = entry.Item1;
                    SummonerRank = entry.Item2;
                    SummonerWins = entry.Item3;
                    SummonerLosses = entry.Item4;
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
                    Values = new ChartValues<ObservableValue> { new ObservableValue(SummonerWins) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title ="Losses",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(summonerLosses) },
                    DataLabels = true
                }
            };
        }
        public SeriesCollection Series { get; set; }

        private void CreateChampionsChart()
        {
            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Wins",
                    Values = new ChartValues<int> { 10, 50, 39, 50 , 60, 40}
                },
                new ColumnSeries
                {
                    Title = "Losses",
                    Values = new ChartValues<int> { 5, 40, 35, 30 , 72, 20}
                }
            };

            ////adding series will update and animate the chart automatically
            //SeriesCollection.Add(new ColumnSeries
            //{
            //    Title = "2016",
            //    Values = new ChartValues<double> { 11, 56, 42 }
            //});

            ////also adding values updates and animates the chart automatically
            //SeriesCollection[1].Values.Add(48d);

            Labels = new[] { "Blitzcrank", "Darius", "Teemo", "Ziggs", "Caitlyn", "Sivir" };
            Formatter = value => value.ToString("N");
        }
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

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
        private int summonerWins;
        public int SummonerWins
        {
            get { return summonerWins; }
            set
            {
                summonerWins = value;
                OnPropertyChanged();
            }
        }

        private int summonerLosses;
        public int SummonerLosses
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
