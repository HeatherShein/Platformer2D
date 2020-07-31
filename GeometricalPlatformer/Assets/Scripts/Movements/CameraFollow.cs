using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    #region Variables
    public Transform target;
    public float timeOffset;
    public Vector3 posOffset;

    private Vector3 velocity;
    #endregion

    void LateUpdate()
    {
        // Updates camera position based on player movement
        transform.position = Vector3.SmoothDamp(transform.position, target.position + posOffset, ref velocity, timeOffset);
    }
}
