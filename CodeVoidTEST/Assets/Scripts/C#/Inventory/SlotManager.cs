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
        if (eventData.button == PointerEventData.InputButton.Left && !GetComponent<Item>().context)
        {
            GetComponent<Item>().drag = true;
            InventoryHelper.dragging = gameObject;
        }
        else if (eventData.button == PointerEventData.InputButton.Right && !GetComponent<Item>().context)
        {
            if (!GetComponent<Item>().drag)
            {
                GetComponent<Item>().context = true;
                GetComponent<Item>().contextPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
            }
        }
        foreach (GameObject obj in GetComponent<Item>().inventoryManager.GetComponent<InventoryManager>().inventory)
        {
            if (obj != gameObject)
                obj.GetComponent<Item>().context = false;
        }
        #endregion
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        #region
        Item item = GetComponent<Item>();
        if (eventData.button != PointerEventData.InputButton.Right && eventData.button != PointerEventData.InputButton.Left) { return; }
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            int type = item.inventoryManager.GetComponent<InventoryManager>().inventoryType;
            if (type == 0)
            {
                if (GetComponent<Item>().invType != 0)
                {
                    InventoryHelper.SetEqSwitch(item.Position, null, GetComponent<Item>().inventoryManager.GetComponent<InventoryManager>().equipment);
                    GetComponent<Item>().inventoryManager.GetComponent<InventoryManager>().inventory.Add(gameObject);
                }
                InventoryHelper.swapItemsOrDrop(gameObject, item.inventoryManager.GetComponent<InventoryManager>().inventory);
            }
            else if (type == 1)
            {
                InventoryHelper.swapEqOrPlace(gameObject, item.inventoryManager.GetComponent<InventoryManager>().equipment);
            }
            item.drag = false;
            InventoryHelper.dragging = null;
        }
        #endregion
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
    }

    public void changeParent(GameObject newParent)
    {
        GetComponent<Item>().inventoryManager.GetComponent<InventoryManager>().inventory.Remove(gameObject);
        GetComponent<Item>().inventoryManager = newParent;
    }
}
