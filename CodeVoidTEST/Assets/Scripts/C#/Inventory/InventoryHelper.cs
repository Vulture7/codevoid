using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryHelper {

    static private int horzMax = 5, vertMax = 4;
    static private float xCord = -397, yCord = 180;
    static private float xOffset = 130.5f, yOffset = -108.5f;
    static private float xWidth = 80, yHeight = 65;

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

                    if (obj.GetComponent<Item>().Position == position)
                    {
                        swapItem = obj;
                    }
                }
            }
        }

        if (swapItem != null)
        {
            swapItem.GetComponent<Item>().Position = movingObj.GetComponent<Item>().Position;
            movingObj.GetComponent<Item>().Position = position;
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

    public static int calcX(int position)
    {
        if (position >= horzMax)
        {
            int x = position - ((position / horzMax) * horzMax);
            return x;
        }
        else
        {
            return position;
        }
    }

    public static int calcY(int position)
    {
        if (position >= horzMax)
        {
            int y = position / horzMax;
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
