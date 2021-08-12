using System.Collections.Generic;
using System.Linq;
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
            if (values.FirstOrDefault(x => true)?.GetType() == typeof(GirlOutfitHairstyleSelectable))
            {
                this.WindowState = WindowState.Maximized;
            }
            
            InitializeComponent();
            ListBox.ItemsSource = values;
        }
    }
}
