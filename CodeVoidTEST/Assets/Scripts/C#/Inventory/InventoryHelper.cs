using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryHelper {

    static private int horzMax = 5, vertMax = 5;
    static private float xCord = -249, yCord = 161;
    static private float xOffset = 135, yOffset = -80;
    static private float xWidth = 50, yHeight = 50;

    public static bool checkObjPos(GameObject obj, float posX, float posY, bool local)
    {
        Vector3 position;
        if (local)
            position = obj.GetComponent<RectTransform>().localPosition;
        else
            position = obj.GetComponent<RectTransform>().position;
        if (position.x > xCord + (xOffset * posX) && position.x < xCord + (xOffset * posX) + xWidth)
        {
            if (position.y > yCord + (yOffset * posY) && position.y < yCord + (yOffset * posY) + yHeight)
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
            for (int x = 0; x < horzMax; x++)
            {
                for (int y = 0; y < vertMax; y++)
                {
                    if (checkObjPos(movingObj, x, y, true) && position == -1)
                    {
                        position = x + (y * horzMax);
                    }
                    else if (obj.GetComponent<Item>().Position == position)
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
        if (position > horzMax)
        {
            int x = position - ((position / horzMax) * horzMax);
            Debug.Log("X: " + x);
            return x;
        }
        else
        {
            Debug.Log("X: " + position);
            return position;
        }
    }

    public static int calcY(int position)
    {
        if (position > horzMax)
        {
            int y = position / horzMax;
            Debug.Log("X: " + y);
            return y;
        }
        else
        {
            Debug.Log("Y: " + 0);
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
