using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SalirJuego : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Check if the player presses the Escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Load the MainMenu scene
            SceneManager.LoadScene("MainMenu");
        }
    }
}
