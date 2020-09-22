using UnityEngine;
using UnityEngine.UI;

public class CommanderManager : MonoBehaviour
{

    #region Variables

    private float imageAlpha = 1; // alpha da imagem do blackout
    private float alphaAmount = 50f; // quantidade que muda o alpha
    private bool toggle; // controle de blackout

    private Image ima;
    private CrewStats commanderStats;
    private TankHealthBar healthBar;

    #endregion

    #region Buildin Methods

    void Start()
    {

        //seta os objectos
        commanderStats = GameObject.Find("Commander").GetComponent<CrewStats>();
        healthBar = GameObject.Find("CommanderHealthBar").GetComponent<TankHealthBar>();
        ima = GameObject.Find("CommanderBlackOut").GetComponent<Image>();

        healthBar.SetMaxHealth(commanderStats.maxHealth); // seta a vida maxima

    }

    void Update()
    {

        healthBar.SetHealth(commanderStats.CurrentHealth); // atualiza com a vida atual

        CommanderBlackOut();

    }

    #endregion

    #region Custom Methods

    // Gerencia o blackout do comandante
    void CommanderBlackOut()
    {

        if (commanderStats.CurrentHealth <= 0)
        {

            toggle = true;

        }
        else
        {

            toggle = false;
            imageAlpha = 1;

        }

        if (toggle == true)
        {

            imageAlpha += alphaAmount * Time.deltaTime;

            // Gerencia o fade in e fade out
            if (imageAlpha >= 150)
            {

                alphaAmount = -(alphaAmount);

            }

            if (imageAlpha <= 0)
            {

                alphaAmount = -(alphaAmount);

            }


        }

        ima.CrossFadeAlpha(imageAlpha, 0.1f, false); // faz o fade in e fade out

    }

    #endregion

}
