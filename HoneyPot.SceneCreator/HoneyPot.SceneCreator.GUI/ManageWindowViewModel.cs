using System.IO;
using System.Windows;
using HoneyPot.SceneCreator.GUI.Helper;
using HoneyPot.SceneCreator.GUI.SceneObjects;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace HoneyPot.SceneCreator.GUI
{
    public class ManageWindowViewModel : BaseViewModel
    {
        private OpenSceneEventHandler onOpenScene;
        private CloseSceneEventHandler onCloseScene;

        public ManageWindowViewModel(OpenSceneEventHandler onOpenScene, CloseSceneEventHandler onCloseScene)
        {
            this.onOpenScene = onOpenScene;
            this.onCloseScene = onCloseScene;

            NewCommand = new RelayCommand(New);
            LoadCommand = new RelayCommand(Load);
            BackCommand = new RelayCommand(Back);
        }

        private void New()
        {
            onOpenScene.Invoke(new Scene() {name = "myScene", author = "myself"});
            Visible = false;
        }

        private void Load()
        {
            var loadFileDialog = new OpenFileDialog();
            loadFileDialog.DefaultExt = "txt";
            loadFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            loadFileDialog.ShowDialog();

            var toLoad = JsonConvert.DeserializeObject<Scene>(File.ReadAllText(loadFileDialog.FileName));

            onOpenScene.Invoke(toLoad);
            Visible = false;
        }

        private void Back()
        {
            onCloseScene.Invoke();
            Visible = true;
        }

        public RelayCommand NewCommand { get; }
        public RelayCommand LoadCommand { get; }
        public RelayCommand BackCommand { get; }
    }
}