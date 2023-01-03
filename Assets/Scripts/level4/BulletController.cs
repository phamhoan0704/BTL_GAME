using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed;
    Rigidbody2D rg;
    void Awake()
    {
        //Force them dong luc de cho vien dan co the bay
        rg = GetComponent<Rigidbody2D>();
        if (transform.localRotation.z > 0)
        {
            rg.AddForce(new Vector2(-1, 0) * bulletSpeed, ForceMode2D.Impulse);
        }
       
       else rg.AddForce(new Vector2(1, 0) * bulletSpeed, ForceMode2D.Impulse);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
