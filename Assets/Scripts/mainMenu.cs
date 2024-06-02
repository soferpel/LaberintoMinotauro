using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{

    private bool isInMenu = true;

    void Update()
    {
        if (isInMenu)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void GameScene()
    {
        isInMenu = false;
        SceneManager.LoadScene("MainMenuInfo");
    }

    public void Quit()
    {
        isInMenu = false;
        Application.Quit();
    }
}
