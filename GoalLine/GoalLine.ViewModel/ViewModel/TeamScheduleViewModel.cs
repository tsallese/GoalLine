using System;
using System.Collections.ObjectModel;
using System.Linq;
using GoalLine.Model;

namespace GoalLine.ViewModel.ViewModel
{
    public class TeamScheduleViewModel : ViewModelBase
    {
        private TeamSchedule _team;

        public TeamScheduleViewModel(TeamSchedule dto)
        {
            _team = dto;

            Games = new ObservableCollection<GameViewModel>();

            if (_team != null) _team.Games.ForEach( x => Games.Add(new GameViewModel(x)));
        }

        public string Name
        {
            get { return _team.Name; }
            set
            {
                _team.Name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        public string GameCount
        {
            get { return string.Format("Games: {0}", Games.Count); }
        }

        public string LeagueGameCount
        {
            get
            {
                var count = Games.Count(game => game.LeagueName.Trim().StartsWith("L",StringComparison.OrdinalIgnoreCase));

                return string.Format("League Games: {0}", count);
            }
        }

        public string NonLeagueGameCount
        {
            get
            {
                var count = Games.Count(game => game.LeagueName.Trim().StartsWith("Non", StringComparison.OrdinalIgnoreCase));

                return string.Format("Non League Games: {0}", count);
            }
        }
        public ObservableCollection<GameViewModel> Games { get; set; }
    }
}
