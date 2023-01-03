using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoRua : MonoBehaviour
{
    public float speed;
    public float range;

    Rigidbody2D myRigidbody;

    float startingY;
    int dir = 1;

    // Start is called before the first frame update
    void Start()
    {
        startingY = transform.position.x;    
        myRigidbody = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime * dir);
        transform.localScale = new Vector2(-dir*(Mathf.Sign(myRigidbody.velocity.x)), transform.localScale.y);
        if(transform.position.x < startingY || transform.position.x > startingY + range)
            {
                dir *= -1;
            }
    }
}
