using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    Joystick joystick;
    public float speed;
    public LayerMask mask;
    public float radius;
    Rigidbody2D rb;
    public Animator anim;
    bool isGround;
    [SerializeField] Transform GroundCheck;
    int jumpValue=1;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        joystick = FindObjectOfType<Joystick>();
        
    }

    
    void Update()
    {
        anim.SetFloat("speed",Mathf.Abs(joystick.Horizontal));
        if (isGround == true) { jumpValue = 1; }
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(joystick.Horizontal * speed * Time.deltaTime, 0, 0));
        isGround = Physics2D.OverlapCircle(GroundCheck.position, radius, mask);

        if (jumpValue>0) { rb.velocity = Vector2.up * joystick.Vertical*5; jumpValue--; }
        





    }
}
