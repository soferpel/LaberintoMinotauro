using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject[] objectPrefabs; // Array para los tres objetos prefabs
    public int objectAmountPerChest; // Cantidad de objetos por cofre
    public List<GameObject> chests; // Lista de cofres

    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        foreach (GameObject chest in chests)
        {
            Transform spawn = chest.transform.Find("spawn");

            if (spawn == null)
            {
                Debug.LogWarning("No SpawnPoint found for chest: " + chest.name);
                continue;
            }

            for (int i = 0; i < objectAmountPerChest; i++)
            {
                // Elegir aleatoriamente uno de los tres prefabs
                int randomIndex = Random.Range(0, objectPrefabs.Length);

                // Instanciar el objeto en el punto de spawn del cofre
                Instantiate(objectPrefabs[randomIndex], spawn.position, Quaternion.identity);
            }
        }
    }
}
