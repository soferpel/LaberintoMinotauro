using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class chest : MonoBehaviour
{
    public Animator chestAnimator; // Referencia al Animator del cofre

    void Update()
    {
        // Verificar si se hace clic derecho
        if (Input.GetMouseButtonDown(1))
        {
            // Reproducir la animación de apertura del cofre
            chestAnimator.SetTrigger("Open");
        }
    }
}
