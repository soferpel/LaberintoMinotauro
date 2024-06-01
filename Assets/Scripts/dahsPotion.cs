using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dahsPotion : MonoBehaviour
{
    int playerLayer;
    public AudioClip pickupSound;

    void Start()
    {
        playerLayer = LayerMask.NameToLayer("Player");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != playerLayer) return;
        soundEffects.current.playSound(pickupSound);
        GameManager.updateDash();
        gameObject.SetActive(false);
    }
}
