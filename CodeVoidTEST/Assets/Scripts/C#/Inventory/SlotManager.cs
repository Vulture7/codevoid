using UnityEngine;
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
