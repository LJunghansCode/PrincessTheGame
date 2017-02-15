using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
	GameObject Player;
	public int startingHealth = 100; 
	public float experienceVal = 6f;
	public int currentHealth;                   
	public float sinkSpeed = 2.5f;
	public Slider healthSlider;
	public float healthPanelOffset = 0.35f;
	public GameObject healthPanel;
	private Text enemyName;
	Animator anim;                             
	public bool isDead;
	AI1 followscript;
	PlayerLevel playerLevel;
	AudioSource ooh; 



	void Awake (){
		Player = GameObject.FindWithTag ("Player");
		playerLevel = Player.GetComponent<PlayerLevel> ();
		anim = GetComponent <Animator> ();
		currentHealth = startingHealth;
		followscript = GetComponent<AI1> ();
		ooh = GetComponent<AudioSource> ();


	}

	void Update ()
	{
		if (isDead) 
		{ 
			followscript.enabled = false;

		}	

	}

	public void TakeDamage (int amount) {
		ooh.Play ();
		if (isDead) {
			return;
		}

		currentHealth -= amount;
		if(currentHealth <= 0)
			
		{
			
			Death ();
		}
	}


	void Death ()
	{
		currentHealth = 1;
		anim.SetTrigger ("Death");
		anim.SetBool ("is_dead", true);
		playerLevel.GainExperience (experienceVal, "Killed Orc For " + experienceVal + " Experience");
		Destroy (gameObject, 5f);
		isDead = true;
	}
}


