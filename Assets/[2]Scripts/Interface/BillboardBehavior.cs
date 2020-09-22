using UnityEngine;

public class BillboardBehavior : MonoBehaviour
{

    #region Variables

    private Transform cam;

    #endregion

    #region Buildin Methods

    void Start()
    {

        cam = Camera.main.transform;

    }

    void LateUpdate()
    {

        transform.LookAt(transform.position - cam.forward); // Olha para a camera

    }

    #endregion

}
