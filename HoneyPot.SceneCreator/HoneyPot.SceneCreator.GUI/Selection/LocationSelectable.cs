using System.Collections.Generic;
using System.IO;

namespace HoneyPot.SceneCreator.GUI.Selection
{
    class LocationSelectable : ISelectable
    {
        public string Name { get; set; }
        public string ResourcePath { get; set; }

        public LocationSelectable(string name, string resourcePath)
        {
            Name = name;
            ResourcePath = resourcePath;
        }

        public bool CheckIfSearchEligible(string s)
        {
            return string.IsNullOrEmpty(s) || Name.Contains(s) || ResourcePath.Contains(s);
        }

        public static List<LocationSelectable> InitLocationSelectables()
        {
            var locations = new List<LocationSelectable>();

            var currDir = Directory.GetCurrentDirectory() + @"\Resources\Locations\";

            foreach (var file in Directory.GetFiles(currDir))
            {
                locations.Add(new LocationSelectable(Path.GetFileNameWithoutExtension(file), file));
            }

            return locations;
        }
    }
}