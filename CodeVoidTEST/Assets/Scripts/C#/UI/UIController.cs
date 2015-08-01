using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {

    public GameObject manager;

    void Update()
    {
        if (Input.GetKeyDown(SettingValues.managerKey))
        {
            manager.SetActive(!manager.activeSelf);
        }
    }


}
