using System.Collections.ObjectModel;
using System.Windows;
using HoneyPot.SceneCreator.GUI.Helper;
using HoneyPot.SceneCreator.GUI.SceneObjects;

namespace HoneyPot.SceneCreator.GUI
{
    public class SceneWindowViewModel : BaseViewModel
    {
        private Scene currScene;
        private Step selectedStep;

        private RelayCommand newCommand;
        private RelayCommand exportCommand;

        public ObservableCollection<Step> Steps { get; set; } = new ObservableCollection<Step>() {new Step() {id = 0, type = StepType.DialogLine, text = "abc"}, new Step() {id = 1, type = StepType.DialogLine}};

        public void OpenScene(Scene scene)
        {
            currScene = scene;
            Visible = true;
        }
        
        private void NewStep()
        {
            Steps.Add(new Step());
        }

        private void Export()
        {
            MessageBox.Show("s");
        }

        public Step SelectedStep
        {
            get => selectedStep;
            set
            {
                if (value == selectedStep) return;
                selectedStep = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Text));
                OnPropertyChanged(nameof(AltGirlSpeaks));
            }
        }

        public string Text
        {
            get => selectedStep?.text ?? "";
            set
            {
                if (value == selectedStep.text) return;
                selectedStep.text = value;
                OnPropertyChanged();
            }
        }

        public bool AltGirlSpeaks
        {
            get => selectedStep?.altGirlSpeaks ?? false;
            set
            {
                if (value == selectedStep.altGirlSpeaks) return;
                selectedStep.altGirlSpeaks = value;
                OnPropertyChanged();
            }
        }


        public RelayCommand NewCommand => newCommand ?? (newCommand = new RelayCommand(NewStep));
        public RelayCommand ExportCommand => exportCommand ?? (exportCommand = new RelayCommand(Export));
    }
}
