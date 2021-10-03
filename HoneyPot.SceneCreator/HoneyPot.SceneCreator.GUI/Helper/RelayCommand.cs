using System;
using System.Windows.Input;

namespace HoneyPot.SceneCreator.GUI.Helper
{
    public class RelayCommand : ICommand
    {
        private readonly Action action;
        private readonly Func<bool> canExecute;

        public RelayCommand(Action action, Func<bool> canExecute = null)
        {
            this.action = action;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add => System.Windows.Input.CommandManager.RequerySuggested += value;
            remove => System.Windows.Input.CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute.Invoke();
        }

        public void Execute(object parameter)
        {
            action();
        }
    }
}