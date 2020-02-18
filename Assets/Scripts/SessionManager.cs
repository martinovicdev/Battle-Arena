using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionManager : MonoBehaviour
{
    public static SessionManager sharedInstance;
    public SoundManager soundManager;

    void Awake()
    {
        if (sharedInstance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        sharedInstance = this;
        DontDestroyOnLoad(this.gameObject);
        soundManager = new SoundManager();
    }

    public static SoundManager GetMusicManager()
    {
        return sharedInstance.soundManager;
    }


}
