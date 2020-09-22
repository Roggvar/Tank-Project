using UnityEngine;
using UnityEngine.UI;

/* 
 * Lista de objetos que usam esse script
 * Tank - SideGun
 */

public class Tank_SideGun_Shooting : MonoBehaviour
{

    #region Variables

    [Header("Firing Atributes")]
    public float bulletForce = 50f; // velocidade do tiro
    public float cooldownTime = 0.6f; // tempo de cooldown do tiro
    private float cooldownReady = 0f; // quando que o tiro estiver pronto 
    private bool shootingEnabled = false;
    private int mag = 15; // muniçao da metralhadora
    private float magReloadTime = 6f; // tempo de reload
    private float magReloadReady = 0f; // quando tiver pronto
    private bool reloading = false; // se ta dando reload

    public GameObject firePoint; // ponto do tiro
    private GameObject bulletPrefab; // o tiro
    private CrewStats sideGunner; // tripulante responsavel
    private SideGunnerManager manager;
    private MachineGunAmmoBar ammoBar; // Barra de muniçao
    private GameObject reloadIcon; // icone de reload
    private Image image; // image da UI
    private Text text; // text da UI

    private float gunSpread = 2f;
    private Vector3 direction;

    #endregion

    #region Buildin Methods

    void Start()
    {

        // alocaçao dos objectos
        firePoint = GameObject.Find("SideTurretFirePoint");
        sideGunner = GameObject.Find("SideGunner").GetComponent<CrewStats>();
        manager = GameObject.Find("SideGunner").GetComponent<SideGunnerManager>();
        ammoBar = GameObject.Find("MachineGunHotbar").GetComponentInChildren<MachineGunAmmoBar>();
        image = GameObject.Find("RangeButton").GetComponent<Image>();
        text = GameObject.Find("RangeText").GetComponent<Text>();
        reloadIcon = GameObject.Find("ReloadIcon");
        bulletPrefab = Resources.Load("Player_SideGun_Bullet") as GameObject;

        //MUDAR DPS
        #region Temporary Solution

        if (sideGunner.sideGunLevel == 1)
        {

            gunSpread -= 0.15f;

        }

        if (sideGunner.sideGunLevel == 2)
        {

            gunSpread -= 0.3f;

        }

        if (sideGunner.sideGunLevel == 3)
        {

            gunSpread -= 0.45f;

        }

        if (sideGunner.sideGunLevel == 4)
        {

            gunSpread -= 0.6f;

        }

        if (sideGunner.sideGunLevel == 5)
        {

            gunSpread -= 0.75f;

        }

        if (sideGunner.sideGunLevel == 6)
        {

            gunSpread -= 0.9f;

        }

        if (sideGunner.sideGunLevel == 7)
        {

            gunSpread -= 1.05f;

        }

        if (sideGunner.sideGunLevel == 8)
        {

            gunSpread -= 1.2f;

        }

        if (sideGunner.sideGunLevel == 9)
        {

            gunSpread -= 1.35f;

        }

        if (sideGunner.sideGunLevel == 10)
        {

            gunSpread -= 1.5f;

        }

        #endregion

        direction = firePoint.transform.position;
        ammoBar.SetMaxAmmo(mag);

    }

    void Update()
    {

        ammoBar.SetAmmo(mag);

        // Gerencia a imagem de reload
        if(reloading == true)
        {

            reloadIcon.gameObject.SetActive(true);

        }else
        {

            reloadIcon.gameObject.SetActive(false);

        }

        //Atirar com a metralhadora
        if (Input.GetKeyDown(KeyCode.Q)) //Testa a tecla E
        {

            if (shootingEnabled == false)
            {

                shootingEnabled = true;
                image.color = Color.black;
                text.color = Color.black;

            }
            else
            {

                shootingEnabled = false;
                image.color = Color.white;
                text.color = Color.white;

            }

        }

        // Começa o processo de recarregar a metralhadora
        if(mag <= 0 && reloading == false )
        {

            magReloadReady = Time.time + magReloadTime;
            reloading = true;

        }

        // Recarrega a metralhadora
        if(reloading == true)
        {

            if(Time.time >= magReloadReady && manager.toggle == true)
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

            if (manager.toggle == true)
            {

                Shoot();

            }

        }

    }

    #endregion

    #region Custom Methods

    void Shoot()
    {

        RaycastHit hit;

        if (Physics.Raycast(firePoint.transform.position, firePoint.transform.TransformVector(Vector3.forward), out hit))
        {

            if (hit.transform.CompareTag("EnemyInfantry"))
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
        //direction.x += Random.Range(-gunSpread, gunSpread);
        //direction.y += Random.Range(-gunSpread, gunSpread);
        direction.z += Random.Range(-gunSpread, gunSpread);

        GameObject bullet = Instantiate(bulletPrefab, direction/*firePoint.transform.position*/, firePoint.transform.rotation); // coordenadas do tiro
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        rb.AddForce(firePoint.transform.TransformVector(Vector3.forward) * bulletForce, ForceMode.Impulse); // adiciona a velocidade ao tiro

    }

    #endregion

    #region Temporary Methods

    //TEMPORARIO
    private void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawRay(firePoint.transform.position, (firePoint.transform.TransformVector(Vector3.forward)) * 100);

    }

    #endregion


}
