using UnityEngine;
using UnityEditor;

/* 
 * Lista de objetos que usam esse script
 * Editor
 */

[CustomEditor(typeof(Tank_Turret_FieldofView))]
public class Editor_FieldofView : Editor
{

    #region Buildin Methods

    // Gerencia o desenho FieldOfView do Tank no inspector
    private void OnSceneGUI()
    {

        Tank_Turret_FieldofView fov = (Tank_Turret_FieldofView)target;

        Handles.color = Color.white; // pinta de branco
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.viewRadius); // desenha

        Vector3 viewAngleA = fov.DirFromAngle(-fov.viewAngle / 2, false); // calculo a linha do angulo de visao do tank
        Vector3 viewAngleB = fov.DirFromAngle(fov.viewAngle / 2, false); // calculo a liha do angulo de visao do tank

        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleA * fov.viewRadius); // desenha a linha
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleB * fov.viewRadius); // desenha a linha

        Handles.color = Color.red; // pinta de vermelho
        foreach(Transform visibleTarget in fov.visibleTargets)
        {

            Handles.DrawLine(fov.transform.position, visibleTarget.position); // desenha a linha do alvo para o player

        }

    }

    #endregion

}
