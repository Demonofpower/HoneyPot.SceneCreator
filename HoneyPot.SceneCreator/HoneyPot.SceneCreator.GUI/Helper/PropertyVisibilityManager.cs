using System;
using System.Windows;
using HoneyPot.SceneCreator.GUI.SceneObjects;

namespace HoneyPot.SceneCreator.GUI.Helper
{
    public class PropertyVisibilityManager
    {
        private StepType stepType;

        public PropertyVisibilityManager(StepType stepType)
        {
            this.stepType = stepType;
        }

        public void SetStepType(StepType newStepType)
        {
            stepType = newStepType;
        }

        private Visibility GetVisibility(string property)
        {
            switch (property)
            {
                case nameof(TextVisibility):
                    return stepType == StepType.DialogLine ? Visibility.Visible : Visibility.Collapsed;
                case nameof(AltGirlSpeaksVisibility):
                    return stepType == StepType.DialogLine ? Visibility.Visible : Visibility.Collapsed;
                case nameof(AltGirlVisibility):
                    return stepType == StepType.ShowAltGirl ? Visibility.Visible : Visibility.Collapsed;
                case nameof(AltGirlHairVisibility):
                    return stepType == StepType.ShowAltGirl ? Visibility.Visible : Visibility.Collapsed;
                case nameof(AltGirlOutfitVisibility):
                    return stepType == StepType.ShowAltGirl ? Visibility.Visible : Visibility.Collapsed;
                case nameof(NewLocationVisibility):
                    return stepType == StepType.Travel ? Visibility.Visible : Visibility.Collapsed;
                default:
                    throw new InvalidOperationException("Unknown property");
            }

            return Visibility.Collapsed;
        }

        public Visibility TextVisibility => GetVisibility(nameof(TextVisibility));
        public Visibility AltGirlSpeaksVisibility => GetVisibility(nameof(AltGirlSpeaksVisibility));
        public Visibility AltGirlVisibility => GetVisibility(nameof(AltGirlVisibility));
        public Visibility AltGirlHairVisibility => GetVisibility(nameof(AltGirlHairVisibility));
        public Visibility AltGirlOutfitVisibility => GetVisibility(nameof(AltGirlOutfitVisibility));
        public Visibility NewLocationVisibility => GetVisibility(nameof(NewLocationVisibility));
    }
}