using UnityEngine;

public class Tank_Enemy_Turret_Shooting : MonoBehaviour
{

    #region Variables

    [Header("Firing Atributes")]
    public float bulletForce = 100f; // velocidade do tiro
    public float cooldownTime = 6f; // tempo de cooldown do tiro
    private float cooldownReady = 0f; // quando que o tiro estiver pronto 
    private float gunCooldownTime;
    private int mag = 1;
    private bool reloading = false;

    public GameObject firePoint; // ponto do tiro
    public GameObject bulletPrefab; // o tiro

    #endregion

    #region Buildin Methods

    void Start()
    {

        gunCooldownTime = cooldownTime;

    }

    void Update()
    {

        if (mag <= 0 && reloading == false)
        {

            cooldownReady = Time.time + gunCooldownTime; // aplica o tempo de cooldown do tiro
            reloading = true;

        }

        if (reloading == true)
        {

            if (Time.time >= cooldownReady)
            {

                mag = 1;
                reloading = false;

            }

        }

        if (Time.time >= cooldownReady && mag == 1 && reloading == false) // so eh acionado quando o cooldown tiver zerado
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

            if (hit.transform.CompareTag("Player"))
            {

                BulletSpawn();

                mag -= 1;
                cooldownReady = Time.time + gunCooldownTime; // aplica o tempo de cooldown do tiro

            }

        }

    }

    void BulletSpawn()
    {

        GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation); // coordenadas do tiro
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        rb.AddForce(firePoint.transform.TransformVector(Vector3.forward) * bulletForce, ForceMode.Impulse); // adiciona a velocidade ao tiro

    }

    #endregion

    #region Temporary Methods

    //TEMPORARIO
    private void OnDrawGizmos()
    {

        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(firePoint.transform.position, (firePoint.transform.TransformVector(Vector3.forward)) * 100);

    }

    #endregion

}
