using UnityEngine;
using System.Collections;

public class Quest {

    private int uid;
    private string title, text, endtext;
    private bool completed;

    public Quest(int uid, string title, string text, string endtext)
    {
        this.uid = uid;
        this.title = title;
        this.text = text;
        this.endtext = endtext;
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

    public string ENDTEXT
    {
        get
        {
            return this.endtext;
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
