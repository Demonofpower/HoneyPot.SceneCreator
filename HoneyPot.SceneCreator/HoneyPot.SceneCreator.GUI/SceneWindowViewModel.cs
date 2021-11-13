﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using HoneyPot.SceneCreator.GUI.Helper;
using HoneyPot.SceneCreator.GUI.SceneObjects;
using HoneyPot.SceneCreator.GUI.Selection;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace HoneyPot.SceneCreator.GUI
{
    public class SceneWindowViewModel : BaseViewModel
    {
        private Scene currScene;
        private Step selectedStep;

        public StepViewRefreshList Steps { get; set; } = new StepViewRefreshList();

        public StepTree StepTree = new StepTree();
        

        public SceneWindowViewModel()
        {
            VisibilityManager = new PropertyVisibilityManager(StepType.DialogLine);
            CommandManager = new CommandManager(this);

            CurrentTreePath = "0";
        }

        public void OpenScene(Scene scene)
        {
            currScene = scene;

            Steps.Clear();

            if (scene.steps != null)
            {
                foreach (var sceneStep in scene.steps)
                {
                    Steps.Add(sceneStep);
                }
            }

            CurrentResponseDepthString = "Origin";

            Visible = true;
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Author));
        }

        public void CloseScene()
        {
            Visible = false;
        }

        public void NewStep()
        {
            var newStep = new Step() {id = Steps.Count};
            Steps.Add(newStep);
            SelectedStep = newStep;
            MainWindow.UpdateStepType(Steps.Count - 1);
        }

        public void DeleteStep()
        {
            Steps.Remove(SelectedStep);
            OnPropertyChanged(nameof(IsStepVisible));
        }

        public void Export()
        {
            SelectedStep.responses = Responses;

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

        public void SelectGirl()
        {
            var s = new Selector(GirlSelectable.InitGirlSelectables());

            s.ShowDialog();

            if (s.Selected == null)
            {
                return;
            }

            Girl = s.Selected.Name;
        }

        public void SelectGirlHair()
        {
            if (string.IsNullOrWhiteSpace(Girl))
            {
                return;
            }

            var s = new Selector(
                GirlOutfitHairstyleSelectable.InitGirlOutfitHairstyleSelectables(Girl,
                    new[] {"8", "9", "10", "11", "12"}));

            s.ShowDialog();

            if (s.Selected == null)
            {
                return;
            }

            GirlHairId = Convert.ToInt32(s.Selected.Name);
        }

        public void SelectGirlOutfit()
        {
            if (string.IsNullOrWhiteSpace(Girl))
            {
                return;
            }

            var s = new Selector(
                GirlOutfitHairstyleSelectable.InitGirlOutfitHairstyleSelectables(Girl,
                    new[] {"13", "14", "15", "16", "17"}));

            s.ShowDialog();

            if (s.Selected == null)
            {
                return;
            }

            GirlOutfitId = Convert.ToInt32(s.Selected.Name);
        }

        public void SelectAltGirl()
        {
            var s = new Selector(GirlSelectable.InitGirlSelectables());

            s.ShowDialog();

            if (s.Selected == null)
            {
                return;
            }

            AltGirl = s.Selected.Name;
        }

        public void SelectAltGirlHair()
        {
            if (string.IsNullOrWhiteSpace(AltGirl))
            {
                return;
            }

            var s = new Selector(
                GirlOutfitHairstyleSelectable.InitGirlOutfitHairstyleSelectables(AltGirl,
                    new[] {"8", "9", "10", "11", "12"}));

            s.ShowDialog();

            if (s.Selected == null)
            {
                return;
            }

            AltGirlHairId = Convert.ToInt32(s.Selected.Name);
        }

        public void SelectAltGirlOutfit()
        {
            if (string.IsNullOrWhiteSpace(AltGirl))
            {
                return;
            }

            var s = new Selector(
                GirlOutfitHairstyleSelectable.InitGirlOutfitHairstyleSelectables(AltGirl,
                    new[] {"13", "14", "15", "16", "17"}));

            s.ShowDialog();

            if (s.Selected == null)
            {
                return;
            }

            AltGirlOutfitId = Convert.ToInt32(s.Selected.Name);
        }

        public void SelectNewLoc()
        {
            var s = new Selector(LocationSelectable.InitLocationSelectables());

            s.ShowDialog();

            if (s.Selected == null)
            {
                return;
            }

            NewLoc = s.Selected.Name;
        }

        public void SelectExistingDialog()
        {
            var s = new Selector(DialogSelectable.InitDialogSelectables(), true);

            s.ShowDialog();

            if (s.Selected == null)
            {
                return;
            }

            DialogId = Convert.ToInt32(s.Selected.ResourcePath);
        }

        public void AddResponseOption()
        {
            Responses.Add(new Response() {text = ResponseText});
            MainWindow.UpdateResponses();
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

        public string Text
        {
            get => SelectedStep?.text ?? "";
            set
            {
                if (value == SelectedStep.text) return;
                SelectedStep.text = value;
                OnPropertyChanged();
            }
        }

        public bool AltGirlSpeaks
        {
            get => SelectedStep?.altGirlSpeaks ?? false;
            set
            {
                if (value == SelectedStep.altGirlSpeaks) return;
                SelectedStep.altGirlSpeaks = value;
                OnPropertyChanged();
            }
        }

        public string Girl
        {
            get => SelectedStep?.girl ?? "";
            set
            {
                if (Equals(value, SelectedStep.girl)) return;
                SelectedStep.girl = value;
                OnPropertyChanged();
            }
        }

        public int GirlHairId
        {
            get => SelectedStep?.girlHairId ?? 0;
            set
            {
                if (Equals(value, SelectedStep.girlHairId)) return;
                SelectedStep.girlHairId = value;
                OnPropertyChanged();
            }
        }

        public int GirlOutfitId
        {
            get => SelectedStep?.girlOutfitId ?? 0;
            set
            {
                if (Equals(value, SelectedStep.girlOutfitId)) return;
                SelectedStep.girlOutfitId = value;
                OnPropertyChanged();
            }
        }

        public string AltGirl
        {
            get => SelectedStep?.altGirl ?? "";
            set
            {
                if (Equals(value, SelectedStep.altGirl)) return;
                SelectedStep.altGirl = value;
                OnPropertyChanged();
            }
        }

        public int AltGirlHairId
        {
            get => SelectedStep?.altGirlHairId ?? 0;
            set
            {
                if (Equals(value, SelectedStep.altGirlHairId)) return;
                SelectedStep.altGirlHairId = value;
                OnPropertyChanged();
            }
        }

        public int AltGirlOutfitId
        {
            get => SelectedStep?.altGirlOutfitId ?? 0;
            set
            {
                if (Equals(value, SelectedStep.altGirlOutfitId)) return;
                SelectedStep.altGirlOutfitId = value;
                OnPropertyChanged();
            }
        }

        public string NewLoc
        {
            get => SelectedStep?.newLoc ?? "";
            set
            {
                if (Equals(value, SelectedStep.newLoc)) return;
                SelectedStep.newLoc = value;
                OnPropertyChanged();
            }
        }

        public int DialogId
        {
            get => SelectedStep?.dialogId ?? 0;
            set
            {
                if (Equals(value, SelectedStep.dialogId)) return;
                SelectedStep.dialogId = value;
                OnPropertyChanged();
            }
        }

        private string currentTreePath;

        public string CurrentTreePath
        {
            get => currentTreePath;
            set
            {
                if (Equals(value, currentTreePath)) return;
                currentTreePath = value;
                OnPropertyChanged();
            }
        }

        private string currentResponseDepthString;

        public string CurrentResponseDepthString
        {
            get => currentResponseDepthString;
            set
            {
                if (Equals(value, currentResponseDepthString)) return;
                currentResponseDepthString = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsOriginButtonVisible));
            }
        }

        private string responseText;

        public string ResponseText
        {
            get => responseText;
            set
            {
                if (Equals(value, responseText)) return;
                responseText = value;
                OnPropertyChanged();
            }
        }

        public List<Response> Responses { get; set; }


        public Step SelectedStep
        {
            get => selectedStep;
            set
            {
                if (value == null) return;
                if (value == selectedStep) return;

                Responses = value.responses;
                MainWindow.ResetResponseItemsSource();

                selectedStep = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(Text));
                OnPropertyChanged(nameof(AltGirlSpeaks));
                OnPropertyChanged(nameof(Girl));
                OnPropertyChanged(nameof(GirlHairId));
                OnPropertyChanged(nameof(GirlOutfitId));
                OnPropertyChanged(nameof(AltGirl));
                OnPropertyChanged(nameof(AltGirlHairId));
                OnPropertyChanged(nameof(AltGirlOutfitId));
                OnPropertyChanged(nameof(NewLoc));

                OnPropertyChanged(nameof(IsStepVisible));
            }
        }

        public Visibility IsStepVisible => SelectedStep != null && Steps.Contains(SelectedStep)
            ? Visibility.Visible
            : Visibility.Collapsed;

        public Visibility IsOriginButtonVisible => CurrentResponseDepthString != "Origin" ? Visibility.Visible : Visibility.Collapsed;

        public PropertyVisibilityManager VisibilityManager { get; }
        public CommandManager CommandManager { get; }
    }
}