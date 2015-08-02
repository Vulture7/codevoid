using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Item : MonoBehaviour {

    public enum ItemType { Consume,Stat,Weapon,ERROR, Head, Chest, Pants, Shoes, Backpack, Extra }
    public GameObject inventoryManager;
    public bool drag = false, context = false;
    public bool dragFail = false;
    public int invType = 0;

    private int id;
    private string nme, lore;
    private ItemType type;
    private string position = "";

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
                Debug.Log(GetComponent<Image>().sprite.ToString());
                break;
            case 1:
                nme = "Med Syringer";
                lore = "Used for healing.";
                type = ItemType.Consume;
                GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Items/Consume/Resource_MedSyringer-Red.2d");
                Debug.Log(GetComponent<Image>().sprite.ToString());
                break;
            case 2:
                nme = "Machine Gun";
                lore = "Used for killing.";
                type = ItemType.Weapon;
                GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Items/Weapons/machinegun_test");
                Debug.Log(GetComponent<Image>().sprite.ToString());
                break;
            case 3:
                nme = "Helmet";
                lore = "Used for Protecting.";
                type = ItemType.Head;
                GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Items/Armor/helmet_test");
                Debug.Log(GetComponent<Image>().sprite.ToString());
                break;
            case 4:
                nme = "Chest";
                lore = "Used for Protecting.";
                type = ItemType.Chest;
                GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Items/Armor/chestplate_test");
                Debug.Log(GetComponent<Image>().sprite.ToString());
                break;
            case 5:
                nme = "Pants";
                lore = "Used for Protecting.";
                type = ItemType.Pants;
                GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Items/Armor/pants_test");
                Debug.Log(GetComponent<Image>().sprite.ToString());
                break;
            case 6:
                nme = "Shoes";
                lore = "Used for Protecting.";
                type = ItemType.Shoes;
                GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Items/Armor/shoes_test");
                Debug.Log(GetComponent<Image>().sprite.ToString());
                break;
            case 7:
                nme = "Backpack";
                lore = "Used for Carrying stuff.";
                type = ItemType.Backpack;
                GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Items/Backpacks/backpack_test");
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

        if (!drag)
        {
            if (invType != inventoryManager.GetComponent<InventoryManager>().inventoryType)
                gameObject.SetActive(false);

            updPosition();
            dragFail = false;
        }
        else if (drag)
        {
            InventoryHelper.followMouse(gameObject);
        }
        if (context)
        {
            Vector3 position = GetComponent<RectTransform>().position;
            Debug.Log(position);
            GUI.Box(new Rect(position.x, position.y, 220, 180), "");

            if (GUI.Button(new Rect(position.x, position.y, 80, 20), "Drop"))
            {
                Drop();
            }

            if (GUI.Button(new Rect(position.x, position.y + 25, 80, 20), "Cancel"))
            {
                context = !context;
            }
        }
    }

    void updPosition()
    {
        invType = 0;
        try
        {
            Convert.ToInt32(position);
            invType = 0;
        }
        catch
        {
            invType = 1;
        }

        if (inventoryManager.GetComponent<InventoryManager>().inventoryType == 0 && invType == 0)
        {
            float xPos = InventoryHelper.startX + (InventoryHelper.calcX(position) * InventoryHelper.offsetX);
            float yPos = InventoryHelper.startY + (InventoryHelper.calcY(position) * InventoryHelper.offsetY);
            GetComponent<RectTransform>().localPosition = new Vector3(xPos, yPos);
        }
        else if (inventoryManager.GetComponent<InventoryManager>().inventoryType == 1 && invType == 1)
        {
            float posX = 0, posY = 0;
            switch (position)
            {
                case "primary":
                    posX = InventoryHelper.primaryPosX + (InventoryHelper.widthX / 2);
                    posY = InventoryHelper.primaryPosY + (InventoryHelper.widthY / 2);
                    break;

                case "secondary":
                    posX = InventoryHelper.secondaryPosX + (InventoryHelper.widthX / 2);
                    posY = InventoryHelper.secondaryPosY + (InventoryHelper.widthY / 2);
                    break;

                case "backpack":
                    posX = InventoryHelper.backpackPosX + (InventoryHelper.widthX / 2);
                    posY = InventoryHelper.backpackPosY + (InventoryHelper.widthY / 2);
                    break;

                case "extra":
                    posX = InventoryHelper.extraPosX + (InventoryHelper.widthX / 2);
                    posY = InventoryHelper.extraPosY + (InventoryHelper.widthY / 2);
                    break;

                case "head":
                    posX = InventoryHelper.headPosX + (InventoryHelper.widthX / 2);
                    posY = InventoryHelper.headPosY + (InventoryHelper.widthY / 2);
                    break;

                case "chest":
                    posX = InventoryHelper.chestPosX + (InventoryHelper.widthX / 2);
                    posY = InventoryHelper.chestPosY + (InventoryHelper.widthY / 2);
                    break;

                case "pants":
                    posX = InventoryHelper.pantsPosX + (InventoryHelper.widthX / 2);
                    posY = InventoryHelper.pantsPosY + (InventoryHelper.widthY / 2);
                    break;

                case "shoes":
                    posX = InventoryHelper.shoesPosX + (InventoryHelper.widthX / 2);
                    posY = InventoryHelper.shoesPosY + (InventoryHelper.widthY / 2);
                    break;
            }

            GetComponent<RectTransform>().localPosition = new Vector3(posX, posY);
        }
    }

    void Drop()
    {
        inventoryManager.GetComponent<InventoryManager>().inventory.Remove(gameObject);
        Destroy(gameObject);
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
