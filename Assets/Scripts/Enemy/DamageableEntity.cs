using UnityEngine;

public class DamageableEntity : MonoBehaviour
{
    [SerializeField] private int entityHealth;

    public void TakeDamage(int damage)
    {
        entityHealth -= damage;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.TryGetComponent<BulletBehavior>(out BulletBehavior bullet))
        {
            TakeDamage(bullet.bulletDamage);
        }
    }

}
