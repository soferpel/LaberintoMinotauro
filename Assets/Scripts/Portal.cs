using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string sceneName;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            GameManager.setGame(false);
            GameManager.resetHits();
            GameManager.updateDamage(false);
            GameManager.changeTimer(false);
            SceneManager.LoadScene(sceneName);
        }
    }
}
