using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Item : MonoBehaviour {

    public enum ItemType { Consume,Stat,Weapon,ERROR }
    public GameObject inventoryManager;
    public bool drag = false;
    public bool dragFail = false;

    private int id;
    private string nme, lore;
    private ItemType type;
    private int position = -1, lastPosition = -1;

    public void loadData(int id, GameObject area, int position)
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
            updPosition();
            dragFail = false;
        }
        else if (drag)
        {
            Debug.Log(position);
            InventoryHelper.followMouse(gameObject);
        }
    }

    void updPosition()
    {
        float xPos = InventoryHelper.startX + (InventoryHelper.calcX(position) * InventoryHelper.offsetX);
        float yPos = InventoryHelper.startY + (InventoryHelper.calcY(position) * InventoryHelper.offsetY);
        GetComponent<RectTransform>().localPosition = new Vector3(xPos, yPos);
        lastPosition = position;
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

    public int Position
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
