using UnityEngine;

public class DriverManager : MonoBehaviour
{

    #region Variables

    [HideInInspector] public bool toggle = true;

    private CrewStats driverGunnerStats;
    private TankHealthBar healthBar;

    #endregion

    #region Buildin Methods

    void Start()
    {

        driverGunnerStats = GameObject.Find("Driver").GetComponent<CrewStats>();
        healthBar = GameObject.Find("DriverHealthBar").GetComponent<TankHealthBar>();

        healthBar.SetMaxHealth(driverGunnerStats.maxHealth);

    }

    void Update()
    {

        healthBar.SetHealth(driverGunnerStats.CurrentHealth);

        if(driverGunnerStats.CurrentHealth <= 0)
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
