using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    static GameManager current;
    bool isAbilityActivate = false;
    bool isPlaying = false;
    int dash;
    int ghost;
    int teleport;
    int injector;
    float visibility;
    int hitNumber;
    public GameObject portal;
    public float timeMax = 300f;
    float actualTime;
    bool timeActivate = false;
    public GameObject enemy2;

    void Awake()
    {
        if (current != null && current != this)
        {
            Destroy(gameObject);
            return;
        }
        current = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        if (current == this)
        {
            StartGame();
            current.portal.SetActive(false);
        }
    }

    void Update()
    {
        if (current.timeActivate)
        {
            changeCounter();
        }

        if (current.hitNumber >= 4 && current.isPlaying)
        {
            current.isPlaying = false;
            current.hitNumber = 0;
            updateDamage(false);
            changeTimer(false);
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void changeCounter()
    {
        current.actualTime -= Time.deltaTime;
        UIManager.updateTimeUI(current.actualTime);
        if (current.actualTime <= 0)
        {
            current.timeActivate = false;
        }
        else if (current.actualTime <= current.timeMax / 2)
        {
            enemy2.SetActive(true);
        }
    }

    public static void changeTimer(bool status)
    {
        if (current != null)
        {
            current.timeActivate = status;
        }
    }

    public void activateTimer()
    {
        current.actualTime = current.timeMax;
        UIManager.updateTimeUI(current.actualTime);
        changeTimer(true);
    }

    public static float getActualTime()
    {
        return current != null ? current.actualTime : 0f;
    }

    public static bool setAbilityStatus(bool status)
    {
        return current != null && (current.isAbilityActivate = status);
    }

    public static bool getAbilityStatus()
    {
        return current != null && current.isAbilityActivate;
    }

    public static int getGhost()
    {
        return current != null ? current.ghost : 0;
    }

    public static int getDash()
    {
        return current != null ? current.dash : 0;
    }

    public static int getTeleport()
    {
        return current != null ? current.teleport : 0;
    }

    public static int getInjector()
    {
        return current != null ? current.injector : 0;
    }

    public static bool getGame()
    {
        return current != null && current.isPlaying;
    }

    public static void setGame(bool game)
    {
        if (current != null)
        {
            current.isPlaying = game;
        }
    }

    public static int getHits()
    {
        return current != null ? current.hitNumber : 0;
    }

    public static void takeKey()
    {
        if (current != null)
        {
            current.portal.SetActive(true);
        }
    }

    public static int setHits(int hits)
    {
        if (current != null)
        {
            current.hitNumber -= hits;
            updateDamage(false);
            return current.hitNumber;
        }
        return 0;
    }

    public static void resetHits()
    {
        if (current != null)
        {
            current.hitNumber = 0;
            updateDamage(false);
        }
    }

    public static void updateDamage(bool isAttacking)
    {
        if (current == null) return;
        if (current.hitNumber <= 4 && isAttacking)
        {
            current.hitNumber += 1;
        }
        if (current.hitNumber <= 0 && current.visibility <= 255f)
        {
            current.visibility = 0f;
        }
        else if (current.hitNumber == 1 && current.visibility <= 255f)
        {
            current.visibility = 25f;
        }
        else if (current.hitNumber == 2 && current.visibility <= 255f)
        {
            current.visibility = 125f;
        }
        else if (current.hitNumber == 3 && current.visibility <= 255f)
        {
            current.visibility = 225f;
        }
        UIManager.updateDamageVisibilityUI(current.visibility);
    }

    public static void updateDash()
    {
        if (current != null)
        {
            current.dash += 1;
            UIManager.updateDashUI(current.dash);
        }
    }

    public static void reduceDash()
    {
        if (current != null)
        {
            current.dash -= 1;
            UIManager.updateDashUI(current.dash);
        }
    }

    public static void updateGhost()
    {
        if (current != null)
        {
            current.ghost += 1;
            UIManager.updateGhostUI(current.ghost);
        }
    }

    public static void reduceGhost()
    {
        if (current != null)
        {
            current.ghost -= 1;
            UIManager.updateGhostUI(current.ghost);
        }
    }

    public static void updateTeleport()
    {
        if (current != null)
        {
            current.teleport += 1;
            UIManager.updateTeleporthUI(current.teleport);
        }
    }

    public static void reduceTeleport()
    {
        if (current != null)
        {
            current.teleport -= 1;
            UIManager.updateTeleporthUI(current.teleport);
        }
    }

    public static void updateInjector()
    {
        if (current != null)
        {
            current.injector += 1;
            UIManager.updateInjectorUI(current.injector);
        }
    }

    public static void reduceInjector()
    {
        if (current != null)
        {
            current.injector -= 1;
            UIManager.updateInjectorUI(current.injector);
        }
    }

    void StartGame()
    {
        current.dash = 0;
        UIManager.updateDashUI(current.dash);
        current.ghost = 0;
        UIManager.updateGhostUI(current.ghost);
        current.teleport = 0;
        UIManager.updateTeleporthUI(current.teleport);
        current.hitNumber = 0;
        current.injector = 0;
        UIManager.updateInjectorUI(current.injector);
        current.visibility = 0f;
        current.isPlaying = true;
        activateTimer();
    }

    public static void RestartGame()
    {
        if (current != null)
        {
            current.StartGame();
        }
    }
}
