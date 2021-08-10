using System.Collections.Generic;
using System.IO;

namespace HoneyPot.SceneCreator.GUI.Selector
{
    class GirlHairSelectable : ISelectable
    {
        public GirlHairSelectable(string name, string resourcePath)
        {
            Name = name;
            ResourcePath = resourcePath;
        }
        
        public string Name { get; set; }
        public string ResourcePath { get; set; }

        public static List<GirlHairSelectable> InitGirlHairSelectables(string girlName)
        {
            var hairs = new List<GirlHairSelectable>();

            var currDir = Directory.GetCurrentDirectory() + @"\Resources\Hair\" + girlName;

            hairs.Add(new GirlHairSelectable("Audrey", currDir + "Audrey_Portrait.png"));

            return hairs;
        }
    }
}