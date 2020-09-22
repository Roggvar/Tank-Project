using UnityEngine;
using UnityEngine.UI;

public class Crew_Face : MonoBehaviour
{

    #region Variables

    private Texture fullHealth;
    private Texture semiFullHealth;
    private Texture halfHealth;
    private Texture thirdHealth;
    private Texture death;

    private RawImage objectTex;
    private Player_Skills skills;
    public GameObject healingImage;
    public CrewStats stast;

    #endregion

    #region Buildin Methods

    void Start()
    {

        objectTex = gameObject.GetComponent<RawImage>();
        skills = GameObject.Find("Tank_Player").GetComponent<Player_Skills>();

        fullHealth = Resources.Load("Bonus_PokerFace") as Texture;
        semiFullHealth = Resources.Load("Bonus_Confused") as Texture;
        halfHealth = Resources.Load("Bonus_Sad") as Texture;
        thirdHealth = Resources.Load("Bonus_Yell") as Texture;
        death = Resources.Load("T_6_head_scull_") as Texture;

        objectTex.texture = fullHealth;

    }

    void Update()
    {



        if(skills.canHeal == true)
        {

            healingImage.SetActive(true);

            if (stast.CurrentHealth >= 100)
            {

                healingImage.SetActive(false);

            }

        }
        else
        {

            healingImage.SetActive(false);

        }

        //Gerencia a imagem dependnedo da vida do objecto
        if(stast.CurrentHealth >= 76)
        {

            objectTex.texture = fullHealth;

        }

        if(stast.CurrentHealth <= 75 && stast.CurrentHealth >= 51)
        {

            objectTex.texture = semiFullHealth;

        }

        if(stast.CurrentHealth <= 50 && stast.CurrentHealth >= 26)
        {

            objectTex.texture = halfHealth;

        }

        if(stast.CurrentHealth <= 25)
        {

            objectTex.texture = thirdHealth;

        }

        if(stast.CurrentHealth <= 0)
        {

            objectTex.texture = death;

        }

    }

    #endregion

}
