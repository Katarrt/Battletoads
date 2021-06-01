using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public Transform player;
    public float speed;
    Vector2 target;
    Vector2 vector2;
    
    
    
    SpriteRenderer sprite;
    Vector3 ThisPos;
    //float MaxRight;
    //float MaxLeft;
    Rigidbody2D rb;
    //bool isFlip=true;
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

   
    void Update()
    {

        if (Vector2.Distance(this.transform.position, player.transform.position) < 7) {
             target = new Vector2(player.transform.position.x, this.transform.position.y);
             vector2 = new Vector2(this.transform.position.x,this.transform.position.y);

            transform.position = Vector2.MoveTowards(vector2, target, speed * Time.deltaTime);


        }

    }
    public virtual void ReceivedDamage()
    {
        Die();
    }

    protected virtual void Die()
    {
        //Destroy(gameObject);
        this.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController.health--;
            StartCoroutine(KD());
        }
        Bullet bullet = collision.GetComponent<Bullet>();
        if (bullet)
        {
            Die();
        }

    }
    IEnumerator KD()
    {
        yield return new WaitForSecondsRealtime(3);
    }
}
