using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using HoneyPot.SceneCreator.GUI.Helper;
using HoneyPot.SceneCreator.GUI.SceneObjects;

namespace HoneyPot.SceneCreator.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowViewModel MainWindowViewModel { get; set; }


        public MainWindow()
        {
            MainWindowViewModel = new MainWindowViewModel();
            InitializeComponent();

            CurrentStepTypeComboBox.ItemsSource = typeof(StepType).GetEnumNames();

            ResponseOptionsControl.ItemsSource = MainWindowViewModel.SceneWindowViewModel.Responses;

            StepsView.ItemsSource = MainWindowViewModel.SceneWindowViewModel.Steps;
            StepsView.DisplayMemberPath = "StepDescription";
            
            thisMainWindow = this;
        }

        //I don´t want to pass an event or instance to any viewmodel so in this case i think static is okay
        //Also implementing INotifyPropertyChanged inside "Step" class which is also serialized is not that good in my opinion
        //Pls no kill
        private static MainWindow thisMainWindow;

        public static void UpdateStepsList()
        {
            thisMainWindow?.StepsView.Items.Refresh();
        }

        public static void UpdateStepsListItemSource()
        {
            thisMainWindow.StepsView.ItemsSource = null;
            thisMainWindow.StepsView.ItemsSource = thisMainWindow.MainWindowViewModel.SceneWindowViewModel.Steps;

        }

        public static void SortStepList()
        {
            thisMainWindow?.SortStepView();
        }

        public static void UpdateStepType(int count)
        {
            thisMainWindow.CurrentStepLabel.Content = count;
            thisMainWindow.CurrentStepTypeComboBox.SelectedIndex = 0;
        }

        public static void UpdateResponses()
        {
            thisMainWindow?.ResponseOptionsControl.Items.Refresh();
        }

        //This shit took me hours to debug.. and its a noob mistake
        public static void UpdateResponseItemsSource()
        {
            thisMainWindow.ResponseOptionsControl.ItemsSource = null;
            thisMainWindow.ResponseOptionsControl.ItemsSource =
                thisMainWindow?.MainWindowViewModel.SceneWindowViewModel.Responses;
        }

        //-------------------------------------------------------------------------------------------------------------------

        internal void SortStepView()
        {
            var stepsList = MainWindowViewModel.SceneWindowViewModel.Steps;

            var sorted = new List<Step>();
            for (int i = 0; i < stepsList.Count; i++)
            {
                if (stepsList[i] is null)
                {
                    continue;
                }
                
                stepsList[i].id = i;
                sorted.Add(stepsList[i]);
            }

            stepsList.Clear();
            foreach (var step in sorted)
            {
                stepsList.Add(step);
            }
        }

        private void StepsView_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListBoxItem)
            {
                ListBoxItem draggedItem = sender as ListBoxItem;

                var selectedStep = (Step) draggedItem.DataContext;
                MainWindowViewModel.SceneWindowViewModel.SelectedStep = selectedStep;
                CurrentStepLabel.Content = selectedStep;

                CurrentStepTypeComboBox.SelectedItem = selectedStep.type.ToString();

                DragDrop.DoDragDrop(draggedItem, draggedItem.DataContext, DragDropEffects.Move);
                draggedItem.IsSelected = true;
            }
        }

        private void StepsView_OnDrop(object sender, DragEventArgs e)
        {
            var stepsList = MainWindowViewModel.SceneWindowViewModel.Steps;

            var droppedData = e.Data.GetData(typeof(Step)) as Step;
            var target = ((ListBoxItem) (sender)).DataContext as Step;

            int removedIdx = StepsView.Items.IndexOf(droppedData);
            int targetIdx = StepsView.Items.IndexOf(target);

            if (removedIdx < targetIdx)
            {
                stepsList.Insert(targetIdx + 1, droppedData);
                stepsList.RemoveAt(removedIdx);
            }
            else
            {
                int remIdx = removedIdx + 1;
                if (stepsList.Count + 1 > remIdx)
                {
                    stepsList.Insert(targetIdx, droppedData);
                    stepsList.RemoveAt(remIdx);
                }
            }
            
            SortStepView();
        }

        private void CurrentStepTypeComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            var selected = comboBox?.SelectedItem;
            var newStepType = (StepType) Enum.Parse(typeof(StepType), (string) selected);
            MainWindowViewModel.SceneWindowViewModel.SelectedStep.type = newStepType;
            MainWindowViewModel.SceneWindowViewModel.VisibilityManager.SetStepType(newStepType);

            MainWindowViewModel.SceneWindowViewModel.SelectedStep.IsCurrentlySelected = true;

            UpdateStepsList();
            UpdateStepsListItemSource();
        }

        private void SwitchStepsBranchClick(object sender, MouseButtonEventArgs e)
        {
            if (!(sender is Label label))
            {
                return;
            }

            var scene = MainWindowViewModel.SceneWindowViewModel;
            var responseText = label.Content as string;

            var newTreePath = scene.CurrentTreePath + "#" + responseText;

            if (scene.CurrentResponseDepthString == "Origin")
            {
                scene.StepTree.AddOrigin(scene.Steps, scene.Name, scene.Author);
            }
            else
            {
                scene.StepTree.SetStepsForBranch(scene.Steps, scene.CurrentTreePath);
            }

            scene.StepTree.AddBranch(newTreePath);

            var newScene = new Scene()
            {
                author = scene.Author,
                name = scene.Name,
                steps = scene.StepTree.Steps[newTreePath]
            };

            scene.OpenScene(newScene);

            scene.CurrentResponseDepthString = responseText;

            scene.CurrentTreePath = newTreePath;

            scene.Responses = new List<Response>();

            UpdateStepsListItemSource();
            UpdateStepsList();
            UpdateResponseItemsSource();
            UpdateResponses();
        }

        private void ReturnToOriginClick(object sender, RoutedEventArgs e)
        {
            var scene = MainWindowViewModel.SceneWindowViewModel;

            scene.StepTree.SetStepsForBranch(scene.Steps, scene.CurrentTreePath);

            var originScene = new Scene()
            {
                author = scene.StepTree.Author,
                name = scene.StepTree.Name,
                steps = new List<Step>(scene.StepTree.Steps["0"])
            };

            scene.OpenScene(originScene);

            scene.CurrentTreePath = "0";
            
            UpdateStepsListItemSource();
            UpdateStepsList();
            UpdateResponseItemsSource();
            UpdateResponses();
        }
    }
}