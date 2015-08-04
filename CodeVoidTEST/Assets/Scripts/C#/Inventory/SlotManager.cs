<<<<<<< HEAD
﻿using UnityEngine;
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
=======
﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotManager : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        #region
        if (eventData.button != PointerEventData.InputButton.Right && eventData.button != PointerEventData.InputButton.Left) { return; }
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            GetComponent<Item>().drag = true;
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            GetComponent<Item>().context = true;
        }
        #endregion
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Item item = GetComponent<Item>();
        #region
        if (eventData.button != PointerEventData.InputButton.Right && eventData.button != PointerEventData.InputButton.Left) { return; }
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            int type = item.inventoryManager.GetComponent<InventoryManager>().inventoryType;
            if (type == 0)
            {
                if (GetComponent<Item>().invType != 0)
                {
                    GetComponent<Item>().inventoryManager.GetComponent<InventoryManager>().equipment.Remove(gameObject);
                    GetComponent<Item>().inventoryManager.GetComponent<InventoryManager>().inventory.Add(gameObject);
                }
                item.dragFail = InventoryHelper.swapItemsOrDrop(gameObject, item.inventoryManager.GetComponent<InventoryManager>().inventory);
            }
            else if (type == 1)
            {
                string dropTo = InventoryHelper.checkEqPos(gameObject, true);
                if (dropTo != "")
                {
                    item.Position = dropTo;
                    GetComponent<Item>().inventoryManager.GetComponent<InventoryManager>().equipment.Add(gameObject);
                    GetComponent<Item>().inventoryManager.GetComponent<InventoryManager>().inventory.Remove(gameObject);
                }
                else
                    item.dragFail = true;
            }
            item.drag = false;
        }
        #endregion
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
    }
}
>>>>>>> origin/Test-Stack
