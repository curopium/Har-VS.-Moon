using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
	//Item types: seed, harvested
	public string itemType = "seed";
	public string species = "light";
	public int quantity = 1;
	// Use this for initialization
	void Start () {
		
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

	/*public static bool operator ==(Item item1, Item item2){
		return ((item1.itemType == item2.itemType) && (item1.species == item2.species));
	}

	public static bool operator !=(Item item1, Item item2){
		return !(item1 == item2);
	}*/
}
