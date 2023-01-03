using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator ani;
    public float speed = 6f, speedJump = 6f;
    private bool isGrounded = false;
    private float moveInput;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (moveInput == 0)
        {
            ani.SetBool("isRunning", false);
        }
        else
        {
            ani.SetBool("isRunning", true);
        }

        if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded)
            Jump();

        ani.SetBool("isGrounded", isGrounded);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, speedJump);
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    public bool canAttack()
    {
        return moveInput == 0;
    }
}
