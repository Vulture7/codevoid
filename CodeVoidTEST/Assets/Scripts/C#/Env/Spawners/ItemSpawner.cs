using UnityEngine;
using System.Collections;

public class ItemSpawner : MonoBehaviour
{

    public GameObject[] items;

    public void SpawnItem()
    {
        Instantiate(items[Mathf.RoundToInt(Random.Range(0, items.Length))]);
    }

}