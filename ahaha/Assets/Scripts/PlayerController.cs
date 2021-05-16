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
    public float jumphigh = 8;
    public Animator anim;
    bool isGround;
    [SerializeField] Transform GroundCheck;
    int jumpValue=1;
    SpriteRenderer sprite;
    public Transform shootPoint;
    public GameObject bullet;
    
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        joystick = FindObjectOfType<Joystick>();
        
    }

    
    void Update()
    {   if (joystick.Horizontal > 0) { sprite.flipX = false; }
        if (joystick.Horizontal < 0) { sprite.flipX = true; }
        anim.SetFloat("speed",Mathf.Abs(joystick.Horizontal));
        if (isGround == true) { jumpValue = 1; /*anim.SetBool("Jump", false);*/ }
        
        

        

    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(joystick.Horizontal * speed * Time.deltaTime, 0, 0));
        isGround = Physics2D.OverlapCircle(GroundCheck.position, radius, mask);



        if (jumpValue > 0 && joystick.Vertical > 0.7)
        {

            anim.SetBool("Jump", true);
            rb.velocity = Vector2.up * jumphigh;
            jumpValue--;

        }

        
        else { anim.SetBool("Jump", false); }


    }



    public void Shoot() {

        anim.SetBool("shoot", true);
        Instantiate(bullet, shootPoint.position, transform.rotation);
        
       
       

    }
 
    
}


