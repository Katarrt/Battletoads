using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

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
    int jumpValue = 1;
    SpriteRenderer sprite;
    public Transform shootPoint;
    public GameObject bullet;
    public static float health=3;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyBroken;
    public int Numbofh;
    bool FacingRight=true;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        joystick = FindObjectOfType<Joystick>();
        
    }

    
    void Update()
    {   if (joystick.Horizontal > 0 && !FacingRight) { Flip();/*sprite.flipX = false; shootPoint.transform.position = new Vector2(0.199f, transform.position.y);*/ }
        if (joystick.Horizontal < 0 && FacingRight) { Flip();/*sprite.flipX = true; shootPoint.transform.position = new Vector2(-0.199f,transform.position.y);*/ }
        anim.SetFloat("speed",Mathf.Abs(joystick.Horizontal));
        if (isGround == true) { jumpValue = 1; /*anim.SetBool("Jump", false);*/ }
        
        

        

    }

    private void FixedUpdate()
    {
        if (health > Numbofh)
        {
            health = Numbofh;
        }
        for (int i = 0; i < hearts.Length; i++) 
        {
            if (i < Mathf.RoundToInt(health))
            {
                hearts[i].sprite = fullHeart;
            }
            else 
            {
                hearts[i].sprite = emptyBroken;
            }
        }
        if (joystick.Horizontal>0)
        {
            transform.Translate(new Vector3(1 * speed * Time.deltaTime, 0, 0));
        }
        if (joystick.Horizontal < 0)
        {
            transform.Translate(new Vector3(1 * speed * Time.deltaTime, 0, 0));
        }
        //transform.Translate(new Vector3(joystick.Horizontal * speed * Time.deltaTime, 0, 0));

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

    void Flip() {
        FacingRight = !FacingRight;
        transform.Rotate(0f, 180f, 0f);

    }


}

