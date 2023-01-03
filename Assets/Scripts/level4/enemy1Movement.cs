using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1Movement : MonoBehaviour
{

    public float enemySpeed;
    Rigidbody2D enemyRg;
    Animator enemyAnim;
    public GameObject enemyGB;
    bool facingRight = true;
    float facingTime = 5f;
    float nextFlip = 0f;
    bool canFlip = true;
    void Awake()
    {
        enemyRg = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponentInChildren<Animator>();

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFlip)
        {
            nextFlip = Time.time + facingTime;
            flip();
            enemyAnim.SetBool("run", true);
            if(facingRight)
            enemyRg.velocity = new Vector2(1f* enemySpeed,0);
            else
            {
                enemyRg.velocity = new Vector2(-1f * enemySpeed, 0);
            }
        }

    }
    void flip()
    {
        if (!canFlip)
        {
            return;
        }
        facingRight = !facingRight;
        Vector3 theScale = enemyGB.transform.localScale;
        theScale.x *= -1;
        enemyGB.transform.localScale = theScale;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player2")
        {
            if (facingRight && other.transform.position.x < transform.position.x)
            {
                flip();
            }
            else if (!facingRight && other.transform.position.x > transform.position.x)
            {
                flip();
            }

            canFlip = false;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "player2")
        {
            if (!facingRight)
            {
                enemyRg.AddForce(new Vector2(-1, 0) * enemySpeed);
            }
            else
                enemyRg.AddForce(new Vector2(1, 0) * enemySpeed);
            enemyAnim.SetBool("run", true);

        }


    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "player2")
        {
            canFlip = true;
            enemyRg.velocity = new Vector2(0, 0);
            //enemyAnim.SetBool("run", true);
        }
    }
}
