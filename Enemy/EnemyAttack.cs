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
        anim = GetComponent <Animator> ();
		playerHealth = player.GetComponent <PlayerHealth> ();
        timer = 0f;

	}


	public void Attack ()
	{
        if (playerHealth.currentHealth > 0)
        {
            anim.SetBool("is_attacking", false);
            timer += Time.deltaTime;
                if (timer > timeBetweenAttacks) {
			        anim.SetBool ("is_attacking", true);
			        playerHealth.TakeDamage (attackDamage);
                    timer = 0f;
            }

        }
    }
}
