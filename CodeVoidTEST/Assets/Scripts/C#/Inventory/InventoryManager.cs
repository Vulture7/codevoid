using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryManager : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerUpHandler 
{

    public enum StorageType { Chest, Inventory }
    public List<GameObject> inventory;
    public Equipment equipment;

    public GameObject slot, Items;
    public StorageType type;
    public int inventoryType;

    void Start()
    {
        type = StorageType.Inventory;
        equipment = new Equipment();
        inventory = new List<GameObject>();
        inventoryType = 0;

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
        item.GetComponent<Item>().loadData(1, gameObject, "16");
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(8, gameObject, "17");
        inventory.Add(item);
	}

    void Update()
    {
        switch (inventoryType)
        {
            case 0:
                foreach (GameObject obj in inventory)
                {
                    if (!obj.GetComponent<Item>().drag)
                        obj.SetActive(true);
                }
                break;

            case 1:
                if (equipment.Primary != null && !equipment.Primary.GetComponent<Item>().drag)
                    equipment.Primary.SetActive(true);
                if (equipment.Secondary != null && !equipment.Secondary.GetComponent<Item>().drag)
                    equipment.Secondary.SetActive(true);
                if (equipment.Backpack != null && !equipment.Backpack.GetComponent<Item>().drag)
                    equipment.Backpack.SetActive(true);
                if (equipment.Extra != null && !equipment.Extra.GetComponent<Item>().drag)
                    equipment.Extra.SetActive(true);
                if (equipment.Head != null && !equipment.Head.GetComponent<Item>().drag)
                    equipment.Head.SetActive(true);
                if (equipment.Chest != null && !equipment.Chest.GetComponent<Item>().drag)
                    equipment.Chest.SetActive(true);
                if (equipment.Pants != null && !equipment.Pants.GetComponent<Item>().drag)
                    equipment.Pants.SetActive(true);
                if (equipment.Shoes != null && !equipment.Shoes.GetComponent<Item>().drag)
                    equipment.Shoes.SetActive(true);
                break;
        }
    }

    public void setVisible(int inventoryType)
    {
        this.inventoryType = inventoryType;

        if (type == StorageType.Chest)
        {
            GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Images/Inventory/Inventory-Background-Chest");
        }
        else if (inventoryType == 0)
        {
            GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Images/Inventory/Inventory-Background-Bag1");
        }
        else if (inventoryType == 1)
        {
            GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Images/Inventory/Inventory-Background-Bag2");
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (InventoryHelper.dragging != null && !inventory.Contains(InventoryHelper.dragging))
        {
            Debug.Log("WOOOOOOW");
            InventoryHelper.dragging.GetComponent<SlotManager>().changeParent(gameObject);
        }
    }
}
