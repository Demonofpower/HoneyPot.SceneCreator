using HoneyPot.SceneCreator.GUI.SceneObjects;

namespace HoneyPot.SceneCreator.GUI
{
    public delegate void OpenSceneEventHandler(Scene scene);
    public delegate void CloseSceneEventHandler();
    
    public class MainWindowViewModel
    {
        public event OpenSceneEventHandler OpenScene;
        public event CloseSceneEventHandler CloseScene;

        public ManageWindowViewModel ManageWindowViewModel { get; set; }
        public SceneWindowViewModel SceneWindowViewModel { get; set; }
        
        public MainWindowViewModel()
        {
            SceneWindowViewModel = new SceneWindowViewModel();
            OpenScene += SceneWindowViewModel.OpenScene;
            CloseScene += SceneWindowViewModel.CloseScene;
            SceneWindowViewModel.SelectedStep = new Step() {id = 0};
            
            ManageWindowViewModel = new ManageWindowViewModel(OpenScene, CloseScene);

            ManageWindowViewModel.Visible = true;
            SceneWindowViewModel.Visible = false;
        }
    }
}
