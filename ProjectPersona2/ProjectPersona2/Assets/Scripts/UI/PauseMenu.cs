using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }

    void Paused()
    {
        //activer notre menu pause /l'afficher
        pauseMenuUI.SetActive(true);
        //arreter le temps
        Time.timeScale = 0;
        //changer le statut du jeu (bool true or false)
        gameIsPaused = true;
    }

    public void Resume()
    {
        //desactiver notre menu pause /l'afficher
        pauseMenuUI.SetActive(false);
        //reprendre le temps
        Time.timeScale = 1;
        //changer le statut du jeu (bool true or false)
        gameIsPaused = false;
    }

    public void LoadMainMenu()
    {
        //DontDestroyOnLoad.
        SceneManager.LoadScene("MainMenu");
    }
}
