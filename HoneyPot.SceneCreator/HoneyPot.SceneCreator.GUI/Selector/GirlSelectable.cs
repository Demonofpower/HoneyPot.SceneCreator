namespace HoneyPot.SceneCreator.GUI.Selector
{
    class GirlSelectable : ISelectable
    {
        public GirlSelectable(string name, string resourcePath)
        {
            Name = name;
            ResourcePath = resourcePath;
        }
        
        public string Name { get; set; }
        public string ResourcePath { get; set; }
    }
}
