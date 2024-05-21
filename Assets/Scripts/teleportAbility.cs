using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportAbility : MonoBehaviour
{
    public float teleportRadius = 5f;
    public float timeToTeleport = 3f;
    public LayerMask groundLayer;
    public GameObject particleSystemObject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && GameManager.getTeleport() > 0 && !GameManager.getAbilityStatus())
        {
            GameManager.setAbilityStatus(true);
            StartCoroutine(teleportActivate());
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

    IEnumerator teleportActivate()
    {
        ActivateParticleEffect();

        yield return new WaitForSeconds(timeToTeleport);

        Teleport();
        GameManager.reduceTeleport();
        DeactivateParticleEffect();
        GameManager.setAbilityStatus(false);
    }

    void Teleport()
    {
        Vector3 randomPosition = GenerateRandomPosition();
        if (IsValidPosition(randomPosition))
        {
            transform.position = randomPosition;
        }
    }

    Vector3 GenerateRandomPosition()
    {
        Vector3 playerPos = transform.position;
        Vector3 randomOffset = Random.insideUnitSphere * teleportRadius;
        randomOffset.y = 0f;
        return playerPos + randomOffset;
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
