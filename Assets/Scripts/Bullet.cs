using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float flySpeed = 5f;
    public int damage;

    void Update()
    {
        transform.position += Vector3.up * flySpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<EnemyHealth>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}