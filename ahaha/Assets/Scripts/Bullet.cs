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

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();


    }
    private void Start()
    {
        Destroy(gameObject, 1.4f);
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
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