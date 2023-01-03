using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_LV2 : MonoBehaviour
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
			if (!dead)
			{
				Destroy(gameObject);
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
		currentHealth += value;
		healthBar.SetHealth(currentHealth);
	}

}
