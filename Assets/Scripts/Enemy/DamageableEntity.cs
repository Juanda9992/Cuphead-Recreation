using UnityEngine;
using DG.Tweening;
using System.Collections;
public class DamageableEntity : MonoBehaviour
{
    [SerializeField] private int entityHealth;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject animationMask;
    [SerializeField] private SpriteRenderer damageTint;
    public void TakeDamage(int damage)
    {
        entityHealth -= damage;

        StartCoroutine("DamageAnimation");

        if (entityHealth <= 0)
        {
            OnDeath();
        }
    }
    
    private IEnumerator DamageAnimation()
    {
        damageTint.DOFade(1, 0);
        animationMask.SetActive(true);
        yield return damageTint.DOFade(0, 0.1f).WaitForCompletion();
        animationMask.SetActive(false);
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
