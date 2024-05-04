using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dahsPotion : MonoBehaviour
{
    int playerLayer;

    void Start()
    {
        playerLayer = LayerMask.NameToLayer("Player");
        Debug.Log(playerLayer);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer != playerLayer) return;
        GameManager.updateDash();
        gameObject.SetActive(false);
    }

}
