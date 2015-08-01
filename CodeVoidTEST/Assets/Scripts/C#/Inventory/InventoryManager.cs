using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour {

    public List<GameObject> inventory = new List<GameObject>();

    public GameObject slot;

	void Start () {
        GameObject item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(0, gameObject, 0);
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(1, gameObject, 1);
        inventory.Add(item);
	}
}
