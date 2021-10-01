using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Mime;
using System.Windows;
using HoneyPot.SceneCreator.GUI.Helper;
using HoneyPot.SceneCreator.GUI.SceneObjects;
using HoneyPot.SceneCreator.GUI.Selector;
using Microsoft.Win32;
using Newtonsoft.Json;


namespace HoneyPot.SceneCreator.GUI
{
    public class SceneWindowViewModel : BaseViewModel
    {
        private Scene currScene;
        private Step selectedStep;

        private RelayCommand newCommand;
        private RelayCommand exportCommand;
        private RelayCommand selectGirlCommand;
        private RelayCommand selectGirlHairCommand;
        private RelayCommand selectGirlOutfitCommand;
        private RelayCommand selectAltGirlCommand;
        private RelayCommand selectAltGirlHairCommand;
        private RelayCommand selectAltGirlOutfitCommand;
        private RelayCommand selectNewLocCommand;

        public ObservableCollection<Step> Steps { get; set; } = new ObservableCollection<Step>();
        
        public SceneWindowViewModel()
        {
            VisibilityManager = new PropertyVisibilityManager(StepType.DialogLine);
        }

        public void OpenScene(Scene scene)
        {
            currScene = scene;
            Visible = true;
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Author));
        }

        private void NewStep()
        {
            Steps.Add(new Step() {id = Steps.Count});
        }

        private void Export()
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "scene.txt";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            currScene.steps = new List<Step>(Steps);

            var json = JsonConvert.SerializeObject(currScene, Formatting.Indented,
                new JsonSerializerSettings() {NullValueHandling = NullValueHandling.Ignore});

            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, json);
            }
        }

        private void SelectGirl()
        {
            var s = new Selector.Selector(GirlSelectable.InitGirlSelectables());

            s.ShowDialog();

            if (s.Selected == null)
            {
                return;
            }

            Girl = s.Selected.Name;
        }

        private void SelectGirlHair()
        {
            if (string.IsNullOrWhiteSpace(Girl))
            {
                return;
            }

            var s = new Selector.Selector(
                GirlOutfitHairstyleSelectable.InitGirlOutfitHairstyleSelectables(Girl,
                    new[] { "8", "9", "10", "11", "12" }));

            s.ShowDialog();

            if (s.Selected == null)
            {
                return;
            }

            GirlHairId = Convert.ToInt32(s.Selected.Name);
        }

        private void SelectGirlOutfit()
        {
            if (string.IsNullOrWhiteSpace(Girl))
            {
                return;
            }

            var s = new Selector.Selector(
                GirlOutfitHairstyleSelectable.InitGirlOutfitHairstyleSelectables(Girl,
                    new[] { "13", "14", "15", "16", "17" }));

            s.ShowDialog();

            if (s.Selected == null)
            {
                return;
            }

            GirlOutfitId = Convert.ToInt32(s.Selected.Name);
        }

        private void SelectAltGirl()
        {
            var s = new Selector.Selector(GirlSelectable.InitGirlSelectables());

            s.ShowDialog();

            if (s.Selected == null)
            {
                return;
            }

            AltGirl = s.Selected.Name;
        }

        private void SelectAltGirlHair()
        {
            if (string.IsNullOrWhiteSpace(AltGirl))
            {
                return;
            }

            var s = new Selector.Selector(
                GirlOutfitHairstyleSelectable.InitGirlOutfitHairstyleSelectables(AltGirl,
                    new[] {"8", "9", "10", "11", "12"}));

            s.ShowDialog();

            if (s.Selected == null)
            {
                return;
            }

            AltGirlHairId = Convert.ToInt32(s.Selected.Name);
        }

        private void SelectAltGirlOutfit()
        {
            if (string.IsNullOrWhiteSpace(AltGirl))
            {
                return;
            }

            var s = new Selector.Selector(
                GirlOutfitHairstyleSelectable.InitGirlOutfitHairstyleSelectables(AltGirl,
                    new[] {"13", "14", "15", "16", "17"}));

            s.ShowDialog();

            if (s.Selected == null)
            {
                return;
            }

            AltGirlOutfitId = Convert.ToInt32(s.Selected.Name);
        }

        private void SelectNewLoc()
        {
            var s = new Selector.Selector(LocationSelectable.InitLocationSelectables());

            s.ShowDialog();

            if (s.Selected == null)
            {
                return;
            }
            
            NewLoc = s.Selected.Name;
        }

        public string Name
        {
            get => currScene?.name ?? "";
            set
            {
                if (value == currScene.name) return;
                currScene.name = value;
                OnPropertyChanged();
            }
        }

        public string Author
        {
            get => currScene?.author ?? "";
            set
            {
                if (value == currScene.author) return;
                currScene.author = value;
                OnPropertyChanged();
            }
        }

        public Step SelectedStep
        {
            get => selectedStep;
            set
            {
                if (value == selectedStep) return;
                selectedStep = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(MediaTypeNames.Text));
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

        public string Girl
        {
            get => selectedStep?.girl ?? "";
            set
            {
                if (Equals(value, selectedStep.girl)) return;
                selectedStep.girl = value;
                OnPropertyChanged();
            }
        }

        public int GirlHairId
        {
            get => selectedStep?.girlHairId ?? 0;
            set
            {
                if (Equals(value, selectedStep.girlHairId)) return;
                selectedStep.girlHairId = value;
                OnPropertyChanged();
            }
        }

        public int GirlOutfitId
        {
            get => selectedStep?.girlOutfitId ?? 0;
            set
            {
                if (Equals(value, selectedStep.girlOutfitId)) return;
                selectedStep.girlOutfitId = value;
                OnPropertyChanged();
            }
        }

        public string AltGirl
        {
            get => selectedStep?.altGirl ?? "";
            set
            {
                if (Equals(value, selectedStep.altGirl)) return;
                selectedStep.altGirl = value;
                OnPropertyChanged();
            }
        }

        public int AltGirlHairId
        {
            get => selectedStep?.altGirlHairId ?? 0;
            set
            {
                if (Equals(value, selectedStep.altGirlHairId)) return;
                selectedStep.altGirlHairId = value;
                OnPropertyChanged();
            }
        }

        public int AltGirlOutfitId
        {
            get => selectedStep?.altGirlOutfitId ?? 0;
            set
            {
                if (Equals(value, selectedStep.altGirlOutfitId)) return;
                selectedStep.altGirlOutfitId = value;
                OnPropertyChanged();
            }
        }

        public string NewLoc
        {
            get => selectedStep?.newLoc ?? "";
            set
            {
                if (Equals(value, selectedStep.newLoc)) return;
                selectedStep.newLoc = value;
                OnPropertyChanged();
            }
        }

        public PropertyVisibilityManager VisibilityManager { get; }

        public RelayCommand NewCommand => newCommand ?? (newCommand = new RelayCommand(NewStep));
        public RelayCommand ExportCommand => exportCommand ?? (exportCommand = new RelayCommand(Export));
        public RelayCommand SelectGirlCommand =>
            selectGirlCommand ?? (selectGirlCommand = new RelayCommand(SelectGirl));

        public RelayCommand SelectGirlHairCommand =>
            selectGirlHairCommand ?? (selectGirlHairCommand = new RelayCommand(SelectGirlHair));

        public RelayCommand SelectGirlOutfitCommand =>
            selectGirlOutfitCommand ?? (selectGirlOutfitCommand = new RelayCommand(SelectGirlOutfit));
        public RelayCommand SelectAltGirlCommand =>
            selectAltGirlCommand ?? (selectAltGirlCommand = new RelayCommand(SelectAltGirl));

        public RelayCommand SelectAltGirlHairCommand =>
            selectAltGirlHairCommand ?? (selectAltGirlHairCommand = new RelayCommand(SelectAltGirlHair));

        public RelayCommand SelectAltGirlOutfitCommand =>
            selectAltGirlOutfitCommand ?? (selectAltGirlOutfitCommand = new RelayCommand(SelectAltGirlOutfit));

        public RelayCommand SelectNewLocCommand =>
            selectNewLocCommand ?? (selectNewLocCommand = new RelayCommand(SelectNewLoc));
    }
}