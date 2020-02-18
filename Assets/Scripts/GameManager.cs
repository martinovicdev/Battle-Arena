using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerHandler
{
}

public class GameManager : MonoBehaviour, IPlayerHandler
{
    public PlayerController player;

    public UIManager uiManager; 

    void Start()
    {
        Time.timeScale = 1;
        player.playerDelegate = this;
    }


}
