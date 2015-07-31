using UnityEngine;
using System.Collections;

public class ContextManager : MonoBehaviour {

    public GameObject inventoryManager;

    public void Use()
    {
        Item item = InventoryManager.currentSlot.GetComponent<SlotManager>().currentItem;

        
    }

}
