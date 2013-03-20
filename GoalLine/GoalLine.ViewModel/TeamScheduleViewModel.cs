using System;
using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GoalLine.BL;
using GoalLine.Model;

namespace GoalLine.ViewModel
{
    public class TeamScheduleViewModel : GalaSoft.MvvmLight.ViewModelBase
    {
        private List<TeamSchedule> _teamSchedules;
        private string _fileName;

        public string FileName
        {
            get { return _fileName; }
            set
            {
                _fileName = value;
                TeamSchedules = Import.GenerateTeamSchedules(_fileName);
                RaisePropertyChanged(() => TeamSchedules);
            }
        }

        public List<TeamSchedule> TeamSchedules
        {
            get { return _teamSchedules; }
            set
            {
                _teamSchedules = value;
                RaisePropertyChanged(() => TeamSchedules);
            }
        }

        #region ICommands

        private readonly RelayCommand _exitCommand = new RelayCommand(ExitApplication);

        public ICommand ExitCommand
        {
            get { return _exitCommand; }
        }

        public static void ExitApplication()
        {
            Environment.Exit(0);
        }

        #endregion
    }
}
