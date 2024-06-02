using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuInfo : MonoBehaviour
{
    public void GameScene()
    {
        /*
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; */
        GameManager.RestartGame();
        SceneManager.LoadScene("MainMenuInfo2");
    }

}
