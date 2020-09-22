using UnityEngine;

/* 
 * Lista de objetos que usam esse script
 * 
 */

public class CharacterStats : MonoBehaviour
{

    #region Variables

    public int maxHealth = 100; // vida do objeto

    public float currentHealth { get; set; }

    #endregion

    #region Buildin Methods

    private void Awake()
    {

        currentHealth = maxHealth; // atualiza caso seja mudado no editor

    }

    #endregion

    #region Custom Methods

    // Gerencia a matematica por traz do dano
    public void TakeDamage (float damage)
    { 

        currentHealth -= damage; // alica o dano ao objeto

        // se a vida cgear a 0, aciona o outro script
        if(currentHealth <= 0)
        {

            //Debug.Log(gameObject + " Morreu");
            //Destroy(gameObject);

        }

    }

    #endregion

}
