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
        // Si el jugador está cerca y presiona la tecla Espacio
        if (interactable && Input.GetKeyDown(KeyCode.Space))
        {
            // Abrir el cofre
            anim.SetBool("openChest", true);

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interactable = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interactable = false;
        }
    }
}