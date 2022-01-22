using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool resetButton = false;

    // Move to the next scene in the scene index when PlayGame() is called
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Quit the game when QuitGame() is called
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    // Resets Game
    public void ResetGame()
    {
        resetButton = true;
    }

    //Load scene by index number
    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
