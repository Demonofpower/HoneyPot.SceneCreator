using System.Collections;
using System.Collections.Generic;
using HoneyPot.SceneCreator.GUI.SceneObjects;

namespace HoneyPot.SceneCreator.GUI.Helper
{
    public class StepViewRefreshList : IList<Step>
    {
        private readonly List<Step> innerList;

        public StepViewRefreshList()
        {
            innerList = new List<Step>();
        }

        public IEnumerator<Step> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        public void Add(Step item)
        {
            innerList.Add(item);
            MainWindow.UpdateStepsList();
        }

        public void Clear()
        {
            innerList.Clear();
            MainWindow.UpdateStepsList();
        }

        public bool Contains(Step item)
        {
            return innerList.Contains(item);
        }

        public void CopyTo(Step[] array, int arrayIndex)
        {
            innerList.CopyTo(array, arrayIndex);
            MainWindow.UpdateStepsList();
        }

        public bool Remove(Step item)
        {
            var successful = innerList.Remove(item);
            MainWindow.SortStepList();
            MainWindow.UpdateStepsList();
            return successful;
        }

        public int Count => innerList.Count;
        public bool IsReadOnly => false;
        public int IndexOf(Step item)
        {
            return innerList.IndexOf(item);
        }

        public void Insert(int index, Step item)
        {
            innerList.Insert(index, item);
            MainWindow.UpdateStepsList();
        }

        public void RemoveAt(int index)
        {
            if (index == -1) return;
            
            innerList.RemoveAt(index);
            MainWindow.SortStepList();
            MainWindow.UpdateStepsList();
        }

        public Step this[int index]
        {
            get => innerList[index];
            set
            {
                innerList[index] = value;
                MainWindow.UpdateStepsList();
            }
        }
    }
}
