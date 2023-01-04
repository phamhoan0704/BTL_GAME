using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	private float startHealth;
	public int currentHealth;
	public int maxHealth = 100;
	public HealthBar healthBar;
	private Animator anim;
	private bool dead;

	[Header("Death Sound")]
	[SerializeField] private AudioClip deathSound;
	[SerializeField] private AudioClip hurtSound;

	public GameManagerScript gameManager;

	void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
		anim = GetComponent<Animator>();
    }

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		healthBar.SetHealth(currentHealth);
		
		if (currentHealth > 0)
        {
			SoundManager.instance.PlaySound(hurtSound);
			anim.SetTrigger("hurt");
        }
        else
        {
			gameManager.GameOver();
			if (!dead)
            {
				anim.SetTrigger("die");
				if(GetComponent<DragonController>()!=null)
					GetComponent<DragonController>().enabled = false;
				dead = true;
				if(GetComponent<NJ_lv1>()!=null)
					GetComponent<NJ_lv1>().enabled = false;
				SoundManager.instance.PlaySound(deathSound);
				gameManager.GameOver();
			}
			
		}

	}
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			TakeDamage(1);
		}
	}
	public void addHealth(int value)
    {
        if (currentHealth < maxHealth)
        {
			currentHealth += value;
			healthBar.SetHealth(currentHealth);
		}

	}



}
