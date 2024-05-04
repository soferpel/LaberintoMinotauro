using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashAbility : MonoBehaviour
{
    public float dashDistance = 5f;
    public LayerMask groundLayer;
    public float dashForce = 10f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3) && GameManager.getDash() > 0)
        {
            dash();
            GameManager.reduceDash();
        }
    }

    void dash()
    {
        Vector3 forwardPosition = transform.position + transform.forward * dashDistance;
        if (IsValidPosition(forwardPosition))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(transform.forward * dashForce, ForceMode.Impulse);
            }
        }
        else
        {
            Debug.Log("No se pudo encontrar una posición válida para el impulso hacia adelante.");
        }
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
