using HoneyPot.SceneCreator.GUI.SceneObjects;

namespace HoneyPot.SceneCreator.GUI
{
    public delegate void OpenSceneEventHandler(Scene scene);
    
    public class MainWindowViewModel
    {
        public event OpenSceneEventHandler OpenScene;

        public ManageWindowViewModel ManageWindowViewModel { get; set; }
        public SceneWindowViewModel SceneWindowViewModel { get; set; }
        
        public MainWindowViewModel()
        {
            SceneWindowViewModel = new SceneWindowViewModel();
            OpenScene += SceneWindowViewModel.OpenScene;
            
            ManageWindowViewModel = new ManageWindowViewModel(OpenScene);

            ManageWindowViewModel.Visible = true;
            SceneWindowViewModel.Visible = false;
        }
    }
}
