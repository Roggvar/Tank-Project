using UnityEngine;

public class GunnerManager : MonoBehaviour
{

    #region Variables

    [HideInInspector]public bool toggle = true; // gerencia se pode rotacionar ou n no script da turret

    private CrewStats gunnerStats;
    private TankHealthBar healthBar;

    #endregion

    #region Buildin Methods

    void Start()
    {

        gunnerStats = GameObject.Find("Gunner").GetComponent<CrewStats>();
        healthBar = GameObject.Find("GunnerHealthBar").GetComponent<TankHealthBar>();

        healthBar.SetMaxHealth(gunnerStats.maxHealth); // seta a vida maxima

    }

    void Update()
    {

        healthBar.SetHealth(gunnerStats.CurrentHealth); // atualiza com a vida atual

        // gerencia o toggle em relaçao a vida
        if(gunnerStats.CurrentHealth <= 0)
        {

            toggle = false;

        }
        else
        {

            toggle = true;

        }

    }

    #endregion

}
