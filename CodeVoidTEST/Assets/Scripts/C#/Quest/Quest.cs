using UnityEngine;
using System.Collections;

public class Quest {

    private int uid;
    private string title, text;
    private bool completed;

    public Quest(int uid, string title, string text)
    {
        this.uid = uid;
        this.title = title;
        this.text = text;
    }

    public int UID
    {
        get
        {
            return this.uid;
        }
    }

    public string TITLE
    {
        get
        {
            return this.title;
        }
    }

    public string TEXT
    {
        get
        {
            return this.text;
        }
    }

    public bool COMPLETED
    {
        get
        {
            return this.completed;
        }
        set
        {
            this.completed = value;
        }
    }

}
