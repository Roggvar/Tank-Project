using UnityEngine;

public class InfantryManager : MonoBehaviour
{
    #region Variables

    public CharacterStats infantryStats;
    public Animator death;

    private bool isDead = false;
    private bool toggle = false;

    #endregion

    #region Buildin Methods

    void Update()
    {

        if(infantryStats.currentHealth <= 0)
        {
            isDead = true;

            //Destroy(gameObject);

        }

        if(isDead == true)
        {

            if (toggle == false)
            {

                death.SetTrigger("death");
                toggle = true;
                gameObject.tag = "Untagged";
                gameObject.layer = LayerMask.NameToLayer("Default");

            }
        }

    }

    #endregion
}
