using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SalirJuego : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Check if the player clicks the mouse button (left click)
        if (Input.GetMouseButtonDown(0))
        {
            // Load the MainMenu scene
            SceneManager.LoadScene("MainMenu");
        }
    }
}
