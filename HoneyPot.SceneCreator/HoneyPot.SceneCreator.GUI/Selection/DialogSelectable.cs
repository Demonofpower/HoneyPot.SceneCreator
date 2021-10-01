using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HoneyPot.SceneCreator.GUI.Selection
{
    class DialogSelectable : ISelectable
    {
        public string Girl { get; set; }

        public string Name { get; set; }
        public string ResourcePath { get; set; }

        public DialogSelectable(string text, string id, string girl)
        {
            Name = text;
            ResourcePath = id;
            Girl = girl;
        }

        public static List<DialogSelectable> InitDialogSelectables()
        {
            var dialogs = new List<DialogSelectable>();

            var lines = File.ReadLines(Directory.GetCurrentDirectory() + @"\Resources\Dialogs\dialogs.txt").ToArray();

            for (int i = 0; i < lines.Count() - 4; i+=5)
            {
                var dialog = new DialogSelectable(lines[i+3], lines[i], lines[i+2]);
                dialogs.Add(dialog);
            }

            return dialogs;
        }
    }
}