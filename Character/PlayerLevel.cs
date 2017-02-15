using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour {
	//xp
	public float startingExperience = 0;
	public float currentExperience;
	public Slider experienceSlider;
	//level
	public float level = 1f;
	public float wholeLevel = 100f;
	//message timer
	public float timer;
	public float successTime = 15f;
	public float expGainTime = 15f;



	Text successText;
	Text currentLevel;
	Text introText;
	Text gainText;


	GameObject levelGainText;
	GameObject SuccessMessage;
	GameObject CurrentLevel;
	GameObject IntroText;



	PlayerHealth playerHealth;
	PlayerAttack playerAttack;



	void Awake (){

		playerHealth = GetComponent<PlayerHealth> ();
		playerAttack = GetComponent<PlayerAttack> ();
		
		SuccessMessage = GameObject.FindGameObjectWithTag("SuccessMessage");
		CurrentLevel = GameObject.FindGameObjectWithTag("CurrentLevel");
		levelGainText = GameObject.FindGameObjectWithTag ("levelGainText");
		IntroText = GameObject.FindGameObjectWithTag ("IntroText");

		successText = SuccessMessage.GetComponent<Text> ();
		introText = IntroText.GetComponent<Text> ();
		currentLevel = CurrentLevel.GetComponent<Text> ();
		gainText = levelGainText.GetComponent<Text> ();


		currentExperience = startingExperience;

	}



	void LevelUp (){
		float leftovers;
		playerAttack.damagePerSwing += 4;
		playerHealth.currentHealth += 10;
		currentLevel = CurrentLevel.GetComponent<Text> ();
		level += 1;
		leftovers = currentExperience - wholeLevel;
		currentExperience = 0f + leftovers;
		currentLevel.text = level.ToString();
		timer = 0f;
		gainText.text = "Congratulations, You Have Reached Level " + level.ToString ();

	}
	public void QuestComplete (float experienceGain, string message) {
		GainExperience (experienceGain, message);
		}
	public void GainExperience(float amount, string message){
		messageDisplay (message);
		currentExperience += amount;
	}
	public void messageDisplay(string message){
		timer = 0f;
		successText.text = message;
	}
	public void conversationDisplay(string message){
		timer = 0f;
		introText.text = message;

	}
	void Update (){
		
		currentLevel.text = level.ToString();
		experienceSlider.value = currentExperience;

		if (currentExperience > wholeLevel) {
			LevelUp ();
		}
		timer += Time.deltaTime;
		if (timer > expGainTime) {
			successText.text = " ";
			gainText.text = " ";
			introText.text = " ";
		}
	}
}
