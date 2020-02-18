using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainUiCanvas : MonoBehaviour
{

    public Text scoreText;
    public Text enemyText;

    public void printScore(int count)
    {
        scoreText.text = "score: " + count;
    }

    public void printEnemy(int count)
    {
        enemyText.text = "enemy count: " + count; 
    }
}
