using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public float distanceBehind = 5f;
    public float cameraHeight = 2f;
    public float smoothSpeed = 0.125f;

    private void Update()
    {
        Vector3 desiredPosition = target.position - target.forward * distanceBehind + Vector3.up * cameraHeight;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }

}
