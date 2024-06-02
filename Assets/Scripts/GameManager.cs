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
        if(current != null && current != this)
        {
            Destroy(gameObject);
            return;
        }
        current = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        StartGame();
        current.portal.SetActive(false);
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
        else if (current.actualTime <= current.timeMax/2)
        {
            enemy2.SetActive(true);
        }
    }

    public void changeTimer(bool status)
    {
        current.timeActivate = status;
    }

    public void activateTimer()
    {
        current.actualTime = current.timeMax;
        changeTimer(true);
    }

    public void desactivateTimer()
    {
        changeTimer(false);
    }

    public static bool setAbilityStatus(bool status)
    {
        return current.isAbilityActivate = status;
    }

    public static bool getAbilityStatus()
    {
        return current.isAbilityActivate;
    }

    public static int getGhost()
    {
        return current.ghost;
    }

    public static int getDash()
    {
        return current.dash;
    }

    public static int getTeleport()
    {
        return current.teleport;
    }

    public static int getInjector()
    {
        return current.injector;
    }

    public static bool getGame()
    {
        return current.isPlaying;
    }

    public static int getHits()
    {
        return current.hitNumber;
    }

    public static void takeKey()
    {
        current.portal.SetActive(true);
    }

    public static int setHits(int hits)
    {
        if (current == null) return 0;
        current.hitNumber -= hits;
        updateDamage(false);
        return current.hitNumber;
    }

    public static void updateDamage(bool isAttacking)
    {
        if(current == null) return;
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
        if(current == null) return;
        current.dash += 1;
        UIManager.updateDashUI(current.dash);
    }

    public static void reduceDash()
    {
        if(current == null) return;
        current.dash -= 1;
        UIManager.updateDashUI(current.dash);
    }

    public static void updateGhost()
    {
        if(current == null) return;
        current.ghost += 1;
        UIManager.updateGhostUI(current.ghost);
    }

    public static void reduceGhost()
    {
        if(current == null) return;
        current.ghost -= 1;
        UIManager.updateGhostUI(current.ghost);
    }

    public static void updateTeleport()
    {
        if(current == null) return;
        current.teleport += 1;
        UIManager.updateTeleporthUI(current.teleport);
    }

    public static void reduceTeleport()
    {
        if(current == null) return;
        current.teleport -= 1;
        UIManager.updateTeleporthUI(current.teleport);
    }

    public static void updateInjector()
    {
        if(current == null) return;
        current.injector += 1;
        UIManager.updateInjectorUI(current.injector);
    }

    public static void reduceInjector()
    {
        if(current == null) return;
        current.injector -= 1;
        UIManager.updateInjectorUI(current.injector);
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
        UIManager.updateInjectorUI(current.injector);
        current.visibility = 0f;
        current.isPlaying = true;
        activateTimer();
    }
}
