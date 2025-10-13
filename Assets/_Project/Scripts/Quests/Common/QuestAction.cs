using UnityEngine;

namespace Ludum.Quest.Common
{
    public class QuestAction
    {
        public bool Completed = false;
        public int NeededCount { get; set; }
        public int DoneCount = 0;

        protected void InitQuestAction()
        {
            Completed = false;
        }
        public void AddToDone(int value = 1)
        {
            DoneCount += value;
            if (DoneCount >= NeededCount)
            {
                Complete();
            }
        }
        public void Complete()
        {
            Completed = true;
        }

    }
}
