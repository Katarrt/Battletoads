using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bullet : MonoBehaviour
{
    [SerializeField]
    public Vector3 direction;
    private float speed = 30f;
    private SpriteRenderer sprite;
    public Vector3 Direction { set { direction = value; } }
    private GameObject parent;
    public GameObject Parent { set { parent = value; } get { return parent; } }
    Rigidbody2D rb;
    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();


    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 0.5f);
    }
    private void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        //transform.Translate(transform.right* speed * Time.deltaTime);
        rb.velocity = transform.right * speed;
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        Enemy unit = collider.GetComponent<Enemy>();
        if (unit && unit.gameObject != parent)
        {
            Destroy(gameObject);
        }
    }
}