using UnityEngine;
using UnityEngine.SceneManagement;

public class TankManager : MonoBehaviour
{

    #region Variables

    private CharacterStats tankStats;
    private TankHealthBar healthBar;

    private GameObject healingImage;
    private Player_Skills skills;

    #endregion

    #region Buildin Methods

    void Start()
    {

        tankStats = GameObject.Find("Tank_Player").GetComponent<CharacterStats>();
        skills = GameObject.Find("Tank_Player").GetComponent<Player_Skills>();
        healthBar = GameObject.Find("TankHealthBar").GetComponent<TankHealthBar>();
        healingImage = GameObject.Find("TankHealingImage");

        healthBar.SetMaxHealth(tankStats.maxHealth);

    }

    void Update()
    {

        healthBar.SetHealth(tankStats.currentHealth);

        if(tankStats.currentHealth <= 0)
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

        if (skills.canRepair == true)
        {

            healingImage.SetActive(true);

            if (tankStats.currentHealth >= 100)
            {

                healingImage.SetActive(false);

            }

        }
        else
        {

            healingImage.SetActive(false);

        }

    }

    #endregion

}
