using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideGunnerManager : MonoBehaviour
{

    #region Variables

    [HideInInspector] public bool toggle;

    private CrewStats sideGunnerStats;
    private TankHealthBar healthBar;

    #endregion

    #region Buildin Methods

    void Start()
    {

        sideGunnerStats = GameObject.Find("SideGunner").GetComponent<CrewStats>();
        healthBar = GameObject.Find("SideGunnerHealthBar").GetComponent<TankHealthBar>();

        healthBar.SetMaxHealth(sideGunnerStats.maxHealth);

    }

    void Update()
    {

        healthBar.SetHealth(sideGunnerStats.CurrentHealth);

        if(sideGunnerStats.CurrentHealth <= 0)
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
