using System.Windows;
using HoneyPot.SceneCreator.GUI.Helper;
using HoneyPot.SceneCreator.GUI.SceneObjects;

namespace HoneyPot.SceneCreator.GUI
{
    public class ManageWindowViewModel : BaseViewModel
    {
        private OpenSceneEventHandler onOpenScene;
        
        private RelayCommand newCommand;
        private RelayCommand loadCommand;

        public ManageWindowViewModel(OpenSceneEventHandler OnOpenScene)
        {
            onOpenScene = OnOpenScene;
        }

        private void New()
        {
            onOpenScene.Invoke(new Scene());
            Visible = false;
        }
        
        private void Load()
        {
            MessageBox.Show("yyy");
        }

        public RelayCommand NewCommand => newCommand ?? (newCommand = new RelayCommand(New));
        public RelayCommand LoadCommand => loadCommand ?? (loadCommand = new RelayCommand(Load));
    }
}