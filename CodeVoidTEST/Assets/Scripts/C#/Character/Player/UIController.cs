using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {

    public GameObject manager;

    void Update()
    {
        if (Input.GetKeyDown(SettingValues.managerKey))
        {
            gameObject.GetComponent<InventoryManager>().menu = !gameObject.GetComponent<InventoryManager>().menu;
        }
    }


}
