using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestUIManager : MonoBehaviour {


    public Text uiTitle;
    public Text uiText;

    public GameObject questManager;

    private Quest quest;

    public void ShowQuest(Quest quest)
    {
        this.quest = quest;
        uiTitle.text = quest.TITLE;
        if (quest.COMPLETED)
        {
            uiText.text = "Nice shooting! I'm afraid I lied. I don't have anything to give you. But thanks!";
            //GiVE REWARDS
        }
        else { uiText.text = quest.TEXT; }   
        gameObject.SetActive(true);
    }

    public void Accept()
    {
        questManager.GetComponent<QuestManager>().AddQuest(quest);
        gameObject.SetActive(false);
    }

    public void Decline()
    {
        gameObject.SetActive(false);
    }

}
