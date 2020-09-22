using UnityEngine;

public class Tank_Enemy_Turret_Behavior : MonoBehaviour
{

    #region Variables

    private float speedRotation = 0.7f; // velocidade de rotaçao

    public Transform tankFront; // transform da frente do tank
    [HideInInspector]
    public Transform targetForTurret; // armazena o alvo

    #endregion

    #region Buildin Methods

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

            transform.rotation = Quaternion.Euler(0f, rotation.y, rotation.z); // rotaciona o alvo

        }

        #endregion

    }

    #endregion

}
