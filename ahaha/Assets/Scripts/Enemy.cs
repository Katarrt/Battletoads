using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform player;
    Vector2 target;
    public float speed;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        target = new Vector2(player.transform.position.x, player.transform.position.y);

    }

    
    void Update()
    {
        if (Vector2.Distance(transform.position,player.position)<7)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        



    }
}
