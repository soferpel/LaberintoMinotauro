using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void GameScene()
    {
        SceneManager.LoadScene("MainMenuInfo");
        
    }

    public void Quit()
    {
        Application.Quit();

    }
}
