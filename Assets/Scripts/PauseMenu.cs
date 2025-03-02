using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject menu; // Uses the GameObject menu


    public void Pause()
    {
        Time.timeScale = 0.0f; // Stops the game from running once paused
        menu.SetActive(true); // Sets the pause menu to show
    }

    public void Unpause()
    {
        Time.timeScale = 1.0f; // Continues the game
        menu.SetActive(false); // Sets the pause menu to disappear
    }


    public void Quit()
    {
        Application.Quit(); // Quits the program
    }

}
