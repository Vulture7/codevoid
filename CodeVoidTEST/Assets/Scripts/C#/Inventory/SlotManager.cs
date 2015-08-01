using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotManager : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        #region On InventoryItem Rightclick
        if (eventData.button != PointerEventData.InputButton.Right && eventData.button != PointerEventData.InputButton.Left) { return; }
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            GetComponent<Item>().drag = true;
        }
        #endregion
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        #region On InventoryItem Rightclick
        if (eventData.button != PointerEventData.InputButton.Right && eventData.button != PointerEventData.InputButton.Left) { return; }
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            GetComponent<Item>().drag = false;
            InventoryHelper.swapItemsOrDrop(gameObject, GetComponent<Item>().inventoryManager.GetComponent<InventoryManager>().inventory);
        }
        #endregion
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
    }
}
