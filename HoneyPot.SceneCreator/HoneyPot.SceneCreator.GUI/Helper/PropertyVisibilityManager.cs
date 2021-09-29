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

        private Visibility GetVisibility()
        {


            return Visibility.Collapsed;
        }

        public Visibility TextVisibility => GetVisibility();
        public Visibility AltGirlSpeaksVisibility => GetVisibility();
        public Visibility AltGirlVisibility => GetVisibility();
        public Visibility AltGirlHairVisibility => GetVisibility();
        public Visibility AltGirlOutfitVisibility => GetVisibility();
        public Visibility NewLocationVisibility => GetVisibility();
    }
}