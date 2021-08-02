using System.Collections.Generic;
using System.Collections.ObjectModel;
using HoneyPot.SceneCreator.GUI.Helper;
using HoneyPot.SceneCreator.GUI.SceneObjects;

namespace HoneyPot.SceneCreator.GUI
{
    public class SceneWindowViewModel : BaseViewModel
    {
        public ObservableCollection<string> Steps { get; set; } = new ObservableCollection<string>() {"a", "b", "c", "d", "e"};
        
        private Scene currScene;

        public void OpenScene(Scene scene)
        {
            Visible = true;
        }
    }
}
