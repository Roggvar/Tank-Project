using UnityEngine;

/* 
 * Lista de objetos que usam esse script
 * Tank - Turret
 */

public class Tank_Turret_Behavior : MonoBehaviour
{

    #region Variables

    private float speedRotation = 0.7f; // velocidade de rotaçao

    [HideInInspector]
    public Transform tankFront; // transform da frente do tank
    [HideInInspector]
    public Transform targetForTurret; // armazena o alvo

    private CrewStats gunner;
    private GunnerManager manager;

    #endregion

    #region Buildin Methods

    void Start()
    {

        tankFront = GameObject.Find("TankFront").transform; // pega o transfomr do object
        gunner = GameObject.Find("Gunner").GetComponent<CrewStats>();
        manager = GameObject.Find("Gunner").GetComponent<GunnerManager>();

        //MUDAR DPS
        #region Temporary Solution

        if (gunner.firingLevel == 1)
        {

            speedRotation += 0.1f;

        }

        if (gunner.firingLevel == 2)
        {

            speedRotation += 0.2f;

        }

        if (gunner.firingLevel == 3)
        {

            speedRotation += 0.3f;

        }

        if (gunner.firingLevel == 4)
        {

            speedRotation += 0.4f;

        }

        if (gunner.firingLevel == 5)
        {

            speedRotation += 0.5f;

        }

        if (gunner.firingLevel == 6)
        {

            speedRotation += 0.6f;

        }

        if (gunner.firingLevel == 7)
        {

            speedRotation += 0.7f;

        }

        if (gunner.firingLevel == 8)
        {

            speedRotation += 0.8f;

        }

        if (gunner.firingLevel == 9)
        {

            speedRotation += 0.9f;

        }

        if (gunner.firingLevel == 10)
        {

            speedRotation += 1f;

        }

        #endregion

    }

    void Update()
    {

        #region Rotaçao e aquisiçao de alvos

        if (!targetForTurret) // se nao tiver alvo, volta para a posiçao original
        {

            targetForTurret = tankFront; // seta o alvo

        }

        if (targetForTurret) // olha para o alvo
        {

            Vector3 direction = targetForTurret.position - transform.position; //aponta pro target
            Quaternion lookRotation = Quaternion.LookRotation(direction); // matematica da rotaçao do alvo
            Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * speedRotation).eulerAngles; // transforma a matematica do quaternion em angulos que a unity compreende (i.e. X, Y, Z)

            if (manager.toggle == true)
            {

                transform.rotation = Quaternion.Euler(0f, rotation.y, 0f); // rotaciona o alvo

            }
        }

        #endregion

    }

    #endregion

}
