using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public LayerMask groundLayer;
    public LayerMask wallLayer;
    public float spawnHeight = 1.0f; 
    public Vector2 planeSize;
    public int objectCount = 10;

    void Start()
    {
        SpawnObjects(objectCount);
    }

    void SpawnObjects(int count)
    {
        int spawnedObjects = 0;

        for (int attempt = 0; attempt < count * 100; attempt++)
        {
            float x = Random.Range(-planeSize.x / 2, planeSize.x / 2);
            float z = Random.Range(-planeSize.y / 2, planeSize.y / 2);
            Vector3 randomPosition = new Vector3(x, 0, z);

            if (Physics.Raycast(randomPosition + Vector3.up * 10, Vector3.down, out RaycastHit hit, Mathf.Infinity, groundLayer))
            {
                randomPosition = hit.point;

                Collider[] colliders = Physics.OverlapSphere(randomPosition, 0.5f, wallLayer);
                if (colliders.Length == 0)
                {
                    Vector3 spawnPosition = randomPosition + Vector3.up * spawnHeight;
                    Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
                    spawnedObjects++;

                    if (spawnedObjects >= count)
                    {
                        break;
                    }
                }
            }
        }

        if (spawnedObjects < count)
        {
            Debug.LogWarning("No se pudo encontrar suficientes posiciones válidas para generar todos los objetos.");
        }
    }
}
