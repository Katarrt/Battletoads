using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float BulletSpeed = 15f;
    public float BulletDamage = 15f;
    public Rigidbody2D BulletRb;

    private void Fixedupdate()
    {
        BulletRb.velocity = Vector2.right * BulletSpeed;
    }
    private void Oncollisionenter2d(Collision2D other)
    {
        Destroy(gameObject);
    }
}
