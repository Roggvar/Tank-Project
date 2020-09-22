using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    #region Variables

    public CharacterStats tank;
    public TankHealthBar healthBar;

    #endregion

    #region Builin Methods

    void Start()
    {

        healthBar.SetMaxHealth(tank.maxHealth);

    }

    void Update()
    {

        healthBar.SetHealth(tank.currentHealth);

        if(tank.currentHealth <= 0)
        {

            Destroy(gameObject);

        }

    }

    #endregion

}
