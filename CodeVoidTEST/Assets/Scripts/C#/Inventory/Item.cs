using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Item : MonoBehaviour {

    public enum ItemType { Consume,Stat,Weapon,ERROR }
    public GameObject itemManager;
    public int position;
    public bool Drag = false;

    private int id;
    private string name, lore;
    private ItemType type;
    private Image image;
    private float xCord = -249;
    private float yCord = 161;
    private float xWidth = 135;
    private float yHeight = -80;
    private int lastPos = -1;

    public void loadInformation(int id, int position, int x, int y)
    {
        this.position = position;
        RectTransform rect = gameObject.GetComponent<RectTransform>();
        rect.localPosition = new Vector3(xCord + (x * xWidth), yCord + (y * yHeight));
        lastPos = position;
        switch (id)
        {
            case 0:
                name = "Med Syringer";
                lore = "Used for healing.";
                type = ItemType.Consume;

                gameObject.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Images/Items/Consume/Resource_MedSyringer.2d");
                Debug.Log(gameObject.GetComponentInChildren<Image>().sprite.ToString());
                break;
            default:
                name = "ERROR";
                lore = "Unknown itemID: " + id.ToString();
                type = ItemType.ERROR;
                break;
        }
        this.id = id;
    }

    void Update() 
    {
        if (Drag)
        {
            var mousePos = Input.mousePosition;
            var wantedPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0));
            gameObject.GetComponent<RectTransform>().position = wantedPos;
        }
        else if (lastPos != position)
        {
            int y = position / InventoryManager.horzMax;
            int x = position > InventoryManager.horzMax ? position - (y * InventoryManager.horzMax): position;
            gameObject.GetComponent<RectTransform>().localPosition = new Vector3(xCord + (x * xWidth), yCord + (y * yHeight));
            lastPos = position;
        }
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

    public Image Icon
    {
        get
        {
            return gameObject.GetComponentInChildren<Image>();
        }
    }

}
