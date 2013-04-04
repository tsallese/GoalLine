using GoalLine.Model;

namespace GoalLine.ViewModel.ViewModel
{
    public class GameViewModel : ViewModelBase
    {
        private Game _game;

        public GameViewModel(Game dto)
        {
            _game = dto;
        }
        public string ByhTeam
        {
            get { return _game.ByhTeam; }
            set
            {
                _game.ByhTeam = value;
                RaisePropertyChanged(() => ByhTeam);
            }
        }
        public string HomeTeam
        {
            get { return _game.HomeTeam; }
            set
            {
                _game.HomeTeam = value;
                RaisePropertyChanged(() => HomeTeam);
            }
        }
        public string VisitorTeam
        {
            get { return _game.VisitorTeam; }
            set
            {
                _game.VisitorTeam = value;
                RaisePropertyChanged(() => VisitorTeam);
            }
        }
        public string StartDate
        {
            get { return _game.StartDate; }
            set
            {
                _game.StartDate = value;
                RaisePropertyChanged(() => StartDate);
            }
        }
        public string StartTime
        {
            get { return _game.StartTime; }
            set
            {
                _game.StartTime = value;
                RaisePropertyChanged(() => StartTime);
            }
        }
        public string Duration
        {
            get { return _game.Duration; }
            set
            {
                _game.Duration = value;
                RaisePropertyChanged(() => Duration);
            }
        }
        public string Details
        {
            get { return _game.Details; }
            set
            {
                _game.Details = value;
                RaisePropertyChanged(() => Details);
            }
        }
        public string ShowDetails
        {
            get { return _game.ShowDetails; }
            set
            {
                _game.ShowDetails = value;
                RaisePropertyChanged(() => ShowDetails);
            }
        }
        public string LeagueName
        {
            get { return _game.LeagueName; }
            set
            {
                _game.LeagueName = value;
                RaisePropertyChanged(() => LeagueName);
            }
        }
        public string PracticeType
        {
            get { return _game.PracticeType; }
            set
            {
                _game.PracticeType = value;
                RaisePropertyChanged(() => PracticeType);
            }
        }
        public string ScheduleName
        {
            get { return _game.ScheduleName; }
            set
            {
                _game.ScheduleName = value;
                RaisePropertyChanged(() => ScheduleName);
            }
        }
        public string Venue
        {
            get { return _game.Venue; }
            set
            {
                _game.Venue = value;
                RaisePropertyChanged(() => Venue);
            }
        }
    }
}
