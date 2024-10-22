using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Required for loading scenes

public class StartMenu : MonoBehaviour
{
    // This function will be triggered when the Play button is clicked
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1"); //Starts from Level 1
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelect"); //Opens Level Select Menu
    }

    public void Options() //This will be used later to adjust options 
    {
        Debug.Log("Options");
    }

    // This function will be triggered when the Quit button is clicked
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit(); //Quit will only work in a built application
    }
}
