using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuestManager : MonoBehaviour {

    public List<Quest> quests = new List<Quest>();

    public void AddQuest(Quest quest)
    {
        quests.Add(quest);
    }

    public void RemoveQuest(int uid)
    {
        foreach (Quest quest in quests)
        {
            if (quest.UID == uid)
            {
                quests.Remove(quest);
            }
        }
    }

    public void CompleteQuest(int uid)
    {
        foreach (Quest quest in quests)
        {
            if (quest.UID == uid)
            {
                quest.COMPLETED = true;
            }
        }
    }
}
