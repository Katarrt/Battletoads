using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform player;
    Vector2 target;
    public float speed;
    SpriteRenderer sprite;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        target = new Vector2(player.transform.position.x, player.transform.position.y);

    }


    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < 7)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }

        if (this.transform.position.x < player.transform.position.x)
        {
            sprite.flipX = true;

        }
        else
        {
            sprite.flipX = false;

        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController.health--;
            StartCoroutine(KD());
        }
    }
    IEnumerator KD()
    {
        yield return new WaitForSecondsRealtime(3);
    }
}

