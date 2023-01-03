using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public float runSpeed = 15;
    public GameObject projectile;
    private Rigidbody2D bossRb;
    private Vector2 rotation = new Vector2(0, 180);
    public float lBound = 54;
    public float rBound = 89;
    public float gravityModifier;


    // Start is called before the first frame update
    void Start()
    {

        bossRb = GetComponent<Rigidbody2D>();

        InvokeRepeating(nameof(Jump), 1, Random.Range(2, 6));

        InvokeRepeating(nameof(Fire), 0, 1.5f);
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Jump()
    {
        float jump = Random.Range(20, 100);
        bossRb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);


    }


    void Fire()
    {
        Instantiate(projectile, transform.position, projectile.transform.rotation);
    }
}
