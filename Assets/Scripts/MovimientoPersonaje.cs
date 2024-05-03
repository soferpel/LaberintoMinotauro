using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento del jugador

    void Update()
    {
        // Obtener la entrada del teclado
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calcular el desplazamiento basado en la entrada y la velocidad
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * speed * Time.deltaTime;

        // Aplicar el desplazamiento al jugador
        transform.Translate(movement, Space.World);
    }
}