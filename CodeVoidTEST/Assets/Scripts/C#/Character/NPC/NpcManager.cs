using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NpcManager : MonoBehaviour {

    public Text interactText;
    public bool looking = false;

    public Quest quest;
    public GameObject questUI;

    void Start()
    {
        quest = new Quest(0, "Target Practice", "Hello there! I need you to test your aim on that target over there a few times. Once you break it come back over.", "Great shooting! Sorry to say, but there's no reward bud.");
    }

    void Update()
    {
        if (looking) { interactText.enabled = true; }
        if (looking && Input.GetKeyDown(SettingValues.interactKey))
        {
            questUI.GetComponent<QuestUIManager>().ShowQuest(quest);
        }
    }
}
