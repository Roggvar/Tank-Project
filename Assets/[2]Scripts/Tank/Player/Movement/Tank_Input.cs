using UnityEngine;

/* 
 * Lista de objetos que usam esse script
 * Tank
 */

public class Tank_Input : MonoBehaviour
{

    #region Variables

    private Camera cam;

    // Variaveis precisam ser public mas nao quero que apareçam no inspector || poderia ter criado uma propriedade private dps um get{}
    [HideInInspector]  public Vector3 reticlePosition;
    [HideInInspector]  public Vector3 reticleNormal;
    [HideInInspector] public float fowardInput;
    [HideInInspector] public float rotationInput;

    #endregion

    #region Builtin Methods

    //TEMPORARIO
    private void Start()
    {

        cam = Camera.main; // pega a main camera na scene

    }

    void Update()
    {

        HandleInputs(); // chama o metodo

    }

    #endregion

    #region Custom Methos

    protected virtual void HandleInputs()
    {

        fowardInput = Input.GetAxis("Vertical");
        rotationInput = Input.GetAxis("Horizontal");

    }

    #endregion

}
