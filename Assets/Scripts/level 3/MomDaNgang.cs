using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomDaNgang : MonoBehaviour
{
    public float speed;
    public float range;

    float startingY;
    int dir = 1;

    // Start is called before the first frame update
    void Start()
    {
        startingY = transform.position.x;    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime * dir);
        if(transform.position.x < startingY || transform.position.x > startingY + range)
            dir *= -1;

    }
}
