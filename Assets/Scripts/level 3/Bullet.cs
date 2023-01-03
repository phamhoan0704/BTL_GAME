using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   public GameObject player;
   private Rigidbody2D rb; 
   public float moveSpeed;
   public float timer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector2 dir = player.transform.position - transform.position;
        rb.velocity = new Vector2(dir.x,dir.y).normalized * moveSpeed;

        float rot = Mathf.Atan2(-dir.y,-dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // if(timer >10)
        // {
        //     Destroy(gameObject);
        // }
    }
    [SerializeField] private int damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="Player")
        {
            Destroy(gameObject);
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.tag =="Player")
    // }

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     if(other.gameObject.CompareTag("Player"))
    //     {
    //         Destroy(gameObject);
    //     }
    // }
}
