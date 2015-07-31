using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CrateManager : MonoBehaviour {

    public Text interactText;
    public bool looking = false;

    void Update()
    {
        if (looking) { interactText.enabled = true; }
    }

}
