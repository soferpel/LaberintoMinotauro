using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundEffects : MonoBehaviour
{
    public static soundEffects current;
    public AudioSource audioSource;

    void Awake()
    {
        if(current != null && current != this)
        {
            //Destroy(gameObject);
            return;
        }
        current = this;
        DontDestroyOnLoad(gameObject);
    }
    
    public void playSound(AudioClip sound)
    {
        audioSource.PlayOneShot(sound);
    }
}
