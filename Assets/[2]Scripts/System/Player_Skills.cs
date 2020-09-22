using UnityEngine;
using UnityEngine.UI;

public class Player_Skills : MonoBehaviour
{

    #region Variables
    private float healingActive = 0f;
    private float healingActiveTimer = 30f;
    private float healingCooldown = 90f;
    private float healingCooldownReady = 0f;
    [HideInInspector] public bool canHeal = false;
    private bool skillController = false;

    [HideInInspector] public bool canRepair = false;
    private bool skillControllerRepair = false;
    private float repairActive = 0f;
    private float repairActiveTimer = 10f;
    private float repairCooldown = 60f;
    private float repairCooldownReady = 0f;

    private CrewStats commander;
    private CrewStats driver;
    private CrewStats loader;
    private CrewStats gunner;
    private CrewStats sideGunner;
    private CharacterStats tank;
    private Image healingImage; // image da UI
    private Text healingText; // text da UI
    private Image repairImage; // image da UI
    private Text repairText; // text da UI

    #endregion

    #region Buildin Methods

    void Start()
    {

        commander = GameObject.Find("Commander").GetComponent<CrewStats>();
        driver = GameObject.Find("Driver").GetComponent<CrewStats>();
        loader = GameObject.Find("Loader").GetComponent<CrewStats>();
        gunner = GameObject.Find("Gunner").GetComponent<CrewStats>();
        tank = GameObject.Find("Tank_Player").GetComponent<CharacterStats>();
        sideGunner = GameObject.Find("SideGunner").GetComponent<CrewStats>();
        healingImage = GameObject.Find("HealingButton").GetComponent<Image>();
        healingText = GameObject.Find("HealingText").GetComponent<Text>();
        repairImage = GameObject.Find("RepairButtonImage").GetComponent<Image>();
        repairText = GameObject.Find("ReapirText").GetComponent<Text>();

    }

    void Update()
    {

        HealingMech();
        RepairMech();

    }

    #endregion

    #region Custom Methods

    void HealingMech()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1) && Time.time >= healingCooldownReady && canHeal == false)
        {

            canHeal = true;
            skillController = true;
            healingCooldownReady = Time.time + healingCooldown;
            healingActive = Time.time + healingActiveTimer;

            healingImage.fillAmount = 0;

        }

        if (canHeal == true)
        {

            commander.CurrentHealth += Time.deltaTime;
            driver.CurrentHealth += Time.deltaTime;
            loader.CurrentHealth += Time.deltaTime;
            gunner.CurrentHealth += Time.deltaTime;
            sideGunner.CurrentHealth += Time.deltaTime;

            healingImage.color = Color.black;
            healingText.color = Color.black;

            if (Time.time >= healingActive)
            {

                canHeal = false;

            }

        }

        if(Time.time >= healingCooldownReady)
        {

            healingImage.color = Color.white;
            healingText.color = Color.white;
            skillController = false;

        }

        if(skillController == true)
        {

            healingImage.fillAmount += Time.deltaTime / healingCooldown;

        }

    }

    void RepairMech()
    {

        if (Input.GetKeyDown(KeyCode.Alpha2) && Time.time >= repairCooldownReady && canRepair == false)
        {

            canRepair = true;
            skillControllerRepair = true;
            repairCooldownReady = Time.time + repairCooldown;
            repairActive = Time.time + repairActiveTimer;

            repairImage.fillAmount = 0;

        }

        if (canRepair == true)
        {

            tank.currentHealth += 5 * Time.deltaTime;

            repairImage.color = Color.black;
            repairText.color = Color.black;

            if (Time.time >= repairActive)
            {

                canRepair = false;

            }

        }

        if (Time.time >= repairCooldownReady)
        {

            repairImage.color = Color.white;
            repairText.color = Color.white;
            skillControllerRepair = false;

        }

        if (skillControllerRepair == true)
        {

            repairImage.fillAmount += Time.deltaTime / repairCooldown;

        }

    }

    #endregion

}
