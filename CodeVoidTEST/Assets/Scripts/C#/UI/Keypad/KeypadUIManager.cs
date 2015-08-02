using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KeypadUIManager : MonoBehaviour {

    public Text text;
    public GameObject crate;
    public GameObject player;

    public AudioClip beep;
    public AudioClip success;

    public string neededCode;
    private string code = "";
    public int maxCodeLength;
    public float hackTime;

    private bool hackable = false;
    private bool hacking = false;
    private float hackTimeLeft;

    void Update()
    {
        if (hacking)
        {
            if (hackTimeLeft < 0.1) { hacking = false; code = neededCode; text.text = neededCode; return; }
            text.text = GetRandText();
            hackTimeLeft -= Time.deltaTime;
            return;
        }
        Item i = player.GetComponent<PlayerManager>().itemInHands;
        switch (i.ID)
        {
            case 8:
                hackable = true;
                transform.GetChild(transform.childCount - 1).gameObject.SetActive(true);
                break;
        }
    }

    public void Add1() { Add("1"); }

    public void Add2() { Add("2"); }

    public void Add3() { Add("3"); }

    public void Add4() { Add("4"); }

    public void Add5() { Add("5"); }

    public void Add6() { Add("6"); }
    
    public void Add7() { Add("7"); }
    
    public void Add8() { Add("8"); }

    public void Add9() { Add("9"); }

    public void Add0() { Add("0"); }

    public void Backspace() { code = code.Remove(code.Length - 1, 1); text.text = code; player.GetComponent<AudioSource>().PlayOneShot(beep); }

    public void Enter() {
        player.GetComponent<AudioSource>().PlayOneShot(beep);
        if (neededCode != code) { text.text = "ERROR"; code = ""; player.GetComponent<AudioSource>().PlayOneShot(beep); return; }
        text.text = "";
        player.GetComponent<PlayerControl>().inManager = false;
        player.GetComponent<AudioSource>().PlayOneShot(success);
        gameObject.SetActive(false);
        crate.GetComponent<CrateManager>().locked = false;
    }

    public void Hack() { hacking = true; hackTimeLeft = hackTime; }

    private string GetRandText()
    {
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+{}|:?<>abcdefghijklmnopqrstuvwxyz";
        string returnText = "";
        for (int x = 0; x < 6; x++)
        {
            returnText += chars.Substring(Random.Range(0, chars.Length));
        }
        return returnText;
    }

    private void Add(string str)
    {
        player.GetComponent<AudioSource>().PlayOneShot(beep);
        if (code.Length == maxCodeLength) { return; }
        code += str;
        text.text = code;
    }

}
