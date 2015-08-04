using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CrateManager : MonoBehaviour {

    public Text interactText;
    public bool looking;
    public bool locked;

    public string code;

    public GameObject keypad;
    private GameObject player;

    void Start()
    {
        looking = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        //if (looking) { interactText.enabled = true; }
        if (Input.GetKeyDown(SettingValues.interactKey) && looking)
        {
            Debug.Log(locked);
            if (locked) 
            { 
                keypad.GetComponent<KeypadUIManager>().neededCode = code; 
                keypad.GetComponent<KeypadUIManager>().crate = gameObject; 
                keypad.SetActive(true); player.GetComponent<PlayerControl>().inManager = true; 
            }
            else 
            { 
                Debug.Log("Crate unlocked! Show UI!"); 
            }
        }
    }

}
