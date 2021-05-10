using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float bulletSpeed = 15f;
    public float bulletDamage = 15f;
    public Rigidbody2D bulletRb;

    private void fixedupdate()
    {
        bulletRb.velocity = Vector2.right * bulletSpeed;

    }
    private void oncollisionenter2d(Collision2D other)
    {
        Destroy(gameObject);
    }
}
