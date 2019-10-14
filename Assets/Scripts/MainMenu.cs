using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

   // public string startLevel;


    public void NewGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadGame()
    {
        // Feature to be added soon!
    }

    public void QuitGame()
    {
        Debug.Log("Game Exicited");
        Application.Quit();
    }
}
