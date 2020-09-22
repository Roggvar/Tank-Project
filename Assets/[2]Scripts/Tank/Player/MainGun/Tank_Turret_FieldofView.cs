using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Lista de objetos que usam esse script
 * Tank
 */

public class Tank_Turret_FieldofView : MonoBehaviour
{

    #region Variables

    public float viewRadius; // Tamanho do circulo

    [Range(0, 360)] // limitaçao do angulo
    public float viewAngle; // angulo que o objecto encherga

    private LayerMask targetMask; // Layermaks pros alvos
    private LayerMask obstacleMask; // Layermask pros objstaculos

    [HideInInspector] // precisa ser um array publico pro editor interagir
    public List<Transform> visibleTargets = new List<Transform>(); // lista com os transforms dos alvos
    private Collider[] targetsInViewRadius;

    private Tank_Turret_Behavior turret;

    public Vector3 DirFromAngle(float angle, bool angleIsGlobal)
    {

        // ajuda na rotaçao do alvo para acompanhar o angulo
        if (!angleIsGlobal)
        {

            angle += transform.eulerAngles.y;

        }

        return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, Mathf.Cos(angle * Mathf.Deg2Rad)); // calculo do angulo pq a geometria da unity eh diferente da vida real

    }

    #endregion

    #region Buildin Methods

    void Start()
    {

        targetMask = LayerMask.GetMask("Enemy_Tanks"); // seta a laymask pra mask do inspector
        obstacleMask = LayerMask.GetMask("Obstacles"); // seta a laymask pra mask do inspector

        turret = GetComponentInChildren<Tank_Turret_Behavior>();

        StartCoroutine("FindTargetWithDelay", .5f); // começa a subrotina

    }

    void Update()
    {

        if (visibleTargets.Count == 0) // caso nao tenha inimigos visiveis a turret ira olhar para a frente do tank
        {

            turret.targetForTurret = turret.tankFront;

        }
        else // ira olhar para o primeiro alvo da list
        {

            turret.targetForTurret = visibleTargets[0];

        }

    }

    #endregion

    #region Custom Methods

    // subrotina
    IEnumerator FindTargetWithDelay(float delay)
    {

        while (true)
        {

            yield return new WaitForSeconds(delay); // espera pelo delay estabelecido no metodo de start
            FindVisibleTargets(); // chama o metodo

        }

    }

    void FindVisibleTargets()
    {

        visibleTargets.Clear(); // limpa o array

        targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask); // pega os alvos

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {

            Transform target = targetsInViewRadius[i].transform; // pega o transform dos alvos
            Vector3 dirToTarget = (target.position - transform.position).normalized; // pega a direçao dos alvos em relaçao ao player

            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {

                float disToTarget = Vector3.Distance(transform.position, target.position); // rotrna a distancia dos alvos vs o player

                if (!Physics.Raycast(transform.position, dirToTarget, disToTarget, obstacleMask)) // se tudo se alinhar
                {

                    visibleTargets.Add(target); // adiciona o alvo no array

                }

            }

        }

    }

    #endregion

}