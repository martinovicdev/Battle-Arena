using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private AudioSource audioSource;

    private void Awake()
    {
        if (!instance)
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = Resources.Load<AudioClip>(StaticRes.MainTheme);
            audioSource.Play();
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

}
