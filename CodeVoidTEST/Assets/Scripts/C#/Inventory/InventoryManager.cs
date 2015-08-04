using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryManager : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerUpHandler 
{

    public enum StorageType { Chest, Inventory }
    public List<GameObject> inventory;
    public Equipment equipment;

    public GameObject slot = null, Items = null, CharacterPreview = null, canvas = null, player = null, camera = null, itemName = null, itemLore = null;
    public StorageType type = StorageType.Inventory;
    public int inventoryType = 0;

    private Vector3 lastMousePos = new Vector3(0, 0);
    private bool dragging = false, dragChar = false;
    private float rotationSpeed = 300.0F;

    void Start()
    {
        GetComponentInParent<RectTransform>().localPosition = GetComponent<RectTransform>().sizeDelta; 
        equipment = new Equipment();
        inventory = new List<GameObject>();
        if (camera != null)
            camera.GetComponent<Camera>().orthographicSize = canvas.GetComponent<RectTransform>().position.y;
        if (itemName != null)
            itemName.GetComponent<RectTransform>().localPosition = new Vector3(InventoryHelper.ItemNameX, InventoryHelper.ItemNameY);
        if (itemLore != null)
            itemLore.GetComponent<RectTransform>().localPosition = new Vector3(InventoryHelper.ItemLoreX, InventoryHelper.ItemLoreY);

        GameObject item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(0, gameObject, "0");
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(1, gameObject, "1");
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(0, gameObject, "2");
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(1, gameObject, "3");
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(0, gameObject, "4");
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(1, gameObject,"5");
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(0, gameObject,"6");
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(1, gameObject, "7");
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(7, gameObject, "8");
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(6, gameObject, "9");
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(5, gameObject, "10");
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(4, gameObject, "11");
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(3, gameObject, "12");
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(2, gameObject, "13");
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(2, gameObject, "14");
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(0, gameObject, "15");
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(9, gameObject, "16");
        inventory.Add(item);
        item = (GameObject)Instantiate(slot);
        item.GetComponent<Item>().loadData(8, gameObject, "17");
        inventory.Add(item);
	}

    void Update()
    {
        updManager();
        if (dragChar)
        {
            float angle = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            player.GetComponent<Transform>().Rotate(new Vector3(0, -angle, 0));
        }
        if (dragging)
        {
            Vector3 difference = Input.mousePosition - lastMousePos;
            gameObject.GetComponent<RectTransform>().position += difference;
            lastMousePos = Input.mousePosition;
        }
        switch (inventoryType)
        {
            case 0:
                foreach (GameObject obj in inventory)
                {
                    if (!obj.GetComponent<Item>().drag)
                        obj.SetActive(true);
                }
                if (CharacterPreview != null)
                    CharacterPreview.SetActive(false);
                break;

            case 1:
                if (equipment.Primary != null && !equipment.Primary.GetComponent<Item>().drag)
                    equipment.Primary.SetActive(true);
                if (equipment.Secondary != null && !equipment.Secondary.GetComponent<Item>().drag)
                    equipment.Secondary.SetActive(true);
                if (equipment.Backpack != null && !equipment.Backpack.GetComponent<Item>().drag)
                    equipment.Backpack.SetActive(true);
                if (equipment.Extra != null && !equipment.Extra.GetComponent<Item>().drag)
                    equipment.Extra.SetActive(true);
                if (equipment.Head != null && !equipment.Head.GetComponent<Item>().drag)
                    equipment.Head.SetActive(true);
                if (equipment.Chest != null && !equipment.Chest.GetComponent<Item>().drag)
                    equipment.Chest.SetActive(true);
                if (equipment.Pants != null && !equipment.Pants.GetComponent<Item>().drag)
                    equipment.Pants.SetActive(true);
                if (equipment.Shoes != null && !equipment.Shoes.GetComponent<Item>().drag)
                    equipment.Shoes.SetActive(true);
                if (CharacterPreview != null)
                    CharacterPreview.SetActive(true);
                break;
        }
    }

    private void setCharacter()
    {
        if (CharacterPreview != null)
            CharacterPreview.transform.GetChild(0).GetComponent<RectTransform>().localPosition = new Vector3(InventoryHelper.PreviewX, InventoryHelper.PreviewY);
        if (player != null)
        {
            player.transform.localPosition = new Vector3(0, InventoryHelper.PlayerY, -800);
            player.transform.localScale = new Vector3(InventoryHelper.PlayerScalX, InventoryHelper.PlayerScalY, InventoryHelper.PlayerScalZ);
        }

        Debug.Log(CharacterPreview.transform.GetChild(0).GetComponent<RectTransform>().localPosition);

    }

    void updManager()
    {
        if (type == StorageType.Chest)
        {
            GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Inventory/Inventory-Background-Chest");
        }
        else if (inventoryType == 0)
        {
            GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Images/Inventory/Inventory-Background-Bag1");
        }
        else if (this.inventoryType == 1)
        {
            GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Images/Inventory/Inventory-Background-Bag2");
        }
        else if (inventoryType == 2)
        {
            GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Images/Inventory/Inventory-Background-Bag3");
        }
        else if (this.inventoryType == 3)
        {
            GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Images/Inventory/Inventory-Background-Bag4");
        }
    }

    public void setVisible(int inventoryType)
    {
        this.inventoryType = inventoryType;

        if (CharacterPreview != null)                
            CharacterPreview.SetActive(true);
        if (inventoryType == 1)
            setCharacter();

        updManager();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        int clickOnSwitch = InventoryHelper.checkClickOnSwitch(Input.mousePosition, GetComponent<RectTransform>().position);
        if (eventData.button == PointerEventData.InputButton.Left && clickOnSwitch != -1)
        {
            inventoryType = clickOnSwitch;
        }
        else if (eventData.button == PointerEventData.InputButton.Left)
        {
            dragging = true;
            lastMousePos = Input.mousePosition;
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (inventoryType == 1)
            {
                Vector3 pos = gameObject.GetComponent<RectTransform>().position;
                Vector3 position = Input.mousePosition;
                if (position.x > pos.x + InventoryHelper.charPosX && position.x < pos.x + InventoryHelper.charPosEndX && position.y < pos.y + InventoryHelper.charPosY && position.y > pos.y + InventoryHelper.charPosEndY)
                {
                    dragChar = true;
                }
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            dragging = false;
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            dragChar = false;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (InventoryHelper.dragging != null && !inventory.Contains(InventoryHelper.dragging))
        {
            if (eventData.pointerEnter != InventoryHelper.dragging.GetComponent<Item>().inventoryManager)
            {
                InventoryHelper.dragging.GetComponent<SlotManager>().changeParent(gameObject);
            }
        }
    }
}
