using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuInfo2 : MonoBehaviour
{
    public void GameScene()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameManager.RestartGame();
        SceneManager.LoadScene("Mapa1");
    }

}
