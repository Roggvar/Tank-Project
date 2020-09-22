using UnityEngine;
using UnityEngine.UI;

public class MovementTutorial : MonoBehaviour
{

    GameObject tutorialText;
    Text text;

    void Start()
    {

        tutorialText = GameObject.Find("TutorialText");

    }

    private void OnTriggerEnter(Collider other)
    {

        text = tutorialText.GetComponent<Text>();
        text.text = "To move your tank, use the WASD keys.";

    }

    private void OnTriggerExit(Collider other)
    {

        text = tutorialText.GetComponent<Text>();
        text.text = "";

    }

}
