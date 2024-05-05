using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab;
    public int objectAmount;
    public Vector2 spawnArea;

    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        for (int i = 0; i < objectAmount; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-spawnArea.x / 2, spawnArea.x / 2), 0.0f, Random.Range(-spawnArea.y / 2, spawnArea.y / 2));

            RaycastHit hit;
            if (Physics.Raycast(randomPosition + Vector3.up * 10.0f, Vector3.down, out hit, 100.0f, LayerMask.GetMask("Ground")))
            {
                Instantiate(objectPrefab, hit.point, Quaternion.identity);
            }
            else
            {
                i--;
            }
        }
    }
}