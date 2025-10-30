using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public static bool isShooting;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float timeBetweenBullets;
    [SerializeField] private Transform generateBulletPos;
    private float currentTimeBetweenBullets = 0;
    void Update()
    {
        isShooting = InputActionManager.instance.GetShootAction().ReadValue<float>() > 0;

        if(!isShooting)
        {
            return;
        }
        if (currentTimeBetweenBullets > 0)
        {
            currentTimeBetweenBullets -= Time.deltaTime;
        }
        else
        {
            currentTimeBetweenBullets = timeBetweenBullets;
            GenerateBullet();
        }
    }

    private void GenerateBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, generateBulletPos.transform.position,Quaternion.identity);
    }

}
