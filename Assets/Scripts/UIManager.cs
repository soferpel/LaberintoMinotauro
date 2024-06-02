using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    static UIManager current;
    public TextMeshProUGUI dashText;
    public TextMeshProUGUI ghostText;
    public TextMeshProUGUI teleportText;
    public TextMeshProUGUI injectorText;
    public TextMeshProUGUI timeText;
    public Image bloodEffectImage;

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

    public static void updateDamageVisibilityUI(float visiblity)
    {
        Color c = current.bloodEffectImage.color;
        c.a = visiblity / 255f;
        current.bloodEffectImage.color = c;
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

    public static void updateInjectorUI(int injectorCount)
    {
        if(current == null) return;
        current.injectorText.text = injectorCount.ToString();
    }

    public static void updateTimeUI(float time)
    {
        if(current == null) return;
        if (time >= 0)
        {
            int minutes = Mathf.FloorToInt(time / 60F);
            int seconds = Mathf.FloorToInt(time % 60F);
            current.timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            current.timeText.color = Color.white;
            current.timeText.fontSize = 36;
        }
        else
        {
            current.timeText.text = "¡CORRE!";
            current.timeText.color = Color.red;
            current.timeText.fontSize = 22;
        }
    }
}
