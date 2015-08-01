using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour
{

    public GameObject manager;
    public GameObject player;

    void Update()
    {
        if (Input.GetKeyDown(SettingValues.managerKey))
        {
            manager.SetActive(!manager.activeSelf);
            gameObject.GetComponent<PlayerControl>().inManager = manager.activeSelf;
        }
    }


}