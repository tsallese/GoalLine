using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GoalLine.BL;

namespace GoalLine.ViewModel.ViewModel
{
   public class MainViewModel : ViewModelBase
    {
       private ObservableCollection<TeamScheduleViewModel> _teamSchedules;
        private string _fileName;
       private static bool _canExport;

        public string FileName
        {
            get { return _fileName; }
            set
            {
                _fileName = value;
                var teams = Import.GenerateTeamSchedules(_fileName);
                _teamSchedules = new ObservableCollection<TeamScheduleViewModel>();
                _teamSchedules.CollectionChanged += IsTeamSelected;
                teams.ForEach(x => TeamSchedules.Add(new TeamScheduleViewModel(x)));
                RaisePropertyChanged(() => TeamSchedules);
            }
        }

       private void IsTeamSelected(object sender, NotifyCollectionChangedEventArgs e)
       {
           if (e.Action != NotifyCollectionChangedAction.Remove && e.Action != NotifyCollectionChangedAction.Add)
               return;
           if (e.NewItems == null) return;
           // Attach the event handler to the new instance;
           foreach (
               var newItem in
                   e.NewItems.Cast<TeamScheduleViewModel>().Where(newItem => newItem != null))
           {
               (newItem as INotifyPropertyChanged).PropertyChanged += TeamSchedule_PropertyChanged;
           }
       }

       private void TeamSchedule_PropertyChanged(object sender, PropertyChangedEventArgs e)
       {
           var teamItem = sender as TeamScheduleViewModel;

           if(teamItem == null) return;
           _canExport = teamItem.IsSelected;
       }

       public ObservableCollection<TeamScheduleViewModel> TeamSchedules
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

        private readonly RelayCommand _exportCommand = new RelayCommand(ExportApplication, CanExport);

        public ICommand ExportCommand
        {
            get { return _exportCommand; }
        }

        public static void ExportApplication()
        {
            throw new Exception("Not implemented.");
        }

       public static bool CanExport()
       {
           return _canExport;
       }

       #endregion

    }
}