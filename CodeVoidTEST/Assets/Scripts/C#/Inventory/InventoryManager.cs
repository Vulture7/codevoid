using UnityEngine;
using System.Collections;

public class InventoryManager : MonoBehaviour {

    public GameObject slotArea;
    public GameObject slot;

    private int horzMax = 5;
    private int vertMax = 5;

	void Start () {
        float xCord = -249;
        float yCord = 161;

        for (int y = 0; y < vertMax; y++)
        {
            for (int x = 0; x < horzMax; x++)
            {
                GameObject newSlot = (GameObject)Instantiate(slot);
                RectTransform rect = newSlot.GetComponent<RectTransform>();
                newSlot.name = "Slot_" + y.ToString() + "." + x.ToString();
                newSlot.transform.SetParent(this.transform.parent);
                rect.localPosition = new Vector3(xCord, yCord);
                xCord += 135;
            }
            xCord = -249;
            yCord -= 80;
        }
	}
}
