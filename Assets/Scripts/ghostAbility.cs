using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ghostAbility : MonoBehaviour
{
    public float time = 3f;
    private bool activate = false;
    private List<Collider> ignorerWalls = new List<Collider>();
    public GameObject particleSystemObject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && GameManager.getGhost() > 0)
        {
            GameManager.reduceGhost();
            ActivateParticleEffect();
            StartCoroutine(ghostActivate());
        }
    }

    void ActivateParticleEffect()
    {
        particleSystemObject.SetActive(true);
    }

    void DeactivateParticleEffect()
    {
        particleSystemObject.SetActive(false);
    }

    IEnumerator ghostActivate()
    {
        activate = true;

        yield return new WaitForSeconds(time);

        activate = false;
        finishAbility();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (activate)
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
            ignorerWalls.Add(collision.collider);
            Debug.Log(collision.collider);
        }
    }

    void finishAbility()
    {
        foreach (Collider wall in ignorerWalls)
        {
            if (wall != null)
            {
                Physics.IgnoreCollision(wall, GetComponent<Collider>(), false);
            }
        }
        ignorerWalls.Clear();
        DeactivateParticleEffect(); 
    }


}
