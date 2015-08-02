using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    public int health = 100;
    public GameObject inventory;

    public Item itemInHands;
    public Item itemOnBack;

    void Start()
    {
        itemInHands = null;
    }

    void Update()
    {
        #region Doesn't work when in UI
        if (!transform.GetComponent<PlayerControl>().inManager)
        {
             if (Input.GetKeyDown(SettingValues.primaryKey))
            {
                //Run animation and wait for finish
                itemInHands = inventory.GetComponent<InventoryManager>().GetEquipmentItemAtPosition("primary");
                itemOnBack = inventory.GetComponent<InventoryManager>().GetEquipmentItemAtPosition("secondary");
                Debug.Log(itemInHands.Name);
            }
            if (Input.GetKeyDown(SettingValues.secondaryKey))
            {
                //Run animation and wait for finish
                itemInHands = inventory.GetComponent<InventoryManager>().GetEquipmentItemAtPosition("secondary");
                itemOnBack = inventory.GetComponent<InventoryManager>().GetEquipmentItemAtPosition("primary");
                Debug.Log(itemInHands.Name);
            }
        }
        #endregion

        #region Works when in UI
        if (Input.GetKeyDown(KeyCode.Escape)) 
        { 
            transform.GetComponent<PlayerControl>().inManager = false;
            foreach (GameObject ui in GameObject.FindGameObjectsWithTag("Popup"))
            {
                ui.SetActive(false);
            }
        }
        #endregion
    }



}
