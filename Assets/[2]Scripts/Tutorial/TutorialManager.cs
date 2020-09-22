using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{

    #region Variables

    GameObject tankHotbar;
    GameObject tankHealthBar;
    GameObject crewCanvas;
    GameObject skills_Hotbar;
    public GameObject enemyTank;
    Text text;
    GameObject tutorialText;

    private float tutorialEndingReady;
    private float tutorialEndingCooldown = 5f;
    private bool toggle = false;

    #endregion

    #region Buildin Methods

    void Start()
    {

        tutorialText = GameObject.Find("TutorialText");
        tankHotbar = GameObject.Find("TankHotbar");
        tankHealthBar = GameObject.Find("TankHealthBar");
        crewCanvas = GameObject.Find("CrewCanvas");
        skills_Hotbar = GameObject.Find("Skills_Hotbar");

        tankHotbar.transform.localScale = new Vector3(0, 0, 0);
        tankHealthBar.transform.localScale = new Vector3(0, 0, 0);
        crewCanvas.transform.localScale = new Vector3(0, 0, 0);
        skills_Hotbar.transform.localScale = new Vector3(0, 0, 0);

    }

    void Update()
    {
        
        if(enemyTank == null)
        {

            skills_Hotbar.transform.localScale = new Vector3(1, 1, 1);

            text = tutorialText.GetComponent<Text>();
            text.text = "This is your tank's ABILITIES, you can press 1 to HEAL your crew, and 2 to REPAIR your TANK";

            if(toggle == false)
            {

                tutorialEndingReady = Time.time + tutorialEndingCooldown;
                toggle = true;

            }

            if(toggle == true && Time.time >= tutorialEndingReady)
            {

                text = tutorialText.GetComponent<Text>();
                text.text = "To finish the TUTORIAL, kill every enemy INFANTRY and TANK";

            }

        }

    }

    #endregion

}
