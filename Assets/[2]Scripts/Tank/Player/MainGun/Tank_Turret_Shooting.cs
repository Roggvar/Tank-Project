using UnityEngine;
using UnityEngine.UI;

/* 
 * Lista de objetos que usam esse script
 * Tank - Turret
 */

// IMPORTANT READ ME
// Todos os Vector3 tem que ser usado o .down ao inves do foward devido a posiçao global do firepoint e da turret

public class Tank_Turret_Shooting : MonoBehaviour
{

    #region Variables

    [Header("Firing Atributes")]
    public float bulletForce = 100f; // velocidade do tiro
    public float cooldownTime = 6f; // tempo de cooldown do tiro
    private float cooldownReady = 0f; // quando que o tiro estiver pronto 
    private float gunCooldownTime;
    private float reloadTime;
    private int mag = 1;
    private bool reloading = false;

    public GameObject firePoint; // ponto do tiro
    private GameObject bulletPrefab; // o tiro
    private CrewStats loader;
    private MainGunAmmoBar ammoBar;
    private LoaderManager manager;
    private GameObject reloadIcon;
    private Image image; // image da UI
    private Text text; // text da UI

    #endregion

    #region Buildin Methods

    void Start()
    {

        // alocaçao dos objectos
        firePoint = GameObject.Find("TurretFirePoint");
        bulletPrefab = Resources.Load("Player_MainGun_Bullet") as GameObject;
        loader = GameObject.Find("Loader").GetComponent<CrewStats>();
        manager = GameObject.Find("Loader").GetComponent<LoaderManager>();
        ammoBar = GameObject.Find("CannonHotbar").GetComponentInChildren<MainGunAmmoBar>();
        image = GameObject.Find("CannonButtonImage").GetComponent<Image>();
        text = GameObject.Find("CannonText").GetComponent<Text>();
        reloadIcon = GameObject.Find("ReloadIcon1");

        //MUDAR DPS
        #region Temporary Solution

        if (loader.loadingLevel == 1)
        {

            reloadTime = 0.3f;

        }

        if (loader.loadingLevel == 2)
        {

            reloadTime = 0.6f;

        }

        if (loader.loadingLevel == 3)
        {

            reloadTime = 0.9f;

        }

        if (loader.loadingLevel == 4)
        {

            reloadTime = 1.2f;

        }

        if (loader.loadingLevel == 5)
        {

            reloadTime = 1.5f;

        }

        if (loader.loadingLevel == 6)
        {

            reloadTime = 1.8f;

        }

        if (loader.loadingLevel == 7)
        {

            reloadTime = 2.1f;

        }

        if (loader.loadingLevel == 8)
        {

            reloadTime = 2.4f;

        }

        if (loader.loadingLevel == 9)
        {

            reloadTime = 2.7f;

        }

        if (loader.loadingLevel == 10)
        {

            reloadTime = 3f;

        }

        #endregion

        gunCooldownTime = cooldownTime - reloadTime;
        ammoBar.SetMaxAmmo(mag);

    }

    void Update()
    {

        ammoBar.SetAmmo(mag);

        if (reloading == true)
        {

            reloadIcon.gameObject.SetActive(true);
            image.color = Color.black;
            text.color = Color.black;

        }
        else
        {

            reloadIcon.gameObject.SetActive(false);
            image.color = Color.white;
            text.color = Color.white;

        }

        if (mag <= 0 && reloading == false && manager.toggle == true)
        {

            cooldownReady = Time.time + gunCooldownTime; // aplica o tempo de cooldown do tiro
            reloading = true;

        }

        if(reloading == true)
        {

            if(Time.time >= cooldownReady)
            {

                mag = 1;
                reloading = false;

            }

        }

        if (Time.time >= cooldownReady && mag == 1 && reloading == false) // so eh acionado quando o cooldown tiver zerado
        {

            if (Input.GetKeyDown(KeyCode.E)) //Testa a tecla E
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
        
        if(Physics.Raycast(firePoint.transform.position, firePoint.transform.TransformVector(Vector3.forward), out hit))
        {

            if(hit.transform.CompareTag("EnemyTank"))
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

        Gizmos.color = Color.green;
        Gizmos.DrawRay(firePoint.transform.position, (firePoint.transform.TransformVector(Vector3.forward)) * 100);

    }

    #endregion

}
