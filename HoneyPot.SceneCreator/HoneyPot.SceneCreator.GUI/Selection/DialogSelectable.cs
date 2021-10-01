using System.Collections.Generic;

namespace HoneyPot.SceneCreator.GUI.Selection
{
    class DialogSelectable : ISelectable
    {
        public string Name { get; set; }
        public string ResourcePath { get; set; }

        public DialogSelectable(string name, string resourcePath)
        {
            Name = name;
            ResourcePath = resourcePath;
        }

        public static List<DialogSelectable> InitDialogSelectables()
        {
            var dialogs = new List<DialogSelectable>();

            return dialogs;
        }
    }
}