using System.Collections.Generic;
using System.IO;

namespace HoneyPot.SceneCreator.GUI.Selector
{
    class LocationSelectable : ISelectable
    {
        public LocationSelectable(string name, string resourcePath)
        {
            Name = name;
            ResourcePath = resourcePath;
        }

        public string Name { get; set; }
        public string ResourcePath { get; set; }

        public static List<LocationSelectable> InitLocationSelectables()
        {
            var locations = new List<LocationSelectable>();

            var currDir = Directory.GetCurrentDirectory() + @"\Resources\Locations\";

            foreach (var file in Directory.GetFiles(currDir))
            {
                locations.Add(new LocationSelectable(Path.GetFileNameWithoutExtension(file),  file));
            }

            return locations;
        }
    }
}