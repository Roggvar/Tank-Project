using UnityEngine;

public class Player_SideGun_Bullet : MonoBehaviour
{

    #region Variables

    private float damage = 5f; // dano do tiro

    public GameObject playerTank;

    #endregion

    #region Buldin Methods

    void Start()
    {

        playerTank = GameObject.Find("Tank_Player");
        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), playerTank.GetComponentInChildren<Collider>());

    }

    void Update()
    {

        Destroy(gameObject, 3f); // se nao colidir com nada, dps de 5 seg ira se destruir

    }

    private void OnCollisionEnter(Collision collision)
    {

        CharacterStats target = collision.transform.GetComponent<CharacterStats>(); //Puxa de outro script

        if (target != null || collision.gameObject.tag == "EnemyInfantry") // testa se o alvo for diferente de vazio e um inimigo
        {

            target.TakeDamage(damage); // uso do script CharacterStats para o dano
            Destroy(gameObject); // quando colidir com um inimigo ira se destruir

        }

    }

    #endregion

}
