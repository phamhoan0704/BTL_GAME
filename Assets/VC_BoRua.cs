using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VC_BoRua : MonoBehaviour
{
    [SerializeField] private int damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="Player")
        collision.GetComponent<Health>().TakeDamage(damage);
    }

}
