using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ViewManager : MonoBehaviour {

    private Transform lastLooked;
    private Transform lastHit;

<<<<<<< HEAD
    public GameObject questUI;
    public GameObject questManager;

    public GameObject NpcTargetedUI;
    public Image npcIcon;
    public Text npcName;
    public Text npcLevel;
    public Slider npcSlider;

=======
>>>>>>> origin/Test-Stack
    public Text interactText;

    void Update()
    {
<<<<<<< HEAD
=======
        //Item itemInHands = transform.parent.GetComponent<PlayerManager>().itemInHands;

>>>>>>> origin/Test-Stack
        #region OnLook
        RaycastHit hit;
        bool looking = true;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            lastHit = hit.transform;
            Debug.Log(hit.transform.tag);
            switch (hit.transform.tag)
            {
<<<<<<< HEAD
                case "QNPC":
                    if (hit.distance > 6f) { return; }
                    if (Input.GetKeyDown(SettingValues.interactKey)) { questUI.GetComponent<QuestUIManager>().ShowQuest(lastHit.GetComponent<QuestNpcManager>().quest); return; }
                    hit.transform.GetComponent<QuestNpcManager>().looking = true;
=======
                case "NPC":
                    if (hit.distance > 6f) { return; }
                    hit.transform.GetComponent<NpcManager>().looking = true;
>>>>>>> origin/Test-Stack
                    break;
                case "Crate":
                    if (hit.distance > 6f) { return; }
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
