using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace HoneyPot.SceneCreator.GUI.Selector
{
    class GirlOutfitHairstyleSelectable : ISelectable
    {
        public GirlOutfitHairstyleSelectable(string name, string resourcePath, int resourceId)
        {
            Name = name;
            ResourcePath = resourcePath;
            ResourceId = resourceId;
        }

        public string Name { get; set; }
        public string ResourcePath { get; set; }
        public int ResourceId { get; set; }
        public CroppedBitmap Image
        {
            get
            {
                BitmapImage src = new BitmapImage();
                src.BeginInit();
                src.UriSource = new Uri(ResourcePath, UriKind.Relative);
                src.CacheOption = BitmapCacheOption.OnLoad;
                src.EndInit();

                return new CroppedBitmap(src, new Int32Rect(1000 * (ResourceId - 1), 0, 1000, 2600));
            }
        }

        public static List<GirlOutfitHairstyleSelectable> InitGirlOutfitHairstyleSelectables(string girlName)
        {
            var hairs = new List<GirlOutfitHairstyleSelectable>();

            var currDir = Directory.GetCurrentDirectory() + @"\Resources\HairstylesOutfits\" + girlName + ".jpg";

            hairs.Add(new GirlOutfitHairstyleSelectable("1", currDir, 1));
            hairs.Add(new GirlOutfitHairstyleSelectable("2", currDir, 2));
            hairs.Add(new GirlOutfitHairstyleSelectable("3", currDir, 3));
            hairs.Add(new GirlOutfitHairstyleSelectable("4", currDir, 4));
            hairs.Add(new GirlOutfitHairstyleSelectable("5", currDir, 5));

            return hairs;
        }
    }
}