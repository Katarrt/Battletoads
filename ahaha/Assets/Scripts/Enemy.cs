using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    static Transform player;
    Vector2 target;
    public float speed;
    SpriteRenderer sprite;
    Vector3 ThisPos;
    float MaxRight;
    float MaxLeft;
    Rigidbody2D rb;
    bool isFlip=true;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ThisPos = this.transform.position;
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        target = new Vector2(player.transform.position.x, player.transform.position.y);
        MaxRight = ThisPos.x + 5;
        MaxLeft = ThisPos.x - 5;

    }
    public virtual void ReceivedDamage()
    {
        Die();
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        Patrol();
        //if (Vector2.Distance(transform.position, player.position) < 7)
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        //}



        //if (this.transform.position.x < player.transform.position.x)
        //{
        //    sprite.flipX = true;

        //}
        //else
        //{
        //    sprite.flipX = false;

        //}


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


       void Patrol() {

        if (GroundDetection.Move==true )
        {
            this.transform.position = new Vector3(this.transform.position.x + speed * Time.deltaTime, this.transform.position.y, this.transform.position.z);
            isFlip = false;
            sprite.flipX = true;
        }
        if (GroundDetection.Move == false )
        {
            this.transform.position = new Vector3(this.transform.position.x - speed * Time.deltaTime, this.transform.position.y, this.transform.position.z);
            isFlip = true;
            sprite.flipX = false;
        }
        ////else if (isFlip == true && this.transform.position.x < MaxLeft)
        ////{

        ////    isFlip = false;
        ////    sprite.flipX = true;
        ////}



    }

  
}

