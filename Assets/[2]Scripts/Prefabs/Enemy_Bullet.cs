using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{

    #region Variables

    private float damage = 25f; // dano do tiro

    public GameObject playerTank;
    private CrewStats commander;
    private CrewStats driver;
    private CrewStats sideGunner;
    private CrewStats gunner;
    private CrewStats loader;

    #endregion

    #region Buldin Methods

    void Start()
    {

        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), playerTank.GetComponentInChildren<Collider>());

        commander = GameObject.Find("Commander").GetComponent<CrewStats>();
        driver = GameObject.Find("Driver").GetComponent<CrewStats>();
        sideGunner = GameObject.Find("SideGunner").GetComponent<CrewStats>();
        gunner = GameObject.Find("Gunner").GetComponent<CrewStats>();
        loader = GameObject.Find("Loader").GetComponent<CrewStats>();

    }

    void Update()
    {

        Destroy(gameObject, 3f); // se nao colidir com nada, dps de 5 seg ira se destruir

    }

    private void OnCollisionEnter(Collision collision)
    {

        CharacterStats target = collision.transform.GetComponent<CharacterStats>(); //Puxa de outro script

        if (target != null || collision.gameObject.tag == "Player") // testa se o alvo for diferente de vazio e um inimigo
        {

            target.TakeDamage(Random.Range(10, damage)); // uso do script CharacterStats para o dano
            commander.TakeDamage(Random.Range(1, damage));
            driver.TakeDamage(Random.Range(1, damage));
            loader.TakeDamage(Random.Range(1, damage));
            gunner.TakeDamage(Random.Range(1, damage));
            sideGunner.TakeDamage(Random.Range(1, damage));
            Destroy(gameObject); // quando colidir com um inimigo ira se destruir

        }

    }

    #endregion

}
