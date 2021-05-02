using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    Joystick joystick;
    public float speed;
    public LayerMask mask;
    public int radius;
    Rigidbody2D rigidbody;
    public Animator animation;
    bool isGrounded;
    [SerializeField] GameObject GgroundCheck;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        joystick = FindObjectOfType<Joystick>();
        
    }

    
    void Update()
    {
        animation.SetFloat("speed",Mathf.Abs(joystick.Horizontal));
    }

    private void FixedUpdate()
    {
        if (joystick.Horizontal > 0)
        {
            //rigidbody.velocity = new Vector2(rigidbody.velocity.x + joystick.Horizontal * speed, rigidbody.velocity.y);
            transform.Translate(new Vector3(joystick.Horizontal * speed *Time.deltaTime,0,0));
            
        }

        if (joystick.Horizontal < 0)
        {
            //rigidbody.velocity = new Vector2(rigidbody.velocity.x + joystick.Horizontal * speed, rigidbody.velocity.y);
            transform.Translate(new Vector3(joystick.Horizontal*speed * Time.deltaTime, 0, 0));
        }

        if (joystick.Horizontal == 0) { rigidbody.velocity = new Vector2(0, 0); }



    }
}
