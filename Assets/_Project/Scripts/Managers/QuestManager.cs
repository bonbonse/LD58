using Ludum.Quest.Common;
using System.Collections.Generic;
using UnityEngine;

namespace Ludum.Manager
{
    public class QuestManager : MonoBehaviour
    {
        private static QuestManager _instance;
        public QuestManager Instance { get { return _instance; } }
        public List<AbstractQuest> quests = new List<AbstractQuest>();

        private void Start()
        {
            _instance = this;
        }


        public AbstractQuest GetQuestByQuestName(string name)
        {
            foreach (AbstractQuest quest in quests)
            {
                if (quest.Name == name)
                {
                    return quest;
                }
            }
            return null;
        }

        public void DoQuestByName(string name, int doCount)
        {
            AbstractQuest abstractQuest = GetQuestByQuestName(name);
            if (abstractQuest != null)
            {
                abstractQuest.DoQuest(doCount);
            }
        }

    }
}
