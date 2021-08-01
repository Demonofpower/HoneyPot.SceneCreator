namespace HoneyPot.SceneCreator.GUI
{
    public class MainWindowViewModel
    {
        public ManageWindowViewModel ManageWindowViewModel { get; set; }
        public SceneWindowViewModel SceneWindowViewModel { get; set; }
        
        public MainWindowViewModel()
        {
            ManageWindowViewModel = new ManageWindowViewModel();
            SceneWindowViewModel = new SceneWindowViewModel();

            ManageWindowViewModel.Visible = true;
            SceneWindowViewModel.Visible = false;
        }
    }
}
