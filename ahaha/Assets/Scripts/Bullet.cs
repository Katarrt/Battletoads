using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float BulletSpeed = 7f;
    public float BulletDamage = 15f;
    //public Rigidbody2D BulletRb;

    private void Update()
    {
        this.gameObject.transform.Translate(Vector2.right * BulletSpeed*Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {

            Destroy(this.gameObject);
        }
    }
}
