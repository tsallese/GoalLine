using GoalLine.ViewModel.ViewModel;

namespace GoalLine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            var context = new MainViewModel { FileName = @"C:\Projects\GoalLine\Import\BYH MASTER SCHEDULE.csv" };
            DataContext = context;
            InitializeComponent();

        }
    }
}
