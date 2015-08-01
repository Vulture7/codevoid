using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour {

    public List<GameObject> inventory = new List<GameObject>();

    public GameObject slot, Items;

    void Start()
    {
        GameObject item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(0, gameObject, 0);
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(1, gameObject, 1);
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(0, gameObject, 2);
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(1, gameObject, 3);
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(0, gameObject, 4);
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(1, gameObject, 5);
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(0, gameObject, 6);
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(1, gameObject, 7);
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(1, gameObject, 8);
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(0, gameObject, 9);
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(1, gameObject, 10);
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(0, gameObject, 11);
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(1, gameObject, 12);
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(0, gameObject, 13);
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(1, gameObject, 14);
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(0, gameObject, 15);
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(1, gameObject, 16);
        inventory.Add(item);
	}
}
