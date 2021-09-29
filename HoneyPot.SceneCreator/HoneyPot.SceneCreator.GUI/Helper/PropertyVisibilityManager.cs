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
                    break;
                case nameof(AltGirlSpeaksVisibility):
                    break;
                case nameof(AltGirlVisibility):
                    break;
                case nameof(AltGirlHairVisibility):
                    break;
                case nameof(AltGirlOutfitVisibility):
                    break;
                case nameof(NewLocationVisibility):
                    break;
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