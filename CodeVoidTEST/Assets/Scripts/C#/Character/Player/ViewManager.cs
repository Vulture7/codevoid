using UnityEngine;
using System.Collections;

public class ViewManager : MonoBehaviour {

    private Transform lastLooked;
    private Transform lastHit;

    public GameObject questUI;
    public GameObject questManager;

    void Update()
    {
        RaycastHit hit;
        bool looking = true;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            lastHit = hit.transform;
            switch (hit.transform.tag)
            {
                case "Target":
                    if (Input.GetMouseButtonDown(0)) { lastLooked.GetComponent<Target>().Damage(35); }
                    break;
                case "NPC":
                    if (hit.distance > 6f) { return; }
                    if (Input.GetKeyDown(KeyCode.E)) { questUI.GetComponent<QuestUIManager>().ShowQuest(lastHit.GetComponent<NpcManager>().quest); return; }
                    hit.transform.GetComponent<NpcManager>().looking = true;
                    break;
                default:
                    looking = false;
                    break;
            }
        }

        if (lastLooked != null && !looking)
        {
            switch (lastLooked.tag)
            {
                case "NPC":
                    lastLooked.GetComponent<NpcManager>().looking = false;
                    break;
            }
        }
        lastLooked = lastHit;
    }



}
