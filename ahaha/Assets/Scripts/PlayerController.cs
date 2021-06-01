using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //Joystick joystick;
    public float speed;
    public LayerMask mask;
    int playerMask,groundMask;
    public float radius;
    Rigidbody2D rb;
    public float jumphigh = 8;
    public Animator anim;
    bool isGround;
    [SerializeField] Transform GroundCheck;
    int jumpValue = 1;
    //SpriteRenderer sprite;
    public Transform shootPoint;
    public GameObject bullet;
    public static float health=3;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyBroken;
    public int Numbofh;
    bool FacingRight=true;
    float stopShoot = 0.3f;
    Transform tr;

    void Start()
    {
        tr = GetComponent<Transform>();
        //sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        //joystick = FindObjectOfType<Joystick>();
        playerMask = LayerMask.NameToLayer("Player");
        groundMask = LayerMask.NameToLayer("Ground");

    }

    
    void Update()
    {
        //Debug.Log(stopShoot);
        if (Input.GetKey(KeyCode.K))
        {
            
            Shoot();
            
        }
        if (/*joystick.Horizontal*//* > 0*/Input.GetKey(KeyCode.D) && !FacingRight) { Flip();/*sprite.flipX = false; shootPoint.transform.position = new Vector2(0.199f, transform.position.y);*/ }
        if (/*joystick.Horizontal*//* < 0*/Input.GetKey(KeyCode.A) && FacingRight) { Flip();/*sprite.flipX = true; shootPoint.transform.position = new Vector2(-0.199f,transform.position.y);*/ }
        //anim.SetFloat("speed",Mathf.Abs(joystick.Horizontal));
        if (isGround == true) { jumpValue = 1; /*anim.SetBool("Jump", false);*/ }

        if (rb.velocity.y > 0)
        {
            Physics2D.IgnoreLayerCollision(playerMask, groundMask, true);
        }

        else { Physics2D.IgnoreLayerCollision(playerMask, groundMask, false); }

        Run();

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

      


        //transform.Translate(new Vector3(joystick.Horizontal * speed * Time.deltaTime, 0, 0));

        isGround = Physics2D.OverlapCircle(GroundCheck.position, radius, mask);



        if (jumpValue > 0 && /*joystick.Vertical > 0.7*/Input.GetKey(KeyCode.W))
        {

            anim.SetBool("Jump", true);
            rb.velocity = Vector2.up * jumphigh;
            jumpValue--;

        }

        
        else { anim.SetBool("Jump", false); }


    }




    public void Shoot() {
        
        anim.SetBool("shoot", true);
        
        stopShoot -= Time.deltaTime;
        if (stopShoot<=0)
        {
            Instantiate(bullet, shootPoint.position, transform.rotation);
            stopShoot = 0.3f;
        }
        
      
        
    }

  

    void Flip() {
        FacingRight = !FacingRight;
        transform.Rotate(0f, 180f, 0f);

    }

    void Run() {

        if (/*joystick.Horizontal < 0*/Input.GetKey(KeyCode.A))
        {
            //anim.SetBool("Run", true);
            anim.SetFloat("speed", 0.2f);
            tr.Translate(new Vector3(1 * speed * Time.deltaTime, 0, 0));

        }
        else if (/*joystick.Horizontal>0*/Input.GetKey(KeyCode.D))
        {
            //anim.SetBool("Run" , true);
            anim.SetFloat("speed", 0.2f);
            tr.Translate(new Vector3(1 * speed * Time.deltaTime, 0, 0));

        }

        else { anim.SetBool("Run", false); anim.SetFloat("speed", 0); }

    }


}

