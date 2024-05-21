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
            // Iniciar la corrutina para cerrar el cofre después de 5 segundos
            StartCoroutine(CloseChestAfterDelay(4f));
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

    private IEnumerator CloseChestAfterDelay(float delay)
    {
        // Esperar por el tiempo especificado
        yield return new WaitForSeconds(delay);
        // Cerrar el cofre
        anim.SetBool("openChest", false);
    }
}