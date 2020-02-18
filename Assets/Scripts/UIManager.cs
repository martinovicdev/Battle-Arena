using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
       
    }

    public void StartGame() {
        Debug.Log("Start pressed");
        SceneManager.LoadScene(SceneNames.Level1Scene);
    }

    public void QuitGame() {
        Application.Quit();
    }


}
