using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour {
	
	GameObject slotPanel;
	ItemDatabase database;
	GameObject inventoryContainer;

	public GameObject inventorySlot;
	public GameObject inventoryItem;
	public Button open;
	public Button close;

	int slotAmount;
	public List<Item> inventory = new List<Item> ();
	public List<GameObject> slots = new List<GameObject>();

	void Start(){


		inventoryContainer = GameObject.Find("Inventory Panel");
		slotPanel = inventoryContainer.transform.FindChild ("Slot Panel").gameObject;
		open = GetComponent<Button>();
		close = GetComponent<Button>();
		database = GetComponent<ItemDatabase> ();

		inventoryContainer.SetActive (false);

		slotAmount = 10;
		for (int i = 0; i < slotAmount; i++) 
		{
			//add slots
			slots.Add (Instantiate (inventorySlot));
			slots [i].transform.SetParent (slotPanel.transform);
			//make items
			inventory.Add(new Item());


		}
		Additem (0);
		Additem (1);
		Additem (2);
		Additem (2);
		Additem (2);
	}
	public void Additem(int id){
		Item itemToAdd = database.FetchByID (id);

		if (itemToAdd.Stackable && CheckItemValid (itemToAdd)) {
			for (int i = 0; i < inventory.Count; i++) {
				if (inventory [i].ID == id) {
					ItemData data = slots [i].transform.GetChild (0).GetComponent<ItemData> ();
					data.amount++;
					data.transform.GetChild (0).GetComponent<Text> ().text = data.amount.ToString ();
					break;
				}
			}
		} else {
			for (int i = 0; i < inventory.Count; i++) {
				if (inventory [i].ID == -1) {
					inventory [i] = itemToAdd;
					GameObject itemObject = Instantiate (inventoryItem);
					itemObject.transform.SetParent (slots [i].transform);
					itemObject.transform.position = Vector2.zero;
					itemObject.GetComponent<Image> ().sprite = itemToAdd.Sprite;
					itemObject.name = itemToAdd.Title;
					break;
				}

			}
		}
	}
	bool CheckItemValid(Item item)
	{
		for(int i = 0; i < inventory.Count; i++)
			if(inventory[i].ID == item.ID)
				return true;
		
		return false;
	}
	public void onPress(){
		inventoryContainer.SetActive(true);
		} 
	public void Xpress(){
		inventoryContainer.SetActive (false);
	}
	}	


