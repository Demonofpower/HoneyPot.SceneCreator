using System;
using System.Windows;
using HoneyPot.SceneCreator.GUI.SceneObjects;

namespace HoneyPot.SceneCreator.GUI.Helper
{
    public class PropertyVisibilityManager : BaseViewModel
    {
        private StepType stepType;

        public PropertyVisibilityManager(StepType stepType)
        {
            this.stepType = stepType;
        }

        public void SetStepType(StepType newStepType)
        {
            stepType = newStepType;

            OnPropertyChanged(nameof(TextVisibility));
            OnPropertyChanged(nameof(AltGirlSpeaksVisibility));
            OnPropertyChanged(nameof(GirlVisibility));
            OnPropertyChanged(nameof(GirlHairVisibility));
            OnPropertyChanged(nameof(GirlOutfitVisibility)); 
            OnPropertyChanged(nameof(AltGirlVisibility));
            OnPropertyChanged(nameof(AltGirlHairVisibility));
            OnPropertyChanged(nameof(AltGirlOutfitVisibility));
            OnPropertyChanged(nameof(NewLocationVisibility));
            OnPropertyChanged(nameof(ExistingDialogVisibility));
        }

        private Visibility GetVisibility(string property)
        {
            switch (property)
            {
                case nameof(TextVisibility):
                    return stepType == StepType.DialogLine ? Visibility.Visible : Visibility.Collapsed;
                case nameof(AltGirlSpeaksVisibility):
                    return stepType == StepType.DialogLine ? Visibility.Visible : Visibility.Collapsed;
                case nameof(GirlVisibility):
                    return stepType == StepType.ShowGirl ? Visibility.Visible : Visibility.Collapsed;
                case nameof(GirlHairVisibility):
                    return stepType == StepType.ShowGirl ? Visibility.Visible : Visibility.Collapsed;
                case nameof(GirlOutfitVisibility):
                    return stepType == StepType.ShowGirl ? Visibility.Visible : Visibility.Collapsed;
                case nameof(AltGirlVisibility):
                    return stepType == StepType.ShowAltGirl ? Visibility.Visible : Visibility.Collapsed;
                case nameof(AltGirlHairVisibility):
                    return stepType == StepType.ShowAltGirl ? Visibility.Visible : Visibility.Collapsed;
                case nameof(AltGirlOutfitVisibility):
                    return stepType == StepType.ShowAltGirl ? Visibility.Visible : Visibility.Collapsed;
                case nameof(NewLocationVisibility):
                    return stepType == StepType.Travel ? Visibility.Visible : Visibility.Collapsed;
                case nameof(ExistingDialogVisibility):
                    return stepType == StepType.ExistingDialogLine ? Visibility.Visible : Visibility.Collapsed;
                default:
                    throw new InvalidOperationException("Unknown property");
            }
        }
        
        public Visibility TextVisibility => GetVisibility(nameof(TextVisibility));
        public Visibility AltGirlSpeaksVisibility => GetVisibility(nameof(AltGirlSpeaksVisibility));
        public Visibility GirlVisibility => GetVisibility(nameof(GirlVisibility));
        public Visibility GirlHairVisibility => GetVisibility(nameof(GirlHairVisibility));
        public Visibility GirlOutfitVisibility => GetVisibility(nameof(GirlOutfitVisibility));
        public Visibility AltGirlVisibility => GetVisibility(nameof(AltGirlVisibility));
        public Visibility AltGirlHairVisibility => GetVisibility(nameof(AltGirlHairVisibility));
        public Visibility AltGirlOutfitVisibility => GetVisibility(nameof(AltGirlOutfitVisibility));
        public Visibility NewLocationVisibility => GetVisibility(nameof(NewLocationVisibility));
        public Visibility ExistingDialogVisibility => GetVisibility(nameof(ExistingDialogVisibility));
    }
}