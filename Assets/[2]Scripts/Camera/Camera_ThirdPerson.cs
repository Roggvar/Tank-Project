using UnityEngine;

/* 
 * Lista de objetos que usam esse script
 * Camera
 */

public class Camera_ThirdPerson : MonoBehaviour
{

    #region Variable

    private float yaw; // angula da camera
    private float pitch; // rotaçao da camera
    public float pitchMin = -40f; // angulo min da camera
    public float pitchMax = 85f; // angulo max da camera

    public float mouseSensitivity = 10f; // sensibilidade do mouse
    public float distanceFromTarget = 2f; // distancia da camera pro alvo
    private float rotationSmoothTime = .12f; // suavidade da camera

    private Vector3 rotationSmoothVelocity; // suavidade
    private Vector3 currentRotation; // rotaçao
    private Transform target; // alvo da camera

    #endregion


    #region Buildin Methods

    void Start()
    {

        target = GameObject.FindGameObjectWithTag("CameraPivot").transform; // acha o gameobject que tenha a tag Player

    }

    
    void LateUpdate()
    {

        yaw += Input.GetAxis("Mouse X") * mouseSensitivity; // pega o axis do mouse
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity; // pega o axis do mouse
        pitch = Mathf.Clamp(pitch, pitchMin, pitchMax); // limite de movimentaçao dos angulos da camera

        // Rotaçao da camera
        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
        transform.eulerAngles = currentRotation;

        // Distancia do alvo
        transform.position = target.position - transform.forward * distanceFromTarget;

    }

    #endregion

}
