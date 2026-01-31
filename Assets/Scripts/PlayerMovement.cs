using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    void Update()
    {
        var worldPoint =
        Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPoint.z = 0;
        transform.position = worldPoint;
    }
}