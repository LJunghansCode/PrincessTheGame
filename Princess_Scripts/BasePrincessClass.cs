using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePrincessClass : MonoBehaviour {

	private string characterClassName;
	private string characterClassDescription;
	//stats
	private int strength;
	private int staminia;
	private int intellect;

	public string CharacterClassName{
		get{return characterClassName; }
		set{ characterClassName = value;}
	}
	public string CharacterClassDescription{
		get{return characterClassDescription; }
		set{ characterClassDescription = value;}
	}
	public int Strength{
		get{return strength; }
		set{ strength = value;}
	}
	public int Staminia{
		get{return staminia; }
		set{ staminia = value;}
	}
	public int Intellect{
		get{return intellect; }
		set{ intellect = value;}
	}







}
