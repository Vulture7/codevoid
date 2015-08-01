using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotManager : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler
{

    public Item currentItem, lastItem;
    public Item itemLastFrame;

    private EventTrigger eventTrigger;
    private bool hover = false;

    void Update()
    {
        #region Item icon changing
        if (itemLastFrame != currentItem)
        {
            if (currentItem == null) { transform.GetChild(0).GetComponent<Image>().enabled = false; return; }
            transform.GetChild(0).GetComponent<Image>().sprite = currentItem.Icon;
            transform.GetChild(0).GetComponent<Image>().enabled = true;
        }
        itemLastFrame = currentItem;
        #endregion
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        #region On InventoryItem Rightclick
        if (eventData.button != PointerEventData.InputButton.Right) { return; }
        switch (currentItem.ID)
        {
            case 0:
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().health += 50;
                break;
        }
        InventoryManager.inventory.Remove(currentItem);
        currentItem = null;
        #endregion
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        InventoryManager.currentSlot = gameObject;
    }
}
