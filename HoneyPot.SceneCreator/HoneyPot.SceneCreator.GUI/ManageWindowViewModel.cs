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

        private RelayCommand newCommand;
        private RelayCommand loadCommand;

        public ManageWindowViewModel(OpenSceneEventHandler OnOpenScene)
        {
            onOpenScene = OnOpenScene;
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

        public RelayCommand NewCommand => newCommand ?? (newCommand = new RelayCommand(New));
        public RelayCommand LoadCommand => loadCommand ?? (loadCommand = new RelayCommand(Load));
    }
}