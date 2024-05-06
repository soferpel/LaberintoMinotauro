using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashAbility : MonoBehaviour
{
    public float dashDistance = 5f;
    public float timeToDash = 3f;
    public LayerMask groundLayer;
    public float dashForce = 10f;
    public GameObject particleSystemObject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3) && GameManager.getDash() > 0 && !GameManager.getAbilityStatus())
        {
            GameManager.setAbilityStatus(true);
            StartCoroutine(dashActivate());
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

    IEnumerator dashActivate()
    {
        ActivateParticleEffect();

        yield return new WaitForSeconds(timeToDash);

        dash();
        GameManager.reduceDash();
        DeactivateParticleEffect();
        GameManager.setAbilityStatus(false);
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
