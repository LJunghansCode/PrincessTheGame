using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	public int damagePerSwing = 20;                  
	public float swingTime = 2f; 
	public int hitcount;
	public float range = 1f;


	float hitTimer;
	float timer;                            
	int shootableMask;                              
	public Transform player;
	Animator anim;
	EnemyAttack enemyAttack;
	AudioSource SwishAudio;




	void Awake ()
	{
		AudioSource[] audios = GetComponents<AudioSource> ();
		SwishAudio = audios [1];
		shootableMask = LayerMask.GetMask ("Shootable");

		// Set up the references
		player = GetComponent<Transform> ();
		anim = GetComponent<Animator> ();

	}

	void Update ()
	{
		
		timer += Time.deltaTime;

		if (timer > 0) {
			anim.SetBool ("is_attackin", false);
		}

		if(Input.GetButton ("Attack") && timer > swingTime)
		{
			SwishAudio.Play ();
			anim.SetBool ("is_attackin", true);
			Attack ();


		}

			
	}

	void Attack ()
	{
		timer = 0f;
		hitcount = 0;
		Vector2 size = new Vector2(.7f, 0.4f);
		Vector2 direction = player.forward;
		float angle = 180f;

		RaycastHit2D sword = Physics2D.CapsuleCast(player.position, size, CapsuleDirection2D.Vertical, angle, direction, range, shootableMask);
		bool hitsuccess = false;
		if (sword.collider != null) {

			hitsuccess = true;
			hitcount += 1;
		}

		if(hitsuccess)
		{
			EnemyHealth enemyHealth = sword.rigidbody.GetComponent <EnemyHealth> ();
			if(enemyHealth)
			{
				// ... the enemy should take damage.
				enemyHealth.TakeDamage (damagePerSwing);

			}
				
		}

	
	}
}

