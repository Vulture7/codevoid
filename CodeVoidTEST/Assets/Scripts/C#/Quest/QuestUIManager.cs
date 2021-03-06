﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestUIManager : MonoBehaviour {


    public Text uiTitle;
    public Text uiText;

    public GameObject questManager;
    public GameObject player;

    private Quest quest;



    public void ShowQuest(Quest quest)
    {
        this.quest = quest;
        uiTitle.text = quest.TITLE;
        if (quest.COMPLETED)
        {
            uiText.text = quest.ENDTEXT;
            transform.GetChild(transform.childCount-1).transform.gameObject.SetActive(false);
            transform.GetChild(transform.childCount-2).transform.gameObject.SetActive(false);
            gameObject.SetActive(true);
            return;
        }
        else { uiText.text = quest.TEXT; }
        //Quest exists, remove the accept button.
        if (questManager.GetComponent<QuestManager>().GetQuest(quest.UID) != null) { transform.GetChild(transform.childCount -2).transform.gameObject.SetActive(false); transform.GetChild(transform.childCount-1).transform.gameObject.SetActive(true); }
        else { transform.GetChild(transform.childCount-2).transform.gameObject.SetActive(true); transform.GetChild(transform.childCount-1).transform.gameObject.SetActive(true); }
        player.GetComponent<PlayerControl>().inManager = true;
        gameObject.SetActive(true);
    }

    public void Accept()
    {
        questManager.GetComponent<QuestManager>().AddQuest(quest);
        Close();
    }

    public void Decline()
    {
        if (questManager.GetComponent<QuestManager>().GetQuest(quest.UID) != null) { questManager.GetComponent<QuestManager>().RemoveQuest(quest.UID); }
        Close();
    }

    public void Close()
    {
        player.GetComponent<PlayerControl>().inManager = false;
        gameObject.SetActive(false);
    }

}
