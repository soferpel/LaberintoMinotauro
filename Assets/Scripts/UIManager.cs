using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    static UIManager current;
    public TextMeshProUGUI dashText;
    public TextMeshProUGUI ghostText;
    public TextMeshProUGUI teleportText;

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

    public static void updateDashUI(int dashCount)
    {
        if(current == null) return;
        current.dashText.text = dashCount.ToString();
    }

    public static void updateGhostUI(int ghostCount)
    {
        if(current == null) return;
        current.ghostText.text = ghostCount.ToString();
    }

    public static void updateTeleporthUI(int teleportCount)
    {
        if(current == null) return;
        current.teleportText.text = teleportCount.ToString();
    }
}