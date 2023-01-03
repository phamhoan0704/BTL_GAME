using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 300;
    private Animator anim;
    private Rigidbody2D rgb2D;
    private Vector2 move = new Vector2();

    private void Start()
    {
        anim = GetComponent<Animator>();
        rgb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
        move = move.normalized;
        rgb2D.velocity = speed * move * Time.deltaTime;
    }

    private void Update()
    {
        if(move.x > 0)
        {
            anim.SetInteger("walk", 1);
        } 
        else if(move.y > 0)
        {
            anim.SetInteger("walk", 2);
        }  
        else
        {
            anim.SetInteger("walk", 0);
        } 
        if(move.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);

        }  
        else if(move.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }    
    }
}
