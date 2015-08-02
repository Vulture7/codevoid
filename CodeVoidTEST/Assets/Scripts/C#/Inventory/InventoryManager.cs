using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {

    public List<GameObject> inventory = new List<GameObject>();
    public List<GameObject> equipment = new List<GameObject>();

    public GameObject slot, Items;
    public int inventoryType = 0;

    void Start()
    {
        GameObject item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(0, gameObject, "0");
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(1, gameObject, "1");
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(0, gameObject, "2");
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(1, gameObject, "3");
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(0, gameObject, "4");
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(1, gameObject,"5");
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(0, gameObject,"6");
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(1, gameObject, "7");
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(7, gameObject, "8");
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(6, gameObject, "9");
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(5, gameObject, "10");
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(4, gameObject, "11");
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(3, gameObject, "12");
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(2, gameObject, "13");
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(2, gameObject, "14");
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(0, gameObject, "15");
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(8, gameObject, "16");
        inventory.Add(item);
	}

    void Update()
    {
        if (Input.GetKey(SettingValues.managerKeyEquipment))
        {
            inventoryType = 1;
            GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Inventory/Inventory-Background-Bag2");
        }
        else if (Input.GetKey(SettingValues.managerKeyInventory))
        {
            inventoryType = 0;
            GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Inventory/Inventory-Background-Bag1");
        }

        switch (inventoryType)
        {
            case 0:
                foreach (GameObject obj in inventory)
                {
                    obj.SetActive(true);
                }
                break;

            case 1:
                foreach (GameObject obj in equipment)
                {
                    obj.SetActive(true);
                }
                break;
        }
    }

    public Item GetEquipmentItemAtPosition(string position)
    {
        foreach (GameObject item in equipment)
        {
            Item i = item.GetComponent<Item>();
            if (i.Position == position)
            {
                return i;
            }
        }
        Debug.LogWarning("Equiptment Item not found @ position: " + position);
        return null;
    }
    
}
