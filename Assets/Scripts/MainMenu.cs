using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Script to make buttons on main menu work
/// </summary>
public class MainMenu : MonoBehaviour
{
    // Enemy collision
    public GameObject enemy;
    
    /// <summary>
    /// Method to make Play button work
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// Closes game
    /// </summary>
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    /// <summary>
    /// Method that switches scene back to menu from lose
    /// </summary>
    public void Menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    /// <summary>
    /// Method that swicthes scene back to menu from win
    /// </summary>
    public void WinMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
}
