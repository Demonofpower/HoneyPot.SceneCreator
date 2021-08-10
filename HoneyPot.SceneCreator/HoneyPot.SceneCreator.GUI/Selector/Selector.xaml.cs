using System.Collections.Generic;
using System.Windows;

namespace HoneyPot.SceneCreator.GUI.Selector
{
    /// <summary>
    /// Interaction logic for Selector.xaml
    /// </summary>
    public partial class Selector : Window
    {
        private ISelectable selected;
        
        public ISelectable Selected
        {
            get => selected;
            set
            {
                selected = value;
                Close();
            }
        }

        public Selector(IEnumerable<ISelectable> values)
        {
            InitializeComponent();
            ListBox.ItemsSource = values;
        }
    }
}
