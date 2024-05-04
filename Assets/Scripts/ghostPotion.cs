using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostPotion : MonoBehaviour
{
    int playerLayer;

    void Start()
    {
        playerLayer = LayerMask.NameToLayer("Player");
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer != playerLayer) return;
        GameManager.updateGhost();
        gameObject.SetActive(false);
    }

}
