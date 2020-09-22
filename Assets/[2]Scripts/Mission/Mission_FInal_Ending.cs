using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission_FInal_Ending : MonoBehaviour
{
    #region Variables

    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    public GameObject object4;
    public GameObject object5;
    public GameObject object6;

    public GameObject endingCanvas;

    #endregion

    #region Buildin Methods

    void Update()
    {

        if (object1 == null && object2 == null && object3 == null && object4 == null && object5 == null
            && object6 == null)
        {

            endingCanvas.SetActive(true);
            PauseMenu.gameIsPaused = true;
            Time.timeScale = 0f; // Pausa o tempo do jogo

        }

    }

    #endregion
}
