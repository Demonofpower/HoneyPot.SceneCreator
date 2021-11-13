using System.Collections.Generic;
using HoneyPot.SceneCreator.GUI.SceneObjects;

namespace HoneyPot.SceneCreator.GUI.Helper
{
    public class StepTree
    {
        public Dictionary<string, List<Step>> Steps;
        public string Author;
        public string Name;

        public StepTree()
        {
            Steps = new Dictionary<string, List<Step>>();
        }

        public void AddOrigin(IList<Step> steps, string name, string author)
        {
            if (Steps.ContainsKey("0"))
            {
                return;
            }

            Steps.Add("0", new List<Step>());   
            
            foreach (var step in steps)
            {
                Steps["0"].Add(step);
            }

            //OriginViewModel.currScene = new Scene();

            Author = author;
            Name = name;
        }

        public void AddBranch(string treePath)
        {
            if (Steps.ContainsKey(treePath))
            {
                return;
            }
            
            Steps.Add(treePath, new List<Step>());
        }

        public void SetStepsForBranch(IList<Step> steps, string treePath)
        {
            Steps[treePath] = new List<Step>(steps);
        }
    }
}
