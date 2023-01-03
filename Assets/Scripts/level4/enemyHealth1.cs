using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth1 : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;
    public GameObject enemyHealthEfect;//hieu ung khi enemy bị tiêu diệt;
                                       //khai báo biến tạo thanh máu
    public Slider enemyHealthSlider;
    void Start()
    {
        currentHealth = maxHealth;
        enemyHealthSlider.maxValue = maxHealth;
        enemyHealthSlider.value = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void addDamge(float damge)
    {
        currentHealth -= damge;
        enemyHealthSlider.value = currentHealth;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            Instantiate(enemyHealthEfect, transform.position, transform.rotation);
        }
    }
}
