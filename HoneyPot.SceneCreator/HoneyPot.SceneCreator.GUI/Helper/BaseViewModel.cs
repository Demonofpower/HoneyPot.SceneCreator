using System.ComponentModel;
using System.Runtime.CompilerServices;
using HoneyPot.SceneCreator.GUI.Annotations;

namespace HoneyPot.SceneCreator.GUI.Helper
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private bool visible;

        public bool Visible
        {
            get => visible;
            set
            {
                if (value == visible) return;
                visible = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}