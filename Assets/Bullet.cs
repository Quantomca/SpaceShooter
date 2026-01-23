using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float flySpeed = 5f;

    void Update()
    {
        var newPosition = transform.position;
            
        newPosition.y += Time.deltaTime * flySpeed;

        transform.position = newPosition;
    }
}