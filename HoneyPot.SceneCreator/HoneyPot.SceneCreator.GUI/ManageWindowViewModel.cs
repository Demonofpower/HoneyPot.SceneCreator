using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            ModGithubCommand = new RelayCommand(ModGithub);
            CreatorGithubCommand = new RelayCommand(CreatorGithub);
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

            loadFileDialog.FileOk += (sender, args) =>
            {
                try
                {
                    var toLoad = JsonConvert.DeserializeObject<Scene>(File.ReadAllText(loadFileDialog.FileName));

                    var stepTree = SetStepTree(toLoad);

                    onOpenScene.Invoke(toLoad, stepTree);
                    Visible = false;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error while loading scene :( Is the file valid?");
                }
            };

            loadFileDialog.ShowDialog();
        }

        private StepTree SetStepTree(Scene scene)
        {
            var tree = new StepTree();

            tree.AddOrigin(scene.steps, scene.name, scene.author);

            tree = RecursiveTreeHandler(tree, scene.steps, "0");

            return tree;
        }

        private StepTree RecursiveTreeHandler(StepTree tree, List<Step> steps, string currentDepthName)
        {
            foreach (var sceneStep in steps)
            {
                if (sceneStep.type == StepType.ResponseOptions)
                {
                    foreach (var sceneStepResponse in sceneStep.responses)
                    {
                        var branchName = currentDepthName + "#" + sceneStepResponse.text;
                        tree.AddBranch(branchName);
                        tree.SetStepsForBranch(sceneStepResponse.steps, branchName);

                        tree = RecursiveTreeHandler(tree, sceneStepResponse.steps, branchName);
                    }
                }
            }

            return tree;
        }

        private void Back()
        {
            onCloseScene.Invoke();
            Visible = true;
        }

        private void ModGithub()
        {
            Process.Start(@"https://github.com/Demonofpower/HoneyPot");
        }

        private void CreatorGithub()
        {
            Process.Start(@"https://github.com/Demonofpower/HoneyPot.SceneCreator");
        }

        public RelayCommand NewCommand { get; }
        public RelayCommand LoadCommand { get; }
        public RelayCommand BackCommand { get; }
        public RelayCommand ModGithubCommand { get; }
        public RelayCommand CreatorGithubCommand { get; }
    }
}