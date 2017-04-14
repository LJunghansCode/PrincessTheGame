using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;


public class ItemData : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
	public Item item;
	public int amount;
	public int slot;

	private ItemManager inv;
	private Tooltip tooltip;
	private Vector2 offset;

	void Start(){
		inv = GameObject.Find("InventoryPanel").GetComponent<ItemManager> ();;
		tooltip = inv.GetComponent<Tooltip> ();
	}
	public void OnPointerEnter(PointerEventData eventData)
	{
		Debug.Log(eventData);
		tooltip.Activate (item);
	}
	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.Deactivate ();
	}
}
