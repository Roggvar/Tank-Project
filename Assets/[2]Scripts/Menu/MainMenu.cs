using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    #region Custom Methods

    // botao de PlayGame
    public void PlayGame ()
    {

        //INICIA O JOGO
        //TUTORIAL LEVEL
        SceneManager.LoadScene("[1]Main_Level_Tutorial"); // Troca de cena de acordo com o nome dado

    }

    //TEMPORARIO - ACESSAR O LEVEL TEST
    public void TESTPLAY()
    {

        SceneManager.LoadScene("[0]TestScene_0.0.1_2"); // Troca de cena de acordo com o nome dado

    }

    // fecha a aplicaçao
    public void QUitGame ()
    {

        Application.Quit();

    }

    #endregion

}
