using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] private Rigidbody2D bulletRb;
    [SerializeField] private float bulletSpeed;
    void Start()
    {
        transform.localScale = new Vector2(PlayerMovement.lastAxis, 1);
        bulletRb.velocity = new Vector2(PlayerMovement.lastAxis * bulletSpeed, 0);
    }

}
