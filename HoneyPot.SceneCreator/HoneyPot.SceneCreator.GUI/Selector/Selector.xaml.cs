using System.Collections.Generic;
using System.Windows;

namespace HoneyPot.SceneCreator.GUI.Selector
{
    /// <summary>
    /// Interaction logic for Selector.xaml
    /// </summary>
    public partial class Selector : Window
    {
        private string selected;
        
        public string Selected
        {
            get => selected;
            set
            {
                selected = value;
                Close();
            }
        }

        public Selector(IEnumerable<string> values)
        {
            InitializeComponent();
            ListBox.ItemsSource = values;
        }
    }
}
