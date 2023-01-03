using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float hitPoints;
    public float maxHitPoints;
    public EnemyHealthBar healthbar;
    public Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        hitPoints=maxHitPoints;
        // healthbar.SetHealth(hitPoints,maxHitPoints);
    }

    // Update is called once per frame
    public void TakeHit(float damage)
    {
        hitPoints -= damage;
        // healthbar.SetHealth(hitPoints,maxHitPoints);
        
        if(hitPoints <= 0)
        {
            // anim.Play("die");
            // anim.PlayQueued("die");
            Destroy(gameObject);
        }
    }
}
