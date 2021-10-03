using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<ISelectable> ObservableSelectables { get; set; }

        private List<ISelectable> selectables;
        private ISelectable selected;
        private string searchText;

        public Selector(IEnumerable<ISelectable> values, bool search = false)
        {
            selectables = new List<ISelectable>(values);
            ObservableSelectables = new ObservableCollection<ISelectable>(values);

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
        }

        private void Search()
        {
            var obs = (ObservableCollection<ISelectable>) ListBox.ItemsSource;
            obs.Clear();
            foreach (var selectable in selectables)
            {
                obs.Add(selectable);
            }

            var toDelete = new ObservableCollection<ISelectable>(ObservableSelectables.Where(x =>
                    !x.CheckIfSearchEligible(SearchText)));

            foreach (var selectable in toDelete)
            {
                obs.Remove(selectable);
            }
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


        public string SearchText
        {
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