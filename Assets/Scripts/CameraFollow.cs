using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform Player;
    public Vector3 Offset;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Player.position - Offset;
    }
}
