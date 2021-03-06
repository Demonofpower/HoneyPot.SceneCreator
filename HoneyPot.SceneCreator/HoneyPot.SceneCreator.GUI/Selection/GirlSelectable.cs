using System.Collections.Generic;
using System.IO;

namespace HoneyPot.SceneCreator.GUI.Selection
{
    public class GirlSelectable : ISelectable
    {
        public string Name { get; set; }
        public string ResourcePath { get; set; }

        public GirlSelectable(string name, string resourcePath)
        {
            Name = name;
            ResourcePath = resourcePath;
        }

        public bool CheckIfSearchEligible(string s)
        {
            return string.IsNullOrEmpty(s) || Name.Contains(s) || ResourcePath.Contains(s);
        }

        public static List<GirlSelectable> InitGirlSelectables()
        {
            var girls = new List<GirlSelectable>();

            var currDir = Directory.GetCurrentDirectory() + @"\Resources\Portraits\";

            girls.Add(new GirlSelectable("Aiko", currDir + "Aiko_Portrait.png"));
            girls.Add(new GirlSelectable("Audrey", currDir + "Audrey_Portrait.png"));
            girls.Add(new GirlSelectable("Beli", currDir + "Beli_Portrait.png"));
            girls.Add(new GirlSelectable("Celeste", currDir + "Celeste_Portrait.png"));
            girls.Add(new GirlSelectable("Jessie", currDir + "Jessie_Portrait.png"));
            girls.Add(new GirlSelectable("Kyanna", currDir + "Kyanna_Portrait.png"));
            girls.Add(new GirlSelectable("Kyu", currDir + "Kyu_Portrait.png"));
            girls.Add(new GirlSelectable("Lola", currDir + "Lola_Portrait.png"));
            girls.Add(new GirlSelectable("Momo", currDir + "Momo_Portrait.png"));
            girls.Add(new GirlSelectable("Nikki", currDir + "Nikki_Portrait.png"));
            girls.Add(new GirlSelectable("Tiffany", currDir + "Tiffany_Portrait.png"));
            girls.Add(new GirlSelectable("Venus", currDir + "Venus_Portrait.png"));
            return girls;
        }
    }
}