using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour {

    public static List<GameObject> inventory = new List<GameObject>();
    public static int removedPos = -1;
    public bool menu = false;
    public GameObject slot;

    public static int horzMax = 5;
    public static int vertMax = 5;

	void Start () {
        inventory.Add((GameObject)Instantiate(slot));
        inventory.Add((GameObject)Instantiate(slot));

        int x = 0;
        int y = 0;
        for (int i = 0 ; i < inventory.Count; i++)
        {
            if (x < horzMax)
            {
                inventory[i].GetComponent<Item>().loadInformation(0, i, x, y);
                inventory[i].transform.SetParent(this.transform.parent);
                x++;
            }
            else
            {
                x = 0;
                if (y < vertMax)
                    y++;
                else
                    break;
            }
        }
	}

    void Update()
    {
        if (menu)
        {
            foreach (GameObject obj in inventory)
            {
                if (!obj.activeSelf)
                    obj.SetActive(true);
            }
            int x = 0;
            int y = 0;
            if (removedPos != -1)
            {
                for (int i = 0; i < inventory.Count; i++)
                {
                    if (x < horzMax)
                    {
                        inventory[i].GetComponent<Item>().position = i;
                        x++;
                    }
                    else
                    {
                        x = 0;
                        if (y < vertMax)
                            y++;
                        else
                            break;
                    }
                }
                removedPos = -1;
            }
        }
        else
        {
            foreach(GameObject obj in inventory)
            {
                if (obj.activeSelf)
                    obj.SetActive(false);
            }
        }
    }
}
