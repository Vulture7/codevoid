using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ViewManager : MonoBehaviour {

    private Transform lastLooked;
    private Transform lastHit;

    public GameObject questUI;
    public GameObject questManager;

    public Text interactText;

    void Update()
    {
        #region OnLook
        RaycastHit hit;
        bool looking = true;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            lastHit = hit.transform;
            switch (hit.transform.tag)
            {
                case "NPC":
                    if (hit.distance > 6f) { return; }
                    if (Input.GetKeyDown(SettingValues.interactKey)) { questUI.GetComponent<QuestUIManager>().ShowQuest(lastHit.GetComponent<NpcManager>().quest); return; }
                    hit.transform.GetComponent<NpcManager>().looking = true;
                    break;
                case "Crate":
                    if (hit.distance > 6f) { return; }
                    if (Input.GetKeyDown(SettingValues.interactKey)) { return; }
                    hit.transform.GetComponent<CrateManager>().looking = true;
                    break;
                default:
                    looking = false;
                    break;
            }
        }
        #endregion

        #region LastLooked
        if (lastLooked != null && !looking)
        {
            switch (lastLooked.tag)
            {
                case "NPC":
                    lastLooked.GetComponent<NpcManager>().looking = false;
    
                    break;
                case "Crate":
                    lastLooked.GetComponent<CrateManager>().looking = false;
                    interactText.enabled = false;
                    break;
            }
        }
        lastLooked = lastHit;
        #endregion
    }



}
