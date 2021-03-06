namespace HoneyPot.SceneCreator.GUI.Helper
{
    public class CommandManager
    {
        public CommandManager(SceneWindowViewModel viewModel)
        {
            NewCommand = new RelayCommand(viewModel.NewStep);
            DeleteCommand = new RelayCommand(viewModel.DeleteStep);
            ExportCommand = new RelayCommand(viewModel.Export);
            SelectGirlCommand = new RelayCommand(viewModel.SelectGirl);
            SelectGirlHairCommand = new RelayCommand(viewModel.SelectGirlHair);
            SelectGirlOutfitCommand = new RelayCommand(viewModel.SelectGirlOutfit);
            SelectAltGirlCommand = new RelayCommand(viewModel.SelectAltGirl);
            SelectAltGirlHairCommand = new RelayCommand(viewModel.SelectAltGirlHair);
            SelectAltGirlOutfitCommand = new RelayCommand(viewModel.SelectAltGirlOutfit);
            SelectNewLocCommand = new RelayCommand(viewModel.SelectNewLoc);
            SelectExistingDialogCommand = new RelayCommand(viewModel.SelectExistingDialog);
            AddResponsesCommand = new RelayCommand(viewModel.AddResponseOption);
        }

        public RelayCommand NewCommand { get; }
        public RelayCommand DeleteCommand { get; }
        public RelayCommand ExportCommand { get; }
        public RelayCommand SelectGirlCommand { get; }
        public RelayCommand SelectGirlHairCommand { get; }
        public RelayCommand SelectGirlOutfitCommand { get; }
        public RelayCommand SelectAltGirlCommand { get; }
        public RelayCommand SelectAltGirlHairCommand { get; }
        public RelayCommand SelectAltGirlOutfitCommand { get; }
        public RelayCommand SelectNewLocCommand { get; }
        public RelayCommand SelectExistingDialogCommand { get; }
        public RelayCommand AddResponsesCommand { get; }
    }
}