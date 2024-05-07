using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class chest : MonoBehaviour
{
    public Animator chestAnimator;
    public GameObject player;
    public float distanciaActivacion = 3f;

    private void Update()
    {
        // Verificar si el jugador está lo suficientemente cerca del cofre y presiona la tecla Espacio
        if (Input.GetKeyDown(KeyCode.Space) && Vector3.Distance(transform.position, player.transform.position) <= distanciaActivacion)
        {
            // Activar la animación de cerrar el cofre si el Animator y la animación están disponibles
            if (chestAnimator != null)
            {
                chestAnimator.SetBool("isClosed", true);
            }
        }
    }
}