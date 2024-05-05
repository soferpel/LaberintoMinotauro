using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportAbility : MonoBehaviour
{
    public float teleportRadius = 5f;
    public LayerMask groundLayer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2) && GameManager.getTeleport() > 0)
        {
            Teleport();
            GameManager.reduceTeleport();
        }
    }

    void Teleport()
    {
        Vector3 randomPosition = GenerateRandomPosition();
        if (IsValidPosition(randomPosition))
        {
            transform.position = randomPosition;
        }
        else
        {
            Debug.Log("No se pudo encontrar una posici�n v�lida para teletransportarse.");
        }
    }

    Vector3 GenerateRandomPosition()
    {
        Vector3 playerPos = transform.position;
        Vector3 randomOffset = Random.insideUnitSphere * teleportRadius;
        randomOffset.y = 0f;
        return playerPos + randomOffset;
    }

    bool IsValidPosition(Vector3 position)
    {
        RaycastHit hit;
        if (Physics.Raycast(position, Vector3.down, out hit, Mathf.Infinity, groundLayer))
        {
            return true;
        }
        return false;
    }
}