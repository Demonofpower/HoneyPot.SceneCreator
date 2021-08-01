using System.Windows;

namespace HoneyPot.SceneCreator.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowViewModel MainWindowViewModel { get; set; }
        
        public MainWindow()
        {
            MainWindowViewModel = new MainWindowViewModel();
            InitializeComponent();
        }
    }
}
