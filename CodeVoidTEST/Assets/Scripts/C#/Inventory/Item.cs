using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Item {

    public enum ItemType { Consume,Stat,Weapon,ERROR }
    public GameObject itemManager;

    private int id;
    private string name, lore;
    private ItemType type;
    private Sprite icon;

    public Item(int id)
    {
        switch (id)
        {
            case 0:
                name = "Med Syringer";
                lore = "Used for healing.";
                type = ItemType.Consume;
                icon = Resources.Load<Sprite>("Images/Items/Consume/Resource_MedSyringer.2d");
                Debug.Log(icon.ToString());
                break;
            default:
                name = "ERROR";
                lore = "Unknown itemID: " + id.ToString();
                type = ItemType.ERROR;
                break;
        }
        this.id = id;
    }

    public string Name
    {
        get
        {
            return name;
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

    public ItemType Type
    {
        get { 
            return type; 
        }
    }

    public Sprite Icon
    {
        get
        {
            return icon;
        }
    }

}
