using System.Collections.Generic;
using UnityEngine;

namespace Ludum.Quest.Common
{
    public abstract class AbstractQuest
    {
        [SerializeField] public abstract string Name { get; }
        public List<QuestAction> questActions = new List<QuestAction>();
        protected QuestAction currenctQuestAction = null;

        public bool Completed = false;

        public void AcceptQuest()
        {
            Completed = false;
            if (questActions.Count > 0)
            {
                currenctQuestAction = questActions[0];
            } else
            {
                Debug.LogError("У квеста нет заданий");
            }
        }
        public void CompleteQuest()
        {
            Completed = true;
        }

        public void DoQuest(int doCount)
        {
            if (!Completed)
            {
                currenctQuestAction.AddToDone(doCount);
                if (currenctQuestAction.Completed)
                {

                }
            }
            
        }
    }
}

