using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePower : MonoBehaviour
{
    public float fSpeed = 20f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        transform.Translate(Vector2.left * Time.deltaTime * fSpeed);




    }
    [SerializeField] private int damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            collision.GetComponent<Health>().TakeDamage(damage);
    }
}
