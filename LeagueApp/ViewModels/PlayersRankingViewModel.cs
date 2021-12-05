using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LeagueApp.Commands;
using LeagueApp.Utils;

namespace LeagueApp.ViewModels
{
    class PlayersRankingViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand DoSomethingCommand { get; set; }
        public PlayersRankingViewModel()
        {
            DoSomethingCommand = new RelayCommand(DoSomething);
            SummonerName = Constans.Name;
            Region = Constans.Region;
        }
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void DoSomething(Object obj)
        {
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
    }
}
