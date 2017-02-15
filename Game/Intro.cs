using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour {


	public int orcCount = 3;
	public Transform warpTarget;
	public EnemyHealth orcOne;
	public EnemyHealth orcTwo;
	public EnemyHealth orcThree;
	public GameObject player;
	public GameObject IntroText;
	public Text count;
	public Text introText;
	public Text questTitle;
	public float timer;
	public bool orcOneDead = false;
	public bool orcTwoDead = false;
	public bool orcThreeDead = false;
	private bool doneTrig = false;
	public bool is_active = false; 
	public bool introCompleted = false;
	PlayerLevel playerLevel;


	void Awake() {
		
		IntroText = GameObject.FindWithTag ("IntroText");
		player = GameObject.FindWithTag ("Player");
		orcOne = orcOne.GetComponent <EnemyHealth> ();
		orcTwo = orcTwo.GetComponent <EnemyHealth> ();
		orcThree = orcThree.GetComponent <EnemyHealth> ();
		playerLevel = player.GetComponent <PlayerLevel> ();


	}
	 

	void OnTriggerEnter2D(Collider2D player){
		if (player.gameObject.tag == "Player") {
			if (is_active == true) {
				playerLevel.conversationDisplay ("Get to the castle! Orcs are still alive!");
			} 
			if (is_active == false && introCompleted == false) {
				is_active = true;
				playerLevel.conversationDisplay ("PRINCESS! I Have urgent news! Some orc thugs have broken into the castle gardens!" +
					"You're the best fighter in town, please go save your home!");
			}
			if (introCompleted == true) {
				playerLevel.conversationDisplay ("Thanks for your help, Princess!");

			}
		}
		}
	void Update (){
		
		introText = IntroText.GetComponent <Text> ();
		if (is_active == true) {
	
			PlayerLevel playerLevel;
			playerLevel = player.GetComponent <PlayerLevel> ();
			count = count.GetComponent <Text> ();
//			questTitle = questTitle.GetComponent <Text> ();
			count.text = "Orcs remaining: " + orcCount + "/3";
			if (orcOne.isDead && orcOneDead == false) {
				OneDead ();
			}

			if (orcTwo.isDead && orcTwoDead == false) {
				TwoDead ();
			}

			if (orcThree.isDead && orcThreeDead == false) {
				ThreeDead ();
			}

			if (orcCount == 1) {
				count.text = "Orc remaining: " + orcCount + "/3";
			}
			if (orcCount == 0 && doneTrig == false) {
				count.enabled = false;
				doneTrig = true;
				is_active = false;
				introCompleted = true; 
				playerLevel.QuestComplete (95f, "Quest Complete! +95experience Earned");
			}
		}
	}
	void OneDead (){
		orcOneDead = true;
		orcCount -= 1;
	}
	void TwoDead (){
		orcTwoDead = true;
		orcCount -= 1;
	}
	void ThreeDead (){
		orcThreeDead = true;
		orcCount -= 1;
	}

}
