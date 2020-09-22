using UnityEngine;
using UnityEngine.UI;

public class ShotTutorial : MonoBehaviour
{

    #region Variables

    GameObject tankHotbar;
    GameObject tutorialText;
    Text text;
    GameObject tankHealthBar;
    GameObject crewCanvas;

    //private float shootingTutorialReady = 0f;
    //private float shootingTutorial = 3f;
    private bool exited = false;

    #endregion

    #region Buildin Methods

    void Start()
    {

        tutorialText = GameObject.Find("TutorialText");
        tankHealthBar = GameObject.Find("TankHealthBar");
        crewCanvas = GameObject.Find("CrewCanvas");
        tankHotbar = GameObject.Find("TankHotbar");

    }

    void Update()
    {
        
        if(exited == true)
        {

            tankHotbar.transform.localScale = new Vector3(1, 1, 1);

            text = tutorialText.GetComponent<Text>();
            text.text = "This is your tank's HOTBAR, you can toggle the MACHINEGUN by pressing Q, to shoot you MAIN GUN, wait for you gunner to aim the barrel and press the E button";

        }

    }

    private void OnTriggerEnter(Collider other)
    {

        text = tutorialText.GetComponent<Text>();
        text.text = "This is your tank's HEALTH BAR, you can see that the crew inside also has a health bar";

        tankHealthBar.transform.localScale = new Vector3(1, 1, 1);
        crewCanvas.transform.localScale = new Vector3(1, 1, 1);

    }

    private void OnTriggerExit(Collider other)
    {

        text = tutorialText.GetComponent<Text>();
        text.text = "";

        //shootingTutorialReady = Time.time + shootingTutorial;
        exited = true;

    }

    #endregion

}
