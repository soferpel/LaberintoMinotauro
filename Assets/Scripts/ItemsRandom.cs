using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEditor.Progress;

public class ItemsRandom : MonoBehaviour
{
    public Transform pos;
    public GameObject[] items;

    // Start is called before the first frame update
    void Start()
    {
        InstantiateObject();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void InstantiateObject()
    {
        int n = Random.Range(0, 3);

        Instantiate(items[n], pos.position, items[n].transform.rotation);
    }
    
}
