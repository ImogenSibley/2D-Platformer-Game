using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management


public class LevelSelect : MonoBehaviour
{
    // Function to load a specific level
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    // Optional: Function to go back to the main menu
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("StartScreen"); // Returns to start screen
    }
}
