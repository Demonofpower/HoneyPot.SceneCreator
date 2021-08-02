using System.Collections.Generic;
using System.Collections.ObjectModel;
using HoneyPot.SceneCreator.GUI.Helper;
using HoneyPot.SceneCreator.GUI.SceneObjects;

namespace HoneyPot.SceneCreator.GUI
{
    public class SceneWindowViewModel : BaseViewModel
    {
        private Scene currScene;
        private Step selectedStep;

        public ObservableCollection<Step> Steps { get; set; } = new ObservableCollection<Step>() {new Step() {id = 0}, new Step() {id = 1}};

        public Step SelectedStep
        {
            get => selectedStep;
            set
            {
                if (value == selectedStep) return;
                selectedStep = value;
                OnPropertyChanged();
            }
        }

        public void OpenScene(Scene scene)
        {
            Visible = true;
        }
    }
}
