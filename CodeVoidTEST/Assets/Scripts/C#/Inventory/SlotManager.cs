using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotManager : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerUpHandler, IPointerExitHandler
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
            int inventoryType = item.inventoryManager.GetComponent<InventoryManager>().inventoryType;
            InventoryManager.StorageType type = item.inventoryManager.GetComponent<InventoryManager>().type;
            if (type == InventoryManager.StorageType.Chest)
            {
                InventoryHelper.swapItemsOrDrop(gameObject, item.inventoryManager.GetComponent<InventoryManager>().inventory);
            }
            else
            {
                if (inventoryType == 0)
                {
                    if (GetComponent<Item>().invType != 0)
                    {
                        InventoryHelper.SetEqSwitch(item.Position, null, GetComponent<Item>().inventoryManager.GetComponent<InventoryManager>().equipment);
                        GetComponent<Item>().inventoryManager.GetComponent<InventoryManager>().inventory.Add(gameObject);
                    }
                    InventoryHelper.swapItemsOrDrop(gameObject, item.inventoryManager.GetComponent<InventoryManager>().inventory);
                }
                else if (inventoryType == 1)
                {
                    InventoryHelper.swapEqOrPlace(gameObject, item.inventoryManager.GetComponent<InventoryManager>().equipment);
                }
            }
            item.drag = false;
            InventoryHelper.dragging = null;
        }
        #endregion
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Item item = GetComponent<Item>();
        Text name = item.inventoryManager.GetComponent<InventoryManager>().itemName.GetComponent<Text>();
        Text lore = item.inventoryManager.GetComponent<InventoryManager>().itemLore.GetComponent<Text>();

        name.text = item.Name;
        lore.text = item.Lore;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Item item = GetComponent<Item>();
        Text name = item.inventoryManager.GetComponent<InventoryManager>().itemName.GetComponent<Text>();
        Text lore = item.inventoryManager.GetComponent<InventoryManager>().itemLore.GetComponent<Text>();

        name.text = "";
        lore.text = "";
    }

    public void changeParent(GameObject newParent)
    {
        GetComponent<Item>().inventoryManager.GetComponent<InventoryManager>().inventory.Remove(gameObject);
        GetComponent<RectTransform>().SetParent(newParent.transform);
        GetComponent<Item>().inventoryManager = newParent;
        GetComponent<Item>().inventoryManager.GetComponent<InventoryManager>().inventory.Add(gameObject);
    }
}
