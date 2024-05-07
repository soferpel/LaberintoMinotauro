using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class chest : MonoBehaviour
{

    public bool interactable = false;
    private Animator anim;

    // Use this for initialization of script
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Si el jugador est� cerca y presiona la tecla Espacio
        if (interactable && Input.GetKeyDown(KeyCode.Space))
        {
            // Abrir el cofre
            anim.SetBool("openChest", true);

        }
    }

    // Cuando el jugador entra en el �rea de activaci�n
    void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entra es el jugador
        if (other.gameObject.CompareTag("Player"))
        {
            interactable = true;
        }
    }

    // Cuando el jugador sale del �rea de activaci�n
    void OnTriggerExit(Collider other)
    {
        // Verificar si el objeto que sale es el jugador
        if (other.gameObject.CompareTag("Player"))
        {
            interactable = false;
        }
    }
}