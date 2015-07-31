using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour {

    public static List<Item> inventory = new List<Item>();
    public static GameObject currentSlot;
    public static GameObject selectedSlotA;

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
