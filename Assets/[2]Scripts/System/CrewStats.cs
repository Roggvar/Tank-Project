using UnityEngine;

public class CrewStats : MonoBehaviour
{

    #region Variables

    [Header("Base Stats")]
    public int maxHealth = 100; // vida do objeto
    public float drivingLevel = 2f; // nivel de direçao
    public float sideGunLevel = 1f; // nivel da sideGun
    public float loadingLevel = 1f; // nivel do loading
    public float firingLevel = 1f; // nivel do firing
    public float commanderLevel = 1f; // nivel do commander

    public float CurrentHealth { get; set; }
    public float CurrentDrivingLevel { get; private set; }
    public float CurrentSideGunLevel { get; private set; }
    public float CurrentLoadingLevel { get; private set; }
    public float CurrentFiringLevel { get; private set; }
    public float CurrentCommanderLevel { get; private set; }

    private CrewStats commander;

    #endregion

    #region Buildin Methods

    private void Awake()
    {

        // atualiza caso seja mudado no editor
        CurrentHealth = maxHealth; 
        CurrentDrivingLevel = drivingLevel;
        CurrentSideGunLevel = sideGunLevel;
        CurrentLoadingLevel = loadingLevel;
        CurrentFiringLevel = firingLevel;
        CurrentCommanderLevel = commanderLevel;

    }

    void Start()
    {

        commander = GameObject.Find("Commander").GetComponent<CrewStats>();

        //MUDAR DPS
        #region Temporary Solution

        if (commander.commanderLevel == 1)
        {

            commander.maxHealth += 1;


        }

        if (commander.commanderLevel == 2)
        {

            commander.maxHealth += 2;


        }

        if (commander.commanderLevel == 3)
        {

            commander.maxHealth += 3;


        }

        if (commander.commanderLevel == 4)
        {

            commander.maxHealth += 4;


        }

        if (commander.commanderLevel == 5)
        {

            commander.maxHealth += 5;


        }

        if (commander.commanderLevel == 6)
        {

            commander.maxHealth += 6;


        }

        if (commander.commanderLevel == 7)
        {

            commander.maxHealth += 7;


        }

        if (commander.commanderLevel == 8)
        {

            commander.maxHealth += 8;


        }

        if (commander.commanderLevel == 9)
        {

            commander.maxHealth += 9;


        }

        if (commander.commanderLevel == 10)
        {

            commander.maxHealth += 10;


        }

        #endregion

    }

    void Update()
    {
        
        if(CurrentHealth >= maxHealth)
        {

            CurrentHealth = maxHealth;

        }

    }

    #endregion

    #region Custom Methods

    public void TakeDamage(float damage)
    {

        CurrentHealth -= damage; // alica o dano ao objeto

        // se a vida cgear a 0, aciona o outro script
        if (CurrentHealth < 0)
        {

            CurrentHealth = 0;

        }

    }

    #endregion

}
