using UnityEngine;

//SCRAPPED
public class Camera_Collision : MonoBehaviour
{

    #region Variables

    public float minDistance = 1f;
    public float maxDistance = 4f;
    public float smooth = 10f;
    public float distance;

    public Vector3 dirAdjusted;
    private Vector3 dir;

    #endregion

    #region Buildin Methods

    void Awake()
    {

        dir = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;

    }

    void Update()
    {

        Vector3 desiredCameraPos = transform.TransformPoint(dir * maxDistance);
        RaycastHit hit;

        if (Physics.Linecast(transform.position, desiredCameraPos, out hit))
        {

            distance = Mathf.Clamp(hit.distance, minDistance, maxDistance);

        }
        else
        {

            distance = maxDistance;

        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, dir * distance, Time.deltaTime * smooth);

    }

    #endregion

}
