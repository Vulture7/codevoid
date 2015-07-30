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

    public Quest GetQuest(int uid)
    {
        foreach (Quest quest in quests)
        {
            if (quest.UID == uid)
            {
                return quest;
            }
        }
        Debug.LogWarning("Could not find Quest: " + uid);
        return null;
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
