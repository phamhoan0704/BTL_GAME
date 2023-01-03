using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;
    public GameObject bloodEffect;
   // public Animator anim;


    //khai báo sử dụng slider
    public Slider playerHealthSlider;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        playerHealthSlider.maxValue = maxHealth;
        playerHealthSlider.value = maxHealth;

        //anim = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addDamage(float damage)
    {
        if (damage <= 0)
            return;
        currentHealth -= damage;
        playerHealthSlider.value = currentHealth;
        if (currentHealth <= 0)
        {
            //anim.SetTrigger("die");
            makeDead();
        }

    }
    void makeDead()
    {
        Instantiate(bloodEffect,transform.position,transform.rotation);
        Destroy(gameObject);
    }
}
