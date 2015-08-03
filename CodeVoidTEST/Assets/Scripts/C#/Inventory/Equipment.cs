using UnityEngine;
using System.Collections;

public class Equipment {

    private GameObject primary = null, secondary = null, head = null, chest = null, pants = null, shoes = null, backpack = null, extra = null;

    public GameObject Primary
    {
        get { return primary; }
        set { primary = value; }
    }

    public GameObject Secondary
    {
        get { return secondary; }
        set { secondary = value; }
    }

    public GameObject Head
    {
        get { return head; }
        set { head = value; }
    }

    public GameObject Chest
    {
        get { return chest; }
        set { chest = value; }
    }

    public GameObject Pants
    {
        get { return pants; }
        set { pants = value; }
    }

    public GameObject Shoes
    {
        get { return shoes; }
        set { shoes = value; }
    }

    public GameObject Backpack
    {
        get { return backpack; }
        set { backpack = value; }
    }

    public GameObject Extra
    {
        get { return extra; }
        set { extra = value; }
    }
}
