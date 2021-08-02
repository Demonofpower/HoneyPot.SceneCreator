using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

            StepsView.ItemsSource = MainWindowViewModel.SceneWindowViewModel.Steps;
            
            //https://stackoverflow.com/a/3352146
            Style itemContainerStyle = new Style(typeof(ListBoxItem));
            itemContainerStyle.Setters.Add(new Setter(ListBoxItem.AllowDropProperty, true));
            itemContainerStyle.Setters.Add(new EventSetter(ListBoxItem.PreviewMouseLeftButtonDownEvent, new MouseButtonEventHandler(StepsView_OnPreviewMouseLeftButtonDown)));
            itemContainerStyle.Setters.Add(new EventSetter(ListBoxItem.DropEvent, new DragEventHandler(StepsView_OnDrop)));
            StepsView.ItemContainerStyle = itemContainerStyle;
        }

        private void StepsView_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListBoxItem)
            {
                ListBoxItem draggedItem = sender as ListBoxItem;
                DragDrop.DoDragDrop(draggedItem, draggedItem.DataContext, DragDropEffects.Move);
                draggedItem.IsSelected = true;
            }
        }

        private void StepsView_OnDrop(object sender, DragEventArgs e)
        {
            var stepsList = MainWindowViewModel.SceneWindowViewModel.Steps;
            
            
            var droppedData = e.Data.GetData(typeof(string)) as string;
            string target = ((ListBoxItem)(sender)).DataContext as string;

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
        }
    }
}