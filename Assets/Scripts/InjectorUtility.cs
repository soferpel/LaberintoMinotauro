using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InjectorUtility : MonoBehaviour
{
    public float time = 1f;
    public int heal = 2;
    public GameObject particleSystemObject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4) && GameManager.getInjector() > 0 && GameManager.getHits() > 0)
        {
            GameManager.reduceInjector();
            StartCoroutine(injectorActivate());
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

    IEnumerator injectorActivate()
    {
        ActivateParticleEffect();
        if (GameManager.getHits() == 1)
        {
            GameManager.setHits(heal);
        }
        else
        {
            GameManager.setHits(heal - 1);
        }
        yield return new WaitForSeconds(time);

        DeactivateParticleEffect();
    }
}
