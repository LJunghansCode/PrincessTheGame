using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooltip : MonoBehaviour {
	private Item item;
	private string data;
	private GameObject tooltip;


	 void  Start()
	{
		tooltip = GameObject.Find("ToolTip");
		tooltip.SetActive(false);
	}
	public void Activate (Item item)
	{
		this.item = item;
		tooltip.SetActive(true);
	}
	public void Deactivate() {
		
	}
	public void ContstructDataString(){
		
	}
}
