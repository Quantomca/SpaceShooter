using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject explosionPrefab;
    public System.Action onDead;
    public System.Action onHealthChanged;
    public int defaultHealthPoint;
    public int healthPoint;

    public void OnTriggerEnter2D(Collider2D collision) => Die();

    protected virtual void Die()
    {
        var explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(explosion, 1);
        Destroy(gameObject);
        onDead?.Invoke();
    }


    private void Start()
    {
        healthPoint = defaultHealthPoint;
        onHealthChanged?.Invoke();
    }

    public void TakeDamage(int damage)
    {
        if (healthPoint <= 0) return;

        healthPoint -= damage;
        onHealthChanged?.Invoke();
        if (healthPoint <= 0) Die();
    }

}