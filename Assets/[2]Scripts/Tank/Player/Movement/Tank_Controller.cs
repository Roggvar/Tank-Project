using UnityEngine;

/* 
 * Lista de objetos que usam esse script
 * Tank
 */

[RequireComponent(typeof(Rigidbody))] // Requer um rigidbody no objeto, se nao tiver adiciona um automatico
[RequireComponent(typeof(Tank_Input))] // Requer um Tank_Input no objeto, se nao tiver adiciona um automatico
public class Tank_Controller : MonoBehaviour
{

    #region Variables

    private Rigidbody rb; // RigidBody
    private Tank_Input input; // Inputs
    private CrewStats driver; // stats do driver
    private DriverManager manager;

    [Header("Movement Atributes")]
    private float tankSpeed = 1.5f; // velocidade do tank
    private float rotationSpeed = 15f; // velocidade de rotaçao do tank

    private float tankMovingSpeed; // armazena o calculo do baseValue do tank com a skill do driver
    private float tankRotationSpeed; // armazena o calculo do baseValue do tank com a skill do driver
    private float driverSkill; // aplica a skill do driver com as variables do tank

    #endregion

    #region BuiltinMethods

    void Start()
    {

        rb = GetComponent<Rigidbody>(); // aloca o RigidBody do objeto na variavel
        input = GetComponent<Tank_Input>(); // aloca o Tank_Input do objeto na variavel
        driver = GameObject.Find("Driver").GetComponent<CrewStats>();
        manager = GameObject.Find("Driver").GetComponent<DriverManager>();

        //MUDAR DPS
        #region Temporary Solution

        if (driver.drivingLevel == 1)
        {

            driverSkill = 1f;

        }

        if (driver.drivingLevel == 2)
        {

            driverSkill = 1.2f;

        }

        if (driver.drivingLevel == 3)
        {

            driverSkill = 1.3f;

        }

        if (driver.drivingLevel == 4)
        {

            driverSkill = 1.4f;

        }

        if (driver.drivingLevel == 5)
        {

            driverSkill = 1.5f;

        }

        if (driver.drivingLevel == 6)
        {

            driverSkill = 1.6f;

        }

        if (driver.drivingLevel == 7)
        {

            driverSkill = 1.7f;

        }

        if (driver.drivingLevel == 8)
        {

            driverSkill = 1.8f;

        }

        if (driver.drivingLevel == 9)
        {

            driverSkill = 1.9f;

        }

        if (driver.drivingLevel == 10)
        {

            driverSkill = 2f;

        }

        #endregion

        tankMovingSpeed = tankSpeed * driverSkill;
        tankRotationSpeed = rotationSpeed * ((driverSkill / 2) + 0.5f);

    }

    void FixedUpdate()
    {

        HandleMovement();

    }

    #endregion

    #region Custom Methods

    protected virtual void HandleMovement()
    {

        // movimento do tank // input.fowardInput pega o W ou S do teclado, pertence a outra classe
        Vector3 wantedPosition = transform.position + (transform.forward * input.fowardInput * tankMovingSpeed * Time.deltaTime);

        // so eh acionado se o driver estiver vivo
        if (manager.toggle == true)
        {

            rb.MovePosition(wantedPosition); // move o rb do tank

        }


        // rotaçao do tank //input.rotationINput pega o A ou D do teclado, pertence a outra classe
        Quaternion wantedRotation = transform.rotation * (Quaternion.Euler(Vector3.up * (tankRotationSpeed * input.rotationInput * Time.deltaTime)));

        // so eh acionado se o driver estiver vivo
        if (manager.toggle == true)
        { 

            rb.MoveRotation(wantedRotation); // rotaciona o tank

        }

    }

    #endregion

}
