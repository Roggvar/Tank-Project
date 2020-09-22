using UnityEngine;

public class Mission_Hunter_Ending : MonoBehaviour
{
    #region Variables

    public GameObject object8;
    public GameObject object9;
    public GameObject object10;
    public GameObject object11;
    public GameObject object12;
    public GameObject object13;
    public GameObject object14;
    public GameObject object15;

    public GameObject endingCanvas;

    #endregion

    #region Buildin Methods

    void Update()
    {

        if (object8 == null && object9 == null && object10 == null
            && object11 == null && object12 == null && object13 == null && object14 == null && object15 == null)
        {

            endingCanvas.SetActive(true);
            PauseMenu.gameIsPaused = true;
            Time.timeScale = 0f; // Pausa o tempo do jogo

        }

    }

    #endregion

}
