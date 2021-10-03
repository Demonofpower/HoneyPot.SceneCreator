using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace HoneyPot.SceneCreator.GUI.Selection
{
    /// <summary>
    /// Interaction logic for Selector.xaml
    /// </summary>
    public partial class Selector : Window
    {
        private ISelectable selected;

        public Selector(IEnumerable<ISelectable> values, bool search = false)
        {
            if (values.FirstOrDefault(x => true)?.GetType() == typeof(GirlOutfitHairstyleSelectable))
            {
                this.WindowState = WindowState.Maximized;
            }
            if (values.FirstOrDefault(x => true)?.GetType() == typeof(LocationSelectable))
            {
                this.WindowState = WindowState.Maximized;
            }

            SearchVisible = search;

            InitializeComponent();
            ListBox.ItemsSource = values;
        }
        public ISelectable Selected
        {
            get => selected;
            set
            {
                selected = value;
                Close();
            }
        }

        public bool SearchVisible { get; }
    }
}
