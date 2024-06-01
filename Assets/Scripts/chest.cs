using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{
    private BoxCollider boxCollider;
    public bool interactable = false;
    private Animator anim;

    // Use this for initialization of script
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable && Input.GetKeyDown(KeyCode.Space))
        {
            OpenChest();
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

    private void OpenChest()
    {
        anim.SetBool("openChest", true);
        boxCollider.enabled = false;  // Desactiva el BoxCollider para permitir la entrada
        StartCoroutine(CloseChestAfterDelay(4f));
    }

    private IEnumerator CloseChestAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        anim.SetBool("openChest", false);
        boxCollider.enabled = true;  // Reactiva el BoxCollider después de cerrar
    }
}
