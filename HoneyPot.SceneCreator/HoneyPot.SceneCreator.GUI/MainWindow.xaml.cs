using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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

            StepsView.ItemsSource = MainWindowViewModel.SceneWindowViewModel.Steps;
            StepsView.DisplayMemberPath = "id";

            //https://stackoverflow.com/a/3352146
            Style itemContainerStyle = new Style(typeof(ListBoxItem));
            itemContainerStyle.Setters.Add(new Setter(ListBoxItem.AllowDropProperty, true));
            itemContainerStyle.Setters.Add(new EventSetter(ListBoxItem.PreviewMouseLeftButtonDownEvent,
                new MouseButtonEventHandler(StepsView_OnPreviewMouseLeftButtonDown)));
            itemContainerStyle.Setters.Add(new EventSetter(ListBoxItem.DropEvent,
                new DragEventHandler(StepsView_OnDrop)));
            StepsView.ItemContainerStyle = itemContainerStyle;
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

            var sorted = new List<Step>();
            for (int i = 0; i < stepsList.Count; i++)
            {
                stepsList[i].id = i;
                sorted.Add(stepsList[i]);
            }

            stepsList.Clear();
            foreach (var step in sorted)
            {
                stepsList.Add(step);
            }
        }

        private void CurrentStepTypeComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            var selected = comboBox?.SelectedItem;
            var newStepType = (StepType) Enum.Parse(typeof(StepType), (string) selected);
            MainWindowViewModel.SceneWindowViewModel.SelectedStep.type = newStepType;
            MainWindowViewModel.SceneWindowViewModel.VisibilityManager.SetStepType(newStepType);
        }
    }
}