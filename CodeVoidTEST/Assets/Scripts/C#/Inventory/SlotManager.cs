using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotManager : MonoBehaviour, IPointerExitHandler, IPointerDownHandler, IPointerEnterHandler
{

    public Item currentItem, lastItem;
    public Item itemLastFrame;
    private GameObject contextMenu;

    private EventTrigger eventTrigger;
    private bool hover = false;

    public void SwapItem(GameObject slot)
    {
        lastItem = currentItem;
        slot.GetComponent<SlotManager>().lastItem = slot.GetComponent<SlotManager>().currentItem;
        currentItem = slot.GetComponent<SlotManager>().lastItem;
        slot.GetComponent<SlotManager>().currentItem = lastItem;
    }

    void Start()
    {
        contextMenu = GameObject.FindGameObjectWithTag("ContextMenu");
    }

    void Update()
    {
        if (itemLastFrame != currentItem)
        {
            if (currentItem == null) { transform.GetChild(0).GetComponent<Image>().enabled = false; }
            transform.GetChild(0).GetComponent<Image>().sprite = currentItem.Icon;
            transform.GetChild(0).GetComponent<Image>().enabled = true;
        }
        itemLastFrame = currentItem;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        contextMenu.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Right) { return; }
        switch (currentItem.ID)
        {
            case 0:
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().health += 50;
                break;
        }


        InventoryManager.inventory.Remove(currentItem);
        currentItem = null;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        InventoryManager.currentSlot = gameObject;
    }
}
