using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ViewManager : MonoBehaviour {

    private Transform lastLooked;
    private Transform lastHit;

    public GameObject questUI;
    public GameObject questManager;

    public GameObject NpcTargetedUI;
    public Image npcIcon;
    public Text npcName;
    public Text npcLevel;
    public Slider npcSlider;

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
                case "QNPC":
                    if (hit.distance > 6f) { return; }
                    if (Input.GetKeyDown(SettingValues.interactKey)) { questUI.GetComponent<QuestUIManager>().ShowQuest(lastHit.GetComponent<QuestNpcManager>().quest); return; }
                    hit.transform.GetComponent<QuestNpcManager>().looking = true;
                    break;
                case "Crate":
                    if (hit.distance > 6f) { return; }
                    if (Input.GetKeyDown(SettingValues.interactKey)) { return; }
                    hit.transform.GetComponent<CrateManager>().looking = true;
                    break;
                case "NPC":
                    NpcManager npcManager = hit.transform.GetComponent<NpcManager>();
                    npcIcon.sprite = npcManager.icon;
                    npcName.text = npcManager.name;
                    npcLevel.text = npcManager.level.ToString();
                    npcSlider.value = npcManager.health;
                    NpcTargetedUI.SetActive(true);
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
                case "QNPC":
                    lastLooked.GetComponent<QuestNpcManager>().looking = false;
                    interactText.enabled = false;
                    break;
                case "Crate":
                    lastLooked.GetComponent<CrateManager>().looking = false;
                    interactText.enabled = false;
                    break;
                case "NPC":
                    NpcTargetedUI.SetActive(false);
                    break;
            }
        }
        lastLooked = lastHit;
        #endregion
    }



}
