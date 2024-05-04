using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    static GameManager current;
    int dash;
    int ghost;
    int teleport;

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

    public static int getGhost()
    {
        return current.ghost;
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
    }
}
