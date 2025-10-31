using UnityEngine;

public class DamageableEntity : MonoBehaviour
{
    [SerializeField] private int entityHealth;
    [SerializeField] private SpriteRenderer _renderer;
    public void TakeDamage(int damage)
    {
        entityHealth -= damage;

        if(entityHealth<=0)
        {
            OnDeath();
        }
    }

    private void OnDeath()
    {
        _renderer.color = Color.red;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.TryGetComponent<BulletBehavior>(out BulletBehavior bullet))
        {
            TakeDamage(bullet.bulletDamage);
        }
    }

}
