using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
	//Item types: seed, harvested
	public string species = "light";
	public string itemType = "seed";
	public int quantity = 1;
	// Use this for initialization
	void Start (string iSpecies = "light", int iQuantity = 1, string iType = "seed") {
		species = iSpecies;
		quantity = iQuantity;
		itemType = iType;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool compareItems(Item itemToCompare){
		return ((itemType == itemToCompare.itemType) && (species == itemToCompare.species));
	}

	public bool addItems(Item itemtoAdd){
		if (compareItems (itemtoAdd) == true) {
			quantity += itemtoAdd.quantity;
			return true;
		} else {
			return false;
		}
	}

	public Item removeItems(Item itemtoRemove){
		if (compareItems (itemtoRemove) == true) {
			quantity -= itemtoRemove.quantity;
			if (quantity < 1) {
				quantity = 0;
			}
			return itemtoRemove;
		} else {
			return itemtoRemove;
		}
	}

	/*public static bool operator ==(Item item1, Item item2){
		return ((item1.itemType == item2.itemType) && (item1.species == item2.species));
	}

	public static bool operator !=(Item item1, Item item2){
		return !(item1 == item2);
	}*/
}
