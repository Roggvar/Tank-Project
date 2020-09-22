using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Enemy_SideGun_Shooting : MonoBehaviour
{

    #region Variables

    [Header("Firing Atributes")]
    public float bulletForce = 100f; // velocidade do tiro
    public float cooldownTime = 0.6f; // tempo de cooldown do tiro
    private float cooldownReady = 0f; // quando que o tiro estiver pronto 
    private bool shootingEnabled = true;
    private int mag = 15; // muniçao da metralhadora
    private float magReloadTime = 6f; // tempo de reload
    private float magReloadReady = 0f; // quando tiver pronto
    private bool reloading = false; // se ta dando reload

    public GameObject firePoint; // ponto do tiro
    public GameObject bulletPrefab; // o tiro

    private float gunSpread = 2f;
    private Vector3 direction;

    #endregion

    #region Buildin Methods

    void Start()
    {

        // alocaçao dos objectos
        firePoint = GameObject.Find("EnemySideTurretFirePoint");

        direction = firePoint.transform.position;

    }

    void Update()
    {

        // Começa o processo de recarregar a metralhadora
        if (mag <= 0 && reloading == false)
        {

            magReloadReady = Time.time + magReloadTime;
            reloading = true;

        }

        // Recarrega a metralhadora
        if (reloading == true)
        {

            if (Time.time >= magReloadReady)
            {

                mag += 1;

                if (mag > 14)
                {

                    reloading = false;

                }

            }

        }

        if (Time.time >= cooldownReady && shootingEnabled == true && mag > 0 && reloading == false) // so eh acionado quando o cooldown tiver zerado
        {

            Shoot();

        }

    }

    #endregion

    #region Custom Methods

    void Shoot()
    {

        RaycastHit hit;

        if (Physics.Raycast(firePoint.transform.position, firePoint.transform.TransformVector(Vector3.forward), out hit))
        {

            if (hit.transform.CompareTag("PlayerInfantry"))
            {

                BulletSpawn();

                mag -= 1;
                cooldownReady = Time.time + cooldownTime; // aplica o tempo de cooldown do tiro

            }

        }

    }

    void BulletSpawn()
    {

        direction = firePoint.transform.position;
        direction.x += Random.Range(-gunSpread, gunSpread);
        direction.y += Random.Range(-gunSpread, gunSpread);
        //direction.z += Random.Range(-gunSpread, gunSpread);

        GameObject bullet = Instantiate(bulletPrefab, direction/*firePoint.transform.position*/, firePoint.transform.rotation); // coordenadas do tiro
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        rb.AddForce(firePoint.transform.TransformVector(Vector3.forward) * bulletForce, ForceMode.Impulse); // adiciona a velocidade ao tiro

    }

    #endregion

    #region Temporary Methods

    //TEMPORARIO
    private void OnDrawGizmos()
    {

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(firePoint.transform.position, (firePoint.transform.TransformVector(Vector3.forward)) * 100);

    }

    #endregion
}
