using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	public List<Item> items = new List<Item> (10);
	public List<InventorySlotScript> slots = new List<InventorySlotScript> (10);
	public int capacity = 10;

	private int slotIndex = 0;
	public int gridWidth = 10;
	public int gridHeight = 1;
	public GameObject slotObject;

	public Inventory(){
		items = new List<Item> (capacity);
		slots = new List<InventorySlotScript> (capacity);
	}
	// Use this for initialization
	void Start () {
		slotObject = GameObject.Find("Slot");
		if (slotObject == null)
		{
			Debug.Log("Slot not found");
			return;
		}
	}
	
	// Update is called once per frame
	void Update () {
		RefreshList ();
	}

	public bool AddItem(Item addedItem){
		//Returns true if successful, false if unsuccessful
		//Check if item of same type is in Inventory
		for(int i = 0; i < items.Count; i++){
			if(items[i] != null){
				if(items[i].compareItems(addedItem) == true){
					//If so, update quantity of item in Inventory
					items[i].addItems(addedItem);
					return true;
				}
			}
		}
		//If item not found in Inventory, check if there's space in the Inventory
		if (items.Count != items.Capacity) {
			//If so, add a new instance of that item's type, then
			//readjust the list's capacity for the sake of consistency
			items.Add (addedItem);
			items.Capacity = capacity;
			print (items.Capacity);
			return true;
		}
		//Otherwise nothing happens and the operation has failed
		return false;
	}

	public bool RemoveItem(Item removedItem){
		//Return true if successful, false if something goes wrong
		//Check if item of same type is in Inventory. If so, get index
		int rIndex = CheckItem(removedItem);
		//If item is not in inventory, this function fails
		if (rIndex < 0) {
			return false;
		} else {
			//Otherwise check to see that the quantity of the removed item does not exceed what exists in the inventory
			if (items [rIndex].quantity < removedItem.quantity) {
				return false;
			} else {
				items [rIndex].removeItems (removedItem);
				//If new quantity is 0 remove item from inventory completely and set size of list back to intended value
				items.RemoveAt(rIndex);
				items.Capacity = capacity;
				return true;
			}
		}
	}

	public void RefreshList(){
		//Remove entries with quantity zero
		for(int i = 0; i < items.Count; i++){
			if(items[i] != null){
				if(items[i].quantity <= 0){
					items.RemoveAt(i);
				}
			}
		}
		items.Capacity = capacity;
		//Keep contents of inventory slots up to date
		for (int i = 0; i < slots.Capacity; i++) {
			if (i >= items.Count) {
				slots [i].itemInSlot = null;
			} else {
				slots [i].itemInSlot = items [i];
			}
		}
	}

	public int CheckItem(Item checkItem){
		//Check if item of same type is in Inventory and return index of item if so
		for(int i = 0; i < items.Count; i++){
			if(items[i] != null){
				if(items[i].compareItems(checkItem) == true){
					return i;
				}
			}
		}
		//Otherwise return -1 if item is not in Inventory
		return -1;
	}

	public void setSize(int w, int h)
	{
		gridWidth = w;
		gridHeight = h;
	}

	public int getSlotIndex(float x, float y){

	}

	public void createGrid()
	{
		Debug.Log("build");
		for (float x = 0; x < gridHeight; x++)
		{
			for (float y = 0; y < gridWidth; y++)
			{

				//Current position in grid
				Vector2 gridPos = new Vector2(x, y);

				GameObject newSlot = new GameObject();
				newSlot.slotObject.SetActive(false);

				newSlot.slotObject = (GameObject)Instantiate(slotObject, Vector2.zero, Quaternion.identity);
				InventorySlotScript slotScript = newSlot.slotObject.AddComponent<InventorySlotScript> () as InventorySlotScript;
				slotScript.tile = newSlot;

				if (newSlot == null) {
					Debug.Log ("Tile is null");
					return;
				}



				slots.Add(newSlot);

				slotIndex++;
		}
	}
}
