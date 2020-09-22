using UnityEngine;

public class LoaderManager : MonoBehaviour
{

    #region Variables

    [HideInInspector] public bool toggle = true;

    private CrewStats loaderStats;
    private TankHealthBar healthBar;

    #endregion

    #region Buildin Methods

    void Start()
    {

        loaderStats = GameObject.Find("Loader").GetComponent<CrewStats>();
        healthBar = GameObject.Find("LoaderHealthBar").GetComponent<TankHealthBar>();

        healthBar.SetMaxHealth(loaderStats.maxHealth);

    }

    void Update()
    {

        healthBar.SetHealth(loaderStats.CurrentHealth);

        if(loaderStats.CurrentHealth <= 0)
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
