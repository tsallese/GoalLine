using System.Collections.ObjectModel;
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

        public int  GameCount { get; set; }

        public ObservableCollection<GameViewModel> Games { get; set; }
    }
}
