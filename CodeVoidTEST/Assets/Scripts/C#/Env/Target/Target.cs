using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

    private int health = 100;
    public GameObject questManager;

    public void Damage(int amount)
    {
        Debug.Log("HITTT");
        if (questManager.GetComponent<QuestManager>().GetQuest(0) == null) { Debug.Log("Quest not accepted yet! Ignoring shot."); return; }
        health -= amount;
        if (health < 1) { questManager.GetComponent<QuestManager>().CompleteQuest(0); Destroy(gameObject); }
    }

}
