using System.Collections.Generic;
using System.Linq;
using System.Windows;
using HoneyPot.SceneCreator.GUI.Helper;

namespace HoneyPot.SceneCreator.GUI.Selection
{
    /// <summary>
    /// Interaction logic for Selector.xaml
    /// </summary>
    public partial class Selector : Window
    {
        private ISelectable selected;
        private string searchText;

        public Selector(IEnumerable<ISelectable> values, bool search = false)
        {
            SearchCommand = new RelayCommand(Search);

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

        private void Search()
        {
            MessageBox.Show(SearchText);
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


        public string SearchText {
            get => searchText;
            set
            {
                if (searchText != null && value == searchText) return;
                searchText = value;
            }
        }

        public bool SearchVisible { get; }

        public RelayCommand SearchCommand { get; }
    }
}