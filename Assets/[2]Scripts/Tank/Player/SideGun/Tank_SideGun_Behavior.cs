using UnityEngine;

/* 
 * Lista de objetos que usam esse script
 * Tank - SideGun
 */

public class Tank_SideGun_Behavior : MonoBehaviour
{

    #region Variables

    private float rotationSpeed = 1.5f;

    public Transform targetForTurret;

    #endregion

    #region Buildin Methods

    void Update()
    {
        
        if(targetForTurret)
        {

            Vector3 direction = targetForTurret.position - transform.position; //aponta pro target
            Quaternion lookRotation = Quaternion.LookRotation(direction); // matematica da rotaçao do alvo
            Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles; // transforma a matematica do quaternion em angulos que a unity compreende (i.e. X, Y, Z)

            transform.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z); // rotaciona o alvo

        }

    }

    #endregion

}
