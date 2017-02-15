using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;


public class Game : MonoBehaviour{ 
	
	public static Game control;

	public float level;
	public float health = 100;
	public float experience = 0;
	PlayerHealth playerHealth;
	PlayerLevel playerLevel;
	GameObject player;
	GameObject blacksmith;
	Intro intro;
	public Vector2 playerPosition;


	void Awake () {
		player = GameObject.Find ("Player");
		blacksmith = GameObject.FindWithTag ("Blacksmith");
		playerLevel = player.GetComponent <PlayerLevel> ();
		playerHealth = player.GetComponent<PlayerHealth> ();
		intro = blacksmith.GetComponent<Intro> ();

	}

	public void Save(){
		
		playerPosition = player.transform.position;
		float health = playerHealth.currentHealth;
		float experience = playerLevel.currentExperience;
		float level = playerLevel.level;
		float position_x = playerPosition.x;
		float position_y = playerPosition.y;
		bool introCompleted = intro.introCompleted;

		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerinfo.dat");
		PlayerData data = new PlayerData ();

		data.introCompleted = introCompleted;
		data.health = health;
		data.level = level;
		data.experience = experience;
		data.position_x = position_x;
		data.position_y = position_y;
		Debug.Log (position_x);
		Debug.Log (position_y);
		bf.Serialize (file, data);
		file.Close();

	}
	public void Load(){
		if (File.Exists (Application.persistentDataPath + "/playerinfo.dat")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/playerinfo.dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize (file);
			file.Close ();

			intro.introCompleted = data.introCompleted;
			playerLevel.level = data.level;
			playerHealth.currentHealth = data.health;
			playerLevel.currentExperience = data.experience;
			player.transform.position = new Vector2(data.position_x, data.position_y);

		}
	}
	public void Menu(){
		SceneManager.LoadScene ("Start Menu");
	}

}

[Serializable]
class PlayerData {
	public bool introCompleted;
	public float health;
	public float level;
	public float experience; 
	public float position_x;
	public float position_y;
}