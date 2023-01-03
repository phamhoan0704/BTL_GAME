using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBullet : MonoBehaviour
{
    [SerializeField] private float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="DragonEnemy")
            collision.GetComponent<EnemyHealth>().TakeHit(damage);
    }
}
