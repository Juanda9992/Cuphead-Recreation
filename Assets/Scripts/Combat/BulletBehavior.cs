using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] private GameObject bulletExplosion;
    [SerializeField] private Rigidbody2D bulletRb;
    [SerializeField] private float bulletSpeed;
    void Start()
    {
        transform.localScale = new Vector2(PlayerMovement.lastAxis, 1);
        bulletRb.velocity = new Vector2(GetBulletSpeedDirection(), PlayerMovement.playerVerticalAxis) * bulletSpeed;


        transform.localRotation = Quaternion.Euler(0, 0, GetZRotation());
    }

    private float GetBulletSpeedDirection()
    {
        if (PlayerMovement.playerHorizontalAxis == 0 && PlayerMovement.playerVerticalAxis == 1)
        {
            return 0;
        }
        else if (PlayerMovement.playerVerticalAxis == 0 && PlayerMovement.playerHorizontalAxis == 0)
        {
            return PlayerMovement.lastAxis;
        }

        return PlayerMovement.playerHorizontalAxis;
    }

    private float GetZRotation()
    {
        if (Mathf.Abs(PlayerMovement.playerHorizontalAxis) == 1 && Math.Abs(PlayerMovement.playerVerticalAxis) == 1)
        {
            return 45 * PlayerMovement.lastAxis;
        }

        if (PlayerMovement.playerVerticalAxis == 1 && Mathf.Abs(PlayerMovement.playerHorizontalAxis) == 0)
        {
            return 90;
        }

        return 0;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(bulletExplosion,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }

}
