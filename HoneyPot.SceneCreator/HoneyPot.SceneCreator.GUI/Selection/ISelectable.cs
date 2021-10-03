using System;

namespace HoneyPot.SceneCreator.GUI.Selection
{
    public interface ISelectable
    {
        string Name { get; set; }
        string ResourcePath { get; set; }

        bool CheckIfSearchEligible(string s);
    }
}