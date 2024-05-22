using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    static GameManager current;
    bool isAbilityActivate = false;
    int dash;
    int ghost;
    int teleport;
    int injector;
    float visibility;
    int hitNumber;

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

    public static int getHits()
    {
        return current.hitNumber;
    }

    public static int setHits(int hits)
    {
        if (current == null) return 0;
        current.hitNumber -= hits;
        heal();
        return current.hitNumber;
    }

    public static void updateDamage()
    {
        if(current == null) return;
        if (current.hitNumber == 0 && current.visibility < 255f)
        {
            current.visibility = 25f;
        }
        else if (current.hitNumber == 1 && current.visibility < 255f)
        {
            current.visibility = 125f;
        }
        else if (current.hitNumber == 2 && current.visibility < 255f)
        {
            current.visibility = 255f;
        }
        else
        {
            current.visibility = 255f;
        }
        current.hitNumber += 1;
        UIManager.updateDamageVisibilityUI(current.visibility);
    }

    public static void heal()
    {
        if(current == null) return;
        if (current.hitNumber == 0 && current.visibility < 255f)
        {
            current.visibility = 25f;
        }
        else if (current.hitNumber == 1 && current.visibility < 255f)
        {
            current.visibility = 125f;
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
    }
}
