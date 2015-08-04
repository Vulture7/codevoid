<<<<<<< HEAD
﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour {

    public static List<Item> inventory = new List<Item>();
    public static GameObject currentSlot;

    public GameObject slotArea;
    public GameObject slot;

    private int horzMax = 5;
    private int vertMax = 5;

	void Start () {
        inventory.Add(new Item(0));
        inventory.Add(new Item(0));

        float xCord = -249;
        float yCord = 161;
        int z = 0;

        for (int y = 0; y < vertMax; y++)
        {
            for (int x = 0; x < horzMax; x++)
            {
                GameObject newSlot = (GameObject)Instantiate(slot);
                RectTransform rect = newSlot.GetComponent<RectTransform>();
                newSlot.name = "Slot_" + y.ToString() + "." + x.ToString();
                newSlot.transform.SetParent(this.transform.parent);
                if (z < inventory.Count)
                {
                    newSlot.GetComponent<SlotManager>().currentItem = inventory[z];
                }
                rect.localPosition = new Vector3(xCord, yCord);
                xCord += 135;
                z++;
            }
            xCord = -249;
            yCord -= 80;
            z++;
        }
	}
}
=======
﻿using UnityEngine;
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
>>>>>>> origin/Test-Stack
