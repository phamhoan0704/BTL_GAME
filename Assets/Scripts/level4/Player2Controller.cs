using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
     private float speed=8;
    public float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float horizontalInput;

    bool facingRight = true;
    bool grounded;
    //khai bao cac bien de bam
    public Transform gunTip;
    public GameObject bullet;
    float fireRate = 0.3f;//trong 0.5 s thi ban 1 lan
    float nextFire = 0;//ban ngay lap tuc
    public GameManagerScript gameManager;
    private void Awake()
    {
       
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        //player quay ben phai
        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(0.7f,0.7f,1);
            facingRight = true;
        }
           // flip();
        

        else if (horizontalInput < 0)// player quay mat sang ben trai
        {

            transform.localScale = new Vector3(-0.7f,0.7f, 1);
            facingRight = false;
        }    
        //nhay len
        if (Input.GetKey(KeyCode.Space)&&grounded)
            Jump();
        //Set animator parameters
        anim.SetBool("run1", horizontalInput != 0);
        anim.SetBool("grounded", grounded);

        //chuc nang ban dan tu ban phim
        if (Input.GetAxisRaw("Fire1") > 0)
        {
           anim.SetTrigger("attack");
            fireBullet();
        }

    }    
            
    private void Jump()
    {
        if (grounded)
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("jump");
            grounded = false;
            //anim.SetTrigger("jump");
        }
        /*else if (!isGrounded())
        {
            if (horizontalInput == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);

            wallJumpCooldown = 0;
        }*/
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
    public bool canAttack()
    {
        return horizontalInput == 0 && grounded;
    }//quay dau
   

    //Chuc nang ban dan
    void fireBullet()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if (!facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "win")
        {
            gameManager.GameWin();
        }
        if (other.gameObject.tag == "Shoot")
        { 
            anim.SetTrigger("slice");
        }

    }
}
