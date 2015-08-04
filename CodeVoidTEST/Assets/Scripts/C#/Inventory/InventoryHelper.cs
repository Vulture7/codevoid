using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class InventoryHelper
{

    #region Item Pos
    static private int horzMax = 5, vertMax = 4;
    static private float xCord = -397, yCord = 180;
    static private float xOffset = 130.5f, yOffset = -108.5f;
    static private float xWidth = 80, yHeight = 65;
    #endregion

    #region Armor Pos
    static public float headPosX = -437, headPosEndX = -357;
    static public float headPosY = 147.5f, headPosEndY = 212.5f;

    static public float chestPosX = -437, chestPosEndX = -357;
    static public float chestPosY = 39f, chestPosEndY = 104f;

    static public float pantsPosX = -437, pantsPosEndX = -357;
    static public float pantsPosY = -69.5f, pantsPosEndY = -4.5f;

    static public float shoesPosX = -437, shoesPosEndX = -357;
    static public float shoesPosY = -178f, shoesPosEndY = -113f;
    #endregion

    #region Weapon, Backpack & Extra Pos
    static public float primaryPosX = 85, primaryPosEndX = 165;
    static public float primaryPosY = 147.5f, primaryPosEndY = 212.5f;

    static public float secondaryPosX = 85, secondaryPosEndX = 165;
    static public float secondaryPosY = 39f, secondaryPosEndY = 104f;

    static public float backpackPosX = 85, backpackPosEndX = 165;
    static public float backpackPosY = -69.5f, backpackPosEndY = -4.5f;

    static public float extraPosX = 85, extraPosEndX = 165;
    static public float extraPosY = -178f, extraPosEndY = -113f;
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
        return "";
    }

    public static bool swapEqOrPlace(GameObject movingObj, List<GameObject> list)
    {
        int position = -1;
        GameObject swapItem = null;

        foreach (GameObject obj in list)
        {
            for (int y = 0; y < vertMax; y++)
            {
                for (int x = 0; x < horzMax; x++)
                {
                    if (checkObjPos(movingObj, x, y, true) && position == -1)
                    {
                        position = x + (y * horzMax);
                    }

                    if (Convert.ToInt32(obj.GetComponent<Item>().Position) == position)
                    {
                        swapItem = obj;
                    }
                }
            }
        }

        if (swapItem != null)
        {
            swapItem.GetComponent<Item>().Position = movingObj.GetComponent<Item>().Position;
            movingObj.GetComponent<Item>().Position = position.ToString();
        }
        else
        {
            movingObj.GetComponent<Item>().dragFail = true;
        }


        return false;
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

    public static bool swapItemsOrDrop(GameObject movingObj, List<GameObject> list)
    {
        int position = -1;
        GameObject swapItem = null;

        foreach (GameObject obj in list)
        {
            for (int y = 0; y < vertMax; y++)
            {
                for (int x = 0; x < horzMax; x++)
                {
                    if (checkObjPos(movingObj, x, y, true) && position == -1)
                    {
                        position = x + (y * horzMax);
                    }

                    if (Convert.ToInt32(obj.GetComponent<Item>().Position) == position)
                    {
                        swapItem = obj;
                    }
                }
            }
        }

        if (swapItem != null)
        {
            swapItem.GetComponent<Item>().Position = movingObj.GetComponent<Item>().Position;
            movingObj.GetComponent<Item>().Position = position.ToString();
        }
        else
        {
            movingObj.GetComponent<Item>().dragFail = true;
        }


        return false;
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
}