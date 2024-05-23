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

    void Start()
    {
        SpawnObject();
    }

    void SpawnObject()
    {
        Vector3 spawnPosition;
        bool validPosition = false;

        for (int attempt = 0; attempt < 100; attempt++)
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
                    spawnPosition = randomPosition + Vector3.up * spawnHeight;
                    Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
                    validPosition = true;
                    break;
                }
            }
        }

        if (!validPosition)
        {
            Debug.LogWarning("No se pudo encontrar una posición válida para generar el objeto.");
        }
    }
}
