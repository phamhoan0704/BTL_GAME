using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullHit : MonoBehaviour
{
    public float weaponDamage;
    BulletController myBull;
    public GameObject bullet;
    void Awake()
    {
        myBull = GetComponentInParent<BulletController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Shoot")
        {
           // myBull.removeForce();
            Instantiate(bullet, transform.position, transform.rotation);
            Destroy(gameObject);
            if (other.gameObject.layer == LayerMask.NameToLayer("enemy"))
            {
                enemyHealth1 hurtEnemy = other.gameObject.GetComponent<enemyHealth1>();
                hurtEnemy.addDamge(weaponDamage);
            }
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Shoot")
        {
            //myBull.removeForce();
            Instantiate(bullet, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    
}
