using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;

    public GameObject player;
    private Rigidbody2D rb; 
    public float moveSpeed;

    float speed = 2.5f;
    float range = 4;

    float startingY;
    int dirY = 1;

    void Start()
    {
        startingY = transform.position.y;   
        // rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector2 dir = (player.transform.position - transform.position).normalized;

        float rot = Mathf.Atan2(-dir.y,-dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position,player.transform.position);
        // Debug.Log(distance);

        if(distance<15)
        {
            timer += Time.deltaTime;
            if(timer > 1)
            {
                timer = 0;
                shoot();
            }        
        }

    }

    void shoot()
    {
        Instantiate(bullet, bulletPos.position,Quaternion.identity );
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime * dirY);
        if(transform.position.y < startingY || transform.position.y > startingY + range)
            dirY *= -1;

    }
    
}
