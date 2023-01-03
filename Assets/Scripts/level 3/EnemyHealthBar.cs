using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    // public Slider Slider;
    // public Color Low;
    // public Color High;
    public Vector3 Offset;
    
    // public void SetHealth(float health, float maxHealth)
    // {
    //     // slider.maxValue = health;
    //     // slider.value = health;
    //     Slider.gameObject.SetActive(health<maxHealth);
    //     Slider.value = health;
    //     Slider.maxValue=maxHealth;

    //     Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, Slider.normalizedValue);

    // }

    // // public void SetHealth(int health)
    // // {
    // //     slider.value = health;
    // // }

    // void Update()
    // {
    //     Slider.transform.position= UnityEngine.Camera.main.WorldToScreenPoint(transform.parent.position +Offset);    
    // }
    public EnemyHealth enemyHealth;
    public Image fillImage;
    private Slider slider;
    public GameObject enemy;
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void SetHealth(float health, float maxHealth)
    {}

    void Update()
    {
        // Slider.transform.position= transform.parent.position + Offset; 


        if(slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }

        if(slider.value > slider.minValue && !fillImage.enabled)
        {
            fillImage.enabled = true;
        }
        
        float fillValue = enemyHealth.hitPoints / enemyHealth.maxHitPoints;
        
        if(fillValue <= slider.maxValue / 3)
        {
            fillImage.color = Color.red;
        }
        else if(fillValue > slider.maxValue / 3)
        {
            fillImage.color = Color.green;
        }
        
        slider.value = fillValue;

        if(enemyHealth.hitPoints  > 0) 
        {
            transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y + 2, enemy.transform.position.z);
        }
        // transform.position = new Vector3(220, 10, 0);
        // transform.position = UnityEngine.Camera.mai n.WorldToScreenPoint(transform.parent.position+Offset);
        if(enemyHealth.hitPoints  <=0) 
        {
            Destroy(gameObject);
        }
    }

}
