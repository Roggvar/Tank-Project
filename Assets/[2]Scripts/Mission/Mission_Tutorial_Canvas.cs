using UnityEngine;
using UnityEngine.SceneManagement;

public class Mission_Tutorial_Canvas : MonoBehaviour
{

    #region Custom Methods
    public void Continue()
    {
        Time.timeScale = 1f; // Despausa o jogo
        SceneManager.LoadScene("[2]Main_Level_Hunter"); // Troca de cena de acordo com o nome dado

    }

    public void Continue2()
    {
        Time.timeScale = 1f; // Despausa o jogo
        SceneManager.LoadScene("[3]Main_Level_Final"); // Troca de cena de acordo com o nome dado

    }

    public void LoadMenuA()
    {

        SceneManager.LoadScene("[0]Main_Level_Menu"); // carrega a cena chamada Menu

    }

    #endregion

}
