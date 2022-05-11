using System.Windows;

namespace DCAD_parser
{
    public partial class MainWindow
    {
        private readonly Manager manager;

        public MainWindow()
        {
            InitializeComponent();
            manager = new Manager();
            manager.Progress += _manager_Progress;
        }

        private void _manager_Progress(object sender, ProgressArgs e)
        {
            ProgressText.Text = e.ProgressCount.ToString();
        }

        private void buttonLaunchManager_Click(object sender, RoutedEventArgs e)
        {
            manager.Launch();
        }
    }
}
