using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab;
    public int objectAmount;
    public GameObject plano;

    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        Vector3 planoSize = plano.GetComponent<Renderer>().bounds.size;
        
        for (int i = 0; i < objectAmount; i++)
        {
            float randomX = Random.Range(-planoSize.x / 2, planoSize.x / 2);
            float randomZ = Random.Range(-planoSize.z / 2, planoSize.z / 2);
            Vector3 randomPosition = new Vector3(randomX, plano.transform.position.y, randomZ);

            Instantiate(objectPrefab, randomPosition, Quaternion.identity);
        }
    }
}