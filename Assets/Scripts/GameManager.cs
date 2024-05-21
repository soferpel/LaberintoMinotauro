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
    float visibility;

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

    public static void updateDamage()
    {
        if(current == null) return;
        current.visibility += 40f;
        if (current.visibility > 255f)
        {
            current.visibility = 255f;
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

    void StartGame()
    {
        current.dash = 0;
        UIManager.updateDashUI(current.dash);
        current.ghost = 0;
        UIManager.updateGhostUI(current.ghost);
        current.teleport = 0;
        UIManager.updateTeleporthUI(current.teleport);
        current.visibility = 0f;
    }
}
