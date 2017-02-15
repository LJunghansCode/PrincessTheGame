using UnityEngine;
using System.Collections;


public class EnemyAttack : MonoBehaviour
{
	public float timeBetweenAttacks = 3f;       // The time in seconds between each attack.
	public int attackDamage = 10;               // The amount of health taken away per attack.
	Animator anim;                              // Reference to the animator component.
	GameObject player;                          // Reference to the player GameObject.
	PlayerHealth playerHealth;                  // Reference to the player's health.
	public bool playerInRange;                  // Whether player is within the trigger collider and can be attacked.
	public float timer;                                // Timer for counting up to the next attack.

	void Awake ()
	{
		// Setting up the references.
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();

	}
	void OnCollisionEnter2D (Collision2D collide) {
		{
			if (collide.gameObject == player) {
				anim.SetBool ("is_walking", false);
				playerInRange = true;

			}
		}
	}
	void OnCollisionExit2D (Collision2D other) {
		{
			if (other.gameObject == player) {
				anim.SetBool ("is_walking", true);
				playerInRange = false;
			}
		}
	}
	void Update ()
	{
		
		if (playerInRange == true) 
		{
			timer += Time.deltaTime;
			if (timer > timeBetweenAttacks) 
			{
				Attack ();
			}
			if (timer < timer) 
			{
				anim.SetBool ("is_attacking", false);
			}
		}

	}


	void Attack ()
	{
		if(playerHealth.currentHealth > 0)
		{
			timer = 0f;
			anim.SetBool ("is_attacking", true);
			playerHealth.TakeDamage (attackDamage);
		}
	}
}