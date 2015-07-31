using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotManager : MonoBehaviour, IPointerExitHandler, IPointerDownHandler, IPointerEnterHandler, IPointerUpHandler
{
    private GameObject contextMenu;
    private EventTrigger eventTrigger;

    private bool hover = false;
    private float xCord = -249;
    private float yCord = 161;
    private float xWidth = 135;
    private float yHeight = -80;
    private float itemX = 50;
    private float itemY = 50;

    void Start()
    {
        contextMenu = GameObject.FindGameObjectWithTag("ContextMenu");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        contextMenu.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Right && eventData.button != PointerEventData.InputButton.Left) { return; }
        for (int x = 0; x < InventoryManager.horzMax; x++ )
        {
            for (int y = 0; y < InventoryManager.vertMax; y++)
            {
                if (Input.mousePosition.x > xCord + (x * xWidth) && Input.mousePosition.x < xCord + (x * xWidth) + itemX && Input.mousePosition.y > yCord + (y * yHeight) && Input.mousePosition.y < yCord + (y * yHeight) + itemY)
                {
                    foreach (GameObject obj in InventoryManager.inventory)
                    {
                        if (obj.GetComponent<RectTransform>().position.x == xCord + (x * xWidth) && obj.GetComponent<RectTransform>().position.y > yCord + (y * yHeight))
                        {
                            if (eventData.button == PointerEventData.InputButton.Left)
                            {
                                obj.GetComponent<Item>().Drag = true;
                            }
                            else if (eventData.button == PointerEventData.InputButton.Right)
                            {
                                switch (obj.GetComponent<Item>().ID)
                                {
                                    case 0:
                                        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().health += 50;
                                        InventoryManager.removedPos = obj.GetComponent<Item>().position;
                                        InventoryManager.inventory.Remove(obj);
                                        break;
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left) { return; }
        for (int x = 0; x < InventoryManager.horzMax; x++)
        {
            for (int y = 0; y < InventoryManager.vertMax; y++)
            {
                if (Input.mousePosition.x > xCord + (x * xWidth) && Input.mousePosition.x < xCord + (x * xWidth) + itemX && Input.mousePosition.y > yCord + (y * yHeight) && Input.mousePosition.y < yCord + (y * yHeight) + itemY)
                {
                    int posA = -1;
                    int posB = -1;
                    foreach (GameObject obj in InventoryManager.inventory)
                    {
                        if (obj.GetComponent<Item>().Drag)
                        {
                            posA = obj.GetComponent<Item>().position;
                        }
                        else if(obj.GetComponent<RectTransform>().position.x > xCord + (x * xWidth) && obj.GetComponent<RectTransform>().position.y > yCord + (y * yHeight))
                        {
                            posB = obj.GetComponent<Item>().position;
                        }
                    }
                    if (posA != -1 && posB != -1)
                    {
                        InventoryManager.inventory[posA].GetComponent<Item>().Drag = false;
                        GameObject a = InventoryManager.inventory[posA];
                        InventoryManager.inventory[posA] = InventoryManager.inventory[posB];
                        InventoryManager.inventory[posA].GetComponent<Item>().position = posA;
                        InventoryManager.inventory[posB] = a;
                        InventoryManager.inventory[posB].GetComponent<Item>().position = posB;
                    }
                }
            }
        }
    }
}
