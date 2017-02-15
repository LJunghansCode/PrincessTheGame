using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public Canvas gameMenu;
	public Button menu;
	Game gameScript;


	// Use this for initialization
	void Start () {
		gameMenu = gameMenu.GetComponent<Canvas> ();
		menu = menu.GetComponent<Button> ();
		gameMenu.enabled = false;
		gameScript = GetComponent<Game> ();
		

	}
	public void MenuPress(){
		if (gameMenu.enabled) {
			gameMenu.enabled = false;
		

		} else {
			gameMenu.enabled = true;
		}
	}
	public void NoPress(){
		gameMenu.enabled = false;
		menu.enabled = true;
		
	}
	public void SaveGame(){
		gameScript.Save();
	}
	public void LoadGame(){
		gameScript.Load();
	}
	public void MenuLoad(){
		gameScript.Menu ();
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
