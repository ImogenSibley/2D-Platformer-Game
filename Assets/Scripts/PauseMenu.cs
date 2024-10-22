using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false; //Keeps track of if game paused
    public GameObject pauseMenuUI; //Pause Menu UI Object goes here

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //if escape button is pressed
        {
            if (GameIsPaused)
            {
                Resume(); //resume if game is paused
            }
            else
            {
                Pause(); //pause if game is playing
            }
        }
    }
    
    void Pause() //Pause Game Function
    {
        pauseMenuUI.SetActive(true); //Show the pause menu
        Time.timeScale = 0f; //Freeze the game
        GameIsPaused = true;
    }

    public void Resume() //Resume Game Function
    {
        pauseMenuUI.SetActive(false); //Hide the pause menu
        Time.timeScale = 1f; // Resume the game (normal time scale)
        GameIsPaused = false;
    }

    public void LoadMainMenu() //Return to Start Screen Function
    {
        Time.timeScale = 1f; //Reset time scale back to normal
        SceneManager.LoadScene("StartScreen"); //Go back to start screen scene
    }

    public void QuitGame() //Quit Game Function
    {
        Debug.Log("Quit");
        Application.Quit(); //Only works in a built game, not in the editor
    }
}
