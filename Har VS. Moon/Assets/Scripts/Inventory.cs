using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	List<Item> items = new List<Item>(10);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	bool AddItem(Item addedItem){
		//Check if item of same type is in Inventory
		for(int i = 0; i < 10; i++){
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
			items.Capacity = 10;
			print (items.Capacity);
			return true;
		}
		//Otherwise nothing happens and the operation has failed
		return false;
	}

	bool RemoveItem(Item removedItem){
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
				items.Capacity = 10;
				return true;
			}
		}
	}

	int CheckItem(Item addedItem){
		//Check if item of same type is in Inventory and return index of item if so
		for(int i = 0; i < 10; i++){
			if(items[i] != null){
				if(items[i].compareItems(addedItem) == true){
					return i;
				}
			}
		}
		//Otherwise return -1 if item is not in Inventory
		return -1;
	}
}
