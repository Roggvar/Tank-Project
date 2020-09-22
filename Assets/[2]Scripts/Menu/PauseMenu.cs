﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    #region Variables

    public static bool gameIsPaused = false; // gerencia se o jogo esta pausado ou n

    public GameObject pauseMenuUI;

    #endregion

    #region Buildin Methods

    void Start()
    {

        gameIsPaused = false;
        Time.timeScale = 1f;

    }

    void Update()
    {
        
        // pausa o jogo quando aperta a tecla esc
        if(Input.GetKeyDown(KeyCode.Escape))
        {

            if(gameIsPaused == true)
            {

                Resume(); // aciona o script Resume

            }
            else
            {

                Pause(); // aciona o script Pause

            }

        }

    }

    #endregion

    #region Custom Methods

    // gerencia o resume do jogo
    public void Resume ()
    {

        pauseMenuUI.SetActive(false); // desativa a interface do menu durante o jogo
        Time.timeScale = 1f; // Despausa o tempo do jogo
        gameIsPaused = false;

    }

    // gerencia o pause do jogo
    void Pause ()
    {

        pauseMenuUI.SetActive(true); // Ativa a interface do menu durante o jogo 
        Time.timeScale = 0f; // Pausa o tempo do jogo
        gameIsPaused = true;

    }

    // Gerencia a volto ao menu do jogo
    public void LoadMenu ()
    {

        Time.timeScale = 1f; // Despausa o jogo
        SceneManager.LoadScene("[0]Main_Level_Menu"); // carrega a cena chamada Menu
        gameIsPaused = false;

    }

    // Sai do jogo
    public void QuitGame ()
    {

        Application.Quit();

    }

    #endregion

}
