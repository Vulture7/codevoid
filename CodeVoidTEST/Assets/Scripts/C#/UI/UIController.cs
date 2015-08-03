using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour
{

    public GameObject manager;
    public GameObject chest;
    public GameObject inventory;
    public GameObject player;

    void Update()
    {
        if (Input.GetKeyDown(SettingValues.managerKey))
        {
            manager.SetActive(!manager.activeSelf);
            gameObject.GetComponent<PlayerControl>().inManager = manager.activeSelf;
        }
        else if (Input.GetKeyDown(SettingValues.chestKey))
        {
            if (!chest.activeSelf)
            {
                chest.SetActive(true);
                chest.GetComponentInChildren<InventoryManager>().type = InventoryManager.StorageType.Chest;
                chest.GetComponentInChildren<InventoryManager>().setVisible(0);
                gameObject.GetComponent<PlayerControl>().inManager = true;
            }
            else
            {
                chest.SetActive(false);
                gameObject.GetComponent<PlayerControl>().inManager = false;
            }
        }
        else if (Input.GetKeyDown(SettingValues.inventoryKeyInventory))
        {
            if (!inventory.activeSelf || inventory.GetComponentInChildren<InventoryManager>().inventoryType == 1)
            {
                inventory.SetActive(true);
                inventory.GetComponentInChildren<InventoryManager>().setVisible(0);
                gameObject.GetComponent<PlayerControl>().inManager = true;
            }
            else
            {
                inventory.SetActive(false);
                gameObject.GetComponent<PlayerControl>().inManager = false;
            }
        }
        else if (Input.GetKeyDown(SettingValues.inventoryKeyEquipment))
        {
            if (!inventory.activeSelf || inventory.GetComponentInChildren<InventoryManager>().inventoryType == 0)
            {
                inventory.SetActive(true);
                inventory.GetComponentInChildren<InventoryManager>().setVisible(1);
                gameObject.GetComponent<PlayerControl>().inManager = true;
            }
            else
            {
                inventory.GetComponentInChildren<InventoryManager>().CharacterPreview.SetActive(false);
                inventory.SetActive(false);
                gameObject.GetComponent<PlayerControl>().inManager = false;
            }
        }
    }


}