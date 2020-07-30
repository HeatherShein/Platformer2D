using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    #region Variables
    public GameObject player;
    public float timeOffset;
    public Vector3 posOffset;

    private Vector3 velocity;
    #endregion

    void Update()
    {
        // Updates camera position based on player movement
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, timeOffset);
    }
}
