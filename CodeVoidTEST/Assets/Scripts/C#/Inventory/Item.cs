using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Item : MonoBehaviour {

    public enum ItemType { Consume,Stat,Weapon,ERROR, Head, Chest, Pants, Shoes, Backpack, Extra, Hack }
    public GameObject inventoryManager;
    public bool drag = false, context = false;
    public bool dragFail = false;
    public int invType = 0;
    public Vector3 contextPos;

    private int id;
    private string nme, lore;
    private ItemType type;
    private string position;

    #region GuiData
    private float buttonX = 120f, buttonY = 20;
    #endregion

    public void loadData(int id, GameObject area, string position)
    {
        this.position = position;
        this.inventoryManager = area;
        GetComponent<RectTransform>().SetParent(area.GetComponent<InventoryManager>().Items.transform, true);
        switch (id)
        {
            case 0:
                nme = "Med Syringer";
                lore = "Used for healing.";
                type = ItemType.Consume;
                GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Items/Consume/Resource_MedSyringer-Blue.2d");   
                break;
            case 1:
                nme = "Med Syringer";
                lore = "Used for healing.";
                type = ItemType.Consume;
                GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Items/Consume/Resource_MedSyringer-Red.2d");      
                break;
            case 2:
                nme = "Machine Gun";
                lore = "Used for killing.";
                type = ItemType.Weapon;
                GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Items/Weapons/machinegun_test");  
                break;
            case 3:
                nme = "Helmet";
                lore = "Used for Protecting.";
                type = ItemType.Head;
                GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Items/Armor/helmet_test");           
                break;
            case 4:
                nme = "Chest";
                lore = "Used for Protecting.";
                type = ItemType.Chest;
                GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Items/Armor/chestplate_test");              
                break;
            case 5:
                nme = "Pants";
                lore = "Used for Protecting.";
                type = ItemType.Pants;
                GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Items/Armor/pants_test");
                break;
            case 6:
                nme = "Shoes";
                lore = "Used for Protecting.";
                type = ItemType.Shoes;
                GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Items/Armor/shoes_test");
                break;
            case 7:
                nme = "Backpack";
                lore = "Used for Carrying stuff.";
                type = ItemType.Backpack;
                GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Items/Backpacks/backpack_test");  
                break;
            case 8:
                nme = "Cracker";
                lore = "Used for hacking past locks.";
                type = ItemType.Weapon;
                GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Items/Hack/cracker");
                break;
            case 8:
                nme = "Machine Gun2";
                lore = "Used for killing.";
                type = ItemType.Weapon;
                GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Items/Weapons/machinegun2_test");
                Debug.Log(GetComponent<Image>().sprite.ToString());
                break;
            default:
                nme = "ERROR";
                lore = "Unknown itemID: " + id.ToString();
                type = ItemType.ERROR;
                break;
        }
        this.id = id;
    }

    void Update()
    {
        if (position == "17" || position == "primary")
            Debug.Log(position);
        if (!drag)
        {
            updPosition();
            if (invType != inventoryManager.GetComponent<InventoryManager>().inventoryType)
                gameObject.SetActive(false);
        }
        else if (drag)
        {
            InventoryHelper.followMouse(gameObject);
        }
    }

    void OnGUI()
    {
        if (context)
        {
            float posX = contextPos.x;
            float posY = Screen.height - contextPos.y;

            if (type == ItemType.Shoes || type == ItemType.Head || type == ItemType.Chest || type == ItemType.Pants || type == ItemType.Backpack)
            {
                GUI.Box(new Rect(posX, posY, buttonX, (buttonY * 2)), "");
                if (GUI.Button(new Rect(posX, posY, buttonX, buttonY), "Equip"))
                {
                    Equip();
                }
                if (GUI.Button(new Rect(posX, posY + buttonY, buttonX, buttonY), "Drop"))
                {
                    Drop();
                }
            }
            else if (type == ItemType.Weapon)
            {
                GUI.Box(new Rect(posX, posY, buttonX, (buttonY * 3)), "");
                if (GUI.Button(new Rect(posX, posY, buttonX, buttonY), "Equip Primary"))
                {
                    EquipPrim();
                }
                if (GUI.Button(new Rect(posX, posY + buttonY, buttonX, buttonY), "Equip Secondary"))
                {
                    EquipSec();
                }
                if (GUI.Button(new Rect(posX, posY + (buttonY * 2), buttonX, buttonY), "Drop"))
                {
                    Drop();
                }
            }
            else
            {
                GUI.Box(new Rect(posX, posY, buttonX, buttonY), "");
                if (GUI.Button(new Rect(posX, posY, buttonX, buttonY), "Drop"))
                {
                    Drop();
                }
            }
        }
    }

    void updPosition()
    {
        float posX = 0, posY = 0;
        switch(position)
        {
            case "0":
            case "1":
            case "2":
            case "3":
            case "4":
            case "5":
            case "6":
            case "7":
            case "8":
            case "9":
            case "10":
            case "11":
            case "12":
            case "13":
            case "14":
            case "15":
            case "16":
            case "17":
            case "18":
            case "19":
                invType = 0;
                posX = InventoryHelper.startX + (InventoryHelper.calcX(position) * InventoryHelper.offsetX);
                posY = InventoryHelper.startY + (InventoryHelper.calcY(position) * InventoryHelper.offsetY);
                break;

            case "head":
                posX = InventoryHelper.headPosX + (InventoryHelper.widthX / 2);
                posY = InventoryHelper.headPosY + (InventoryHelper.widthY / 2);
                invType = 1 ;
                break;

            case "chest":
                posX = InventoryHelper.chestPosX + (InventoryHelper.widthX / 2);
                posY = InventoryHelper.chestPosY + (InventoryHelper.widthY / 2);
                invType = 1 ;
                break;

            case "pants":
                posX = InventoryHelper.pantsPosX + (InventoryHelper.widthX / 2);
                posY = InventoryHelper.pantsPosY + (InventoryHelper.widthY / 2);
                invType = 1 ;
                break;

            case "shoes":
                posX = InventoryHelper.shoesPosX + (InventoryHelper.widthX / 2);
                posY = InventoryHelper.shoesPosY + (InventoryHelper.widthY / 2);
                invType = 1 ;
                break;

            case "backpack":
                posX = InventoryHelper.backpackPosX + (InventoryHelper.widthX / 2);
                posY = InventoryHelper.backpackPosY + (InventoryHelper.widthY / 2);
                invType = 1 ;
                break;

            case "extra":
                posX = InventoryHelper.extraPosX + (InventoryHelper.widthX / 2);
                posY = InventoryHelper.extraPosY + (InventoryHelper.widthY / 2);
                invType = 1 ;
                break;

            case "primary":
                posX = InventoryHelper.primaryPosX + (InventoryHelper.widthX / 2);
                posY = InventoryHelper.primaryPosY + (InventoryHelper.widthY / 2);
                invType = 1 ;
                break;

            case "secondary":
                posX = InventoryHelper.secondaryPosX + (InventoryHelper.widthX / 2);
                posY = InventoryHelper.secondaryPosY + (InventoryHelper.widthY / 2);
                invType = 1 ;
                break;
        }
        GetComponent<RectTransform>().localPosition = new Vector3(posX, posY);
    }

    void Equip()
    {
        InventoryHelper.swapEqOrPlaceContext(gameObject, null, inventoryManager.GetComponent<InventoryManager>().equipment);
        context = false;
    }

    void EquipPrim()
    {
        InventoryHelper.swapEqOrPlaceContext(gameObject, "primary", inventoryManager.GetComponent<InventoryManager>().equipment);
        context = false;
    }

    void EquipSec()
    {
        InventoryHelper.swapEqOrPlaceContext(gameObject, "secondary", inventoryManager.GetComponent<InventoryManager>().equipment);
        context = false;
    }

    void Drop()
    {
        inventoryManager.GetComponent<InventoryManager>().inventory.Remove(gameObject);
        Destroy(gameObject);
        context = false;
    }

    public string Name
    {
        get
        {
            return nme;
        }
    }

    public string Lore
    {
        get
        {
            return lore;
        }
    }

    public int ID
    {
        get
        {
            return id;
        }
    }

    public string Position
    {
        get
        {
            return position;
        }
        set
        {
            position = value;
        }
    }

    public ItemType Type
    {
        get { 
            return type; 
        }
    }

    public Sprite Image
    {
        get
        {
            return gameObject.GetComponent<Image>().sprite;
        }
    }

}
