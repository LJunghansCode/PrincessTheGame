using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	public float startingHealth = 100;
	public float currentHealth;                                   
	public Slider healthSlider; 
	public Image damageImage;                                   
	public float flashSpeed = 5f;                               
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);



	Text die;
	Animator anim;                                              
	GameObject dieBox;

	PlayerAttack playerAttack;
	playerMovement playermovement;
	bool isDead;                                                
	bool damaged;                                             


	void Awake ()
	{
		dieBox = GameObject.FindWithTag ("DEAD");
		anim = GetComponent <Animator> ();
		playerAttack = GetComponent<PlayerAttack> ();
		playermovement = GetComponent<playerMovement> ();
		die = dieBox.GetComponent<Text> ();

		currentHealth = startingHealth;
	}


	void Update ()
	{

		healthSlider.value = currentHealth;
		if (damaged) {
			damaged = false;
		}
	}


	public void TakeDamage (int amount)
	{
		damaged = true;
		currentHealth -= amount;
		healthSlider.value = currentHealth;

		if(currentHealth <= 0 && !isDead)
		{
			Death ();
		}
	}


	void Death ()
	{

		isDead = true;
		anim.SetTrigger ("Die");
		playermovement.enabled = false;
		playerAttack.enabled = false;
		die.text = "You Died...";



	}       
}
