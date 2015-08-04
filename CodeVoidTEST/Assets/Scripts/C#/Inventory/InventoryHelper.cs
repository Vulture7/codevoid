using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class InventoryHelper
{
    public static GameObject dragging = null;

    #region Item Pos
    static private int horzMax = 5, vertMax = 4;
    static private float xCord = Screen.width / 2.57f * -1, yCord = Screen.height / 3f;
    static private float xOffset = Screen.width / 7.8f, yOffset = Screen.height / 5f * -1;
    static private float xWidth = Screen.width / 24.5f, yHeight = Screen.height / 16.5f;
    #endregion

    #region Player Preview
    static private float camX = Screen.width / 5.7f, camY = Screen.height / 3.5f;
    static private float previewX = -92f / 1400 * Screen.width, previewY = 10f / 600 * Screen.height;
    static private float playerY = -250f / 600 * Screen.height;
    static private float playerScalX = 300f / 600 * Screen.height, playerScalY = 180f / 600 * Screen.height, playerScalZ = 300f / 600 * Screen.height;
    #endregion

    #region TypeSwitch Preview
    static private float typeX = 185f / 1400 * Screen.width - xWidth / 2, typeXEnd = 185f / 1400 * Screen.width + xWidth / 2;
    static private float type1Y = 25f / 600 * Screen.height + yHeight / 2, type1YEnd = 25f / 600 * Screen.height - yHeight / 2;
    static private float type2Y = -15f / 600 * Screen.height + yHeight / 2, type2YEnd = -15f / 600 * Screen.height - yHeight / 2;
    static private float type3Y = -55f / 600 * Screen.height + yHeight / 2, type3YEnd = -55f / 600 * Screen.height - yHeight / 2;
    static private float type4Y = -95f / 600 * Screen.height + yHeight / 2, type4YEnd = -95f / 600 * Screen.height - yHeight / 2;
    #endregion

    #region ItemDescription
    static private float itemNameX = 470f / 1400 * Screen.width, itemNameY = 270f / 600 * Screen.height;
    static private float itemLoreX = 470f / 1400 * Screen.width, itemLoreY = 175f / 600 * Screen.height;
    #endregion

    #region Armor Pos
    static public float headPosX = xCord - xWidth / 2, headPosEndX = xCord + xWidth / 2;
    static public float headPosEndY = yCord + yHeight / 2, headPosY = yCord - yHeight / 2;

    static public float chestPosX = xCord - xWidth / 2, chestPosEndX = xCord + xWidth / 2;
    static public float chestPosEndY = yCord + yOffset + yHeight / 2, chestPosY = yCord + yOffset - yHeight / 2;

    static public float pantsPosX = xCord - xWidth / 2, pantsPosEndX = xCord + xWidth / 2;
    static public float pantsPosEndY = yCord + yOffset * 2 + yHeight / 2, pantsPosY = yCord + yOffset * 2 - yHeight / 2;

    static public float shoesPosX = xCord - xWidth / 2, shoesPosEndX = xCord + xWidth / 2;
    static public float shoesPosEndY = yCord + yOffset * 3 + yHeight / 2, shoesPosY = yCord + yOffset * 3 - yHeight / 2;
    #endregion

    #region Weapon, Backpack & Extra Pos
    static public float primaryPosX = xCord + xOffset * 4 - xWidth / 2, primaryPosEndX = xCord + xOffset * 4 + xWidth / 2;
    static public float primaryPosEndY = yCord + yHeight / 2, primaryPosY = yCord - yHeight / 2;

    static public float secondaryPosX = xCord + xOffset * 4 - xWidth / 2, secondaryPosEndX = xCord + xOffset * 4 + xWidth / 2;
    static public float secondaryPosEndY = yCord + yOffset + yHeight / 2, secondaryPosY = yCord + yOffset - yHeight / 2;

    static public float backpackPosX = xCord + xOffset * 4 - xWidth / 2, backpackPosEndX = xCord + xOffset * 4 + xWidth / 2;
    static public float backpackPosEndY = yCord + yOffset * 2 + yHeight / 2, backpackPosY = yCord + yOffset * 2 - yHeight / 2;

    static public float extraPosX = xCord + xOffset * 4 - xWidth / 2, extraPosEndX = xCord + xOffset * 4 + xWidth / 2;
    static public float extraPosEndY = yCord + yOffset * 3 + yHeight / 2, extraPosY = yCord + yOffset * 3 - yHeight / 2;
    #endregion

    #region ChracterDragPos
    static public float charPosX = xCord + xOffset - xWidth / 2, charPosEndX = xCord + xOffset * 3 + xWidth / 2;
    static public float charPosY = yCord + yHeight / 2, charPosEndY = yCord + yOffset * 3 - yHeight / 2;
    #endregion

    public static string checkEqPos(GameObject obj, bool local)
    {
        Vector3 position;
        if (local)
            position = obj.GetComponent<RectTransform>().localPosition;
        else
            position = obj.GetComponent<RectTransform>().position;

        #region Weapon Check
        if (obj.GetComponent<Item>().Type == Item.ItemType.Weapon)
        {
            Debug.Log(position + ":" + primaryPosX + ":" + primaryPosY + ":" + primaryPosEndX + ":" + primaryPosEndY);
            if ((position.x > primaryPosX && position.x < primaryPosEndX) && (position.y > primaryPosY && position.y < primaryPosEndY))
            {
                return "primary";
            }
            else if ((position.x > secondaryPosX && position.x < secondaryPosEndX) && (position.y > secondaryPosY && position.y < secondaryPosEndY))
            {
                return "secondary";
            }
        }
        #endregion
        #region Armor
        else if (obj.GetComponent<Item>().Type == Item.ItemType.Head)
        {
            if ((position.x > headPosX && position.x < headPosEndX))
            {
                if ((position.y > headPosY && position.y < headPosEndY))
                {
                    return "head";
                }
            }
        }
        else if (obj.GetComponent<Item>().Type == Item.ItemType.Chest)
        {
            if ((position.x > chestPosX && position.x < chestPosEndX))
            {
                if ((position.y > chestPosY && position.y < chestPosEndY))
                {
                    return "chest";
                }
            }
        }
        else if (obj.GetComponent<Item>().Type == Item.ItemType.Pants)
        {
            if ((position.x > pantsPosX && position.x < pantsPosEndX))
            {
                if ((position.y > pantsPosY && position.y < pantsPosEndY))
                {
                    return "pants";
                }
            }
        }
        else if (obj.GetComponent<Item>().Type == Item.ItemType.Shoes)
        {
            if ((position.x > shoesPosX && position.x < shoesPosEndX))
            {
                if ((position.y > shoesPosY && position.y < shoesPosEndY))
                {
                    return "shoes";
                }
            }
        }
        #endregion
        #region Backpack
        else if (obj.GetComponent<Item>().Type == Item.ItemType.Backpack)
        {
            if ((position.x > backpackPosX && position.x < backpackPosEndX))
            {
                if ((position.y > backpackPosY && position.y < backpackPosEndY))
                {
                    return "backpack";
                }
            }
        }
        #endregion
        #region Extra
        else if (obj.GetComponent<Item>().Type == Item.ItemType.Extra)
        {
            if ((position.x > extraPosX && position.x < extraPosEndX))
            {
                if ((position.y > extraPosY && position.y < extraPosEndY))
                {
                    return "extra";
                }
            }
        }
        #endregion
        return "-1";
    }

    public static void swapEqOrPlace(GameObject movingObj, Equipment equipment)
    {
        string position = "-1";
        GameObject swapItem = null;

        position = checkEqPos(movingObj, true);
        swapItem = GetEqSwitch(position, equipment);

        if (swapItem != null && position != "-1")
        {
            swapItem.GetComponent<Item>().Position = movingObj.GetComponent<Item>().Position;
            movingObj.GetComponent<Item>().Position = position;
            swapItem.GetComponent<Item>().invType = 0;
            movingObj.GetComponent<Item>().invType = 1;

            SetEqSwitch(position, movingObj, equipment);
            movingObj.GetComponent<Item>().inventoryManager.GetComponent<InventoryManager>().inventory.Remove(movingObj);
            movingObj.GetComponent<Item>().inventoryManager.GetComponent<InventoryManager>().inventory.Add(swapItem);
        }
        else if (position != "-1")
        {
            movingObj.GetComponent<Item>().Position = position;
            SetEqSwitch(position, movingObj, equipment);
            movingObj.GetComponent<Item>().inventoryManager.GetComponent<InventoryManager>().inventory.Remove(movingObj);
            movingObj.GetComponent<Item>().invType = 1;
        }
    }

    public static GameObject GetEqSwitch(string position, Equipment equipment)
    {
        GameObject item = null;
        switch (position)
        {
            case "primary":
                item = equipment.Primary;
                break;
            case "secondary":
                item = equipment.Secondary;
                break;
            case "head":
                item = equipment.Head;
                break;
            case "chest":
                item = equipment.Chest;
                break;
            case "pants":
                item = equipment.Pants;
                break;
            case "shoes":
                item = equipment.Shoes;
                break;
            case "backpack":
                item = equipment.Backpack;
                break;
            case "extra":
                item = equipment.Extra;
                break;
        }

        return item;
    }

    public static void SetEqSwitch(string position, GameObject item, Equipment equipment)
    {
        switch (position)
        {
            case "primary":
                equipment.Primary = item;
                break;
            case "secondary":
                equipment.Secondary = item;
                break;
            case "head":
                equipment.Head = item;
                break;
            case "chest":
                equipment.Chest = item;
                break;
            case "pants":
                equipment.Pants = item;
                break;
            case "shoes":
                equipment.Shoes = item;
                break;
            case "backpack":
                equipment.Backpack = item;
                break;
            case "extra":
                equipment.Extra = item;
                break;
        }
    }

    public static void swapEqOrPlaceContext(GameObject movingObj, string primsec, Equipment equipment)
    {
        string position = "-1";
        GameObject swapItem = null;

        switch (movingObj.GetComponent<Item>().Type)
        {
            case Item.ItemType.Weapon:
                if (primsec != null)
                    position = primsec;
                else
                    position = "primary";
                break;
            case Item.ItemType.Head:
                position = "head";
                break;
            case Item.ItemType.Chest:
                position = "chest";
                break;
            case Item.ItemType.Pants:
                position = "pants";
                break;
            case Item.ItemType.Shoes:
                position = "shoes";
                break;
            case Item.ItemType.Backpack:
                position = "backpack";
                break;
            case Item.ItemType.Extra:
                position = "extra";
                break;
        }

        swapItem = GetEqSwitch(position, equipment);

        if (swapItem != null && position != "-1")
        {
            movingObj.GetComponent<Item>().inventoryManager.GetComponent<InventoryManager>().inventory.Remove(movingObj);
            swapItem.GetComponent<Item>().inventoryManager.GetComponent<InventoryManager>().inventory.Add(swapItem);
            swapItem.GetComponent<Item>().Position = movingObj.GetComponent<Item>().Position;
            swapItem.GetComponent<Item>().invType = 0;

            movingObj.GetComponent<Item>().Position = position;
            SetEqSwitch(position, movingObj, equipment);
            movingObj.GetComponent<Item>().invType = 1;
        }
        else if (position != "-1")
        {
            movingObj.GetComponent<Item>().inventoryManager.GetComponent<InventoryManager>().inventory.Remove(movingObj);

            movingObj.GetComponent<Item>().Position = position;
            SetEqSwitch(position, movingObj, equipment);
            movingObj.GetComponent<Item>().invType = 1;
        }
    }

    public static bool checkObjPos(GameObject obj, float posX, float posY, bool local)
    {
        Vector3 position;
        if (local)
            position = obj.GetComponent<RectTransform>().localPosition;
        else
            position = obj.GetComponent<RectTransform>().position;
        if (position.x > xCord + (xOffset * posX) - (xWidth / 2) && position.x < xCord + (xOffset * posX) + (xWidth / 2))
        {
            if (position.y > yCord + (yOffset * posY) - (yHeight / 2) && position.y < yCord + (yOffset * posY) + (yHeight / 2))
            {
                return true;
            }
        }
        return false;
    }

    public static void swapItemsOrDrop(GameObject movingObj, List<GameObject> list)
    {
        string position = "-1";
        GameObject swapItem = null;

        foreach (GameObject obj in list)
        {
            for (int y = 0; y < vertMax; y++)
            {
                for (int x = 0; x < horzMax; x++)
                {
                    if (checkObjPos(movingObj, x, y, true) && position == "-1")
                    {
                        position = (x + (y * horzMax)).ToString();
                    }

                    if (obj.GetComponent<Item>().Position == position)
                    {
                        swapItem = obj;
                    }
                }
            }
        }

        if (swapItem != null && position != "-1")
        {
            swapItem.GetComponent<Item>().Position = movingObj.GetComponent<Item>().Position;
            movingObj.GetComponent<Item>().Position = position.ToString();
            swapItem.GetComponent<Item>().invType = 0;
            movingObj.GetComponent<Item>().invType = 0;
        }
        else if(position != "-1")
        {
            movingObj.GetComponent<Item>().Position = position.ToString();
            movingObj.GetComponent<Item>().invType = 0;
        }
    }

    public static void followMouse(GameObject obj)
    {
        obj.GetComponent<RectTransform>().position = Input.mousePosition;
    }

    public static int calcX(string position)
    {
        int posi = Convert.ToInt32(position);
        if (posi >= horzMax)
        {
            int x = posi - ((posi / horzMax) * horzMax);
            return x;
        }
        else
        {
            return posi;
        }
    }

    public static int calcY(string position)
    {
        int posi = Convert.ToInt32(position);
        if (posi >= horzMax)
        {
            int y = posi / horzMax;
            return y;
        }
        else
        {
            return 0;
        }
    }

    public static int checkClickOnSwitch(Vector2 mousePosition, Vector2 windowPos)
    {
        Vector2 position = mousePosition - windowPos;
        if (position.x > typeX && position.x < typeXEnd)
        {
            if (position.y < type1Y && position.y > type1YEnd)
                return 0;
            if (position.y < type2Y && position.y > type2YEnd)
                return 1;
            if (position.y < type3Y && position.y > type3YEnd)
                return 2;
            if (position.y < type4Y && position.y > type4YEnd)
                return 3;
        }
        return -1;
    }

    #region Get Functions
    public static int maxX
    {
        get
        {
            return horzMax;
        }
    }

    public static int maxY
    {
        get
        {
            return vertMax;
        }
    }

    public static float startX
    {
        get
        {
            return xCord;
        }
    }

    public static float startY
    {
        get
        {
            return yCord;
        }
    }

    public static float offsetX
    {
        get
        {
            return xOffset;
        }
    }

    public static float offsetY
    {
        get
        {
            return yOffset;
        }
    }

    public static float widthX
    {
        get
        {
            return xWidth;
        }
    }

    public static float widthY
    {
        get
        {
            return yHeight;
        }
    }

    public static float CamX
    {
        get
        {
            return camX;
        }
    }

    public static float CamY
    {
        get
        {
            return camY;
        }
    }

    public static float PreviewX
    {
        get
        {
            return previewX;
        }
    }

    public static float PreviewY
    {
        get
        {
            return previewY;
        }
    }

    public static float PlayerY
    {
        get
        {
            return playerY;
        }
    }

    public static float PlayerScalX
    {
        get
        {
            return playerScalX;
        }
    }

    public static float PlayerScalY
    {
        get
        {
            return playerScalY;
        }
    }

    public static float PlayerScalZ
    {
        get
        {
            return playerScalZ;
        }
    }

    public static float ItemNameX
    {
        get
        {
            return itemNameX;
        }
    }

    public static float ItemNameY
    {
        get
        {
            return itemNameY;
        }
    }

    public static float ItemLoreX
    {
        get
        {
            return itemLoreX;
        }
    }

    public static float ItemLoreY
    {
        get
        {
            return itemLoreY;
        }
    }

    public static float TypeX
    {
        get
        {
            return typeX;
        }
    }

    public static float TypeXEnd
    {
        get
        {
            return typeXEnd;
        }
    }

    public static float Type1Y
    {
        get
        {
            return type1Y;
        }
    }

    public static float Type1YEnd
    {
        get
        {
            return type1YEnd;
        }
    }

    public static float Type2Y
    {
        get
        {
            return type2Y;
        }
    }

    public static float Type2YEnd
    {
        get
        {
            return type2YEnd;
        }
    }

    public static float Type3Y
    {
        get
        {
            return type3Y;
        }
    }

    public static float Type3YEnd
    {
        get
        {
            return type3YEnd;
        }
    }

    public static float Type4Y
    {
        get
        {
            return type4Y;
        }
    }

    public static float Type4YEnd
    {
        get
        {
            return type4YEnd;
        }
    }
#endregion
}
