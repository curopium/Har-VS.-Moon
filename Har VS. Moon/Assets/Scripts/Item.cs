using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
	//Plant species: light, tree, mouse, snake, bird
	public string species = "light";
	//Item types: seed, harvested
	public string itemType = "seed";
	public int quantity = 1;

	public Item(string iSpecies = "light", string iType = "seed", int iQuantity = 1){
		species = iSpecies;
		itemType = iType;
		quantity = iQuantity;
		Start ();
	}

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

	public Item removeItems(Item itemtoRemove){
		if (compareItems (itemtoRemove) == true) {
			int removequantity = itemtoRemove.quantity;
			if (quantity - removequantity <= 0) {
				removequantity = quantity;
			}
			quantity -= removequantity;
			return new Item (species, itemType, removequantity);
		} else {
			return null;
		}
	}

	public Item removeItem(){
		if (quantity > 0) {
			quantity -= 1;
			return new Item (species, itemType, 1);
		} else {
			return null;
		}
	}

	/*public static bool operator ==(Item item1, Item item2){
		return ((item1.itemType == item2.itemType) && (item1.species == item2.species));
	}

	public static bool operator !=(Item item1, Item item2){
		return !(item1 == item2);
	}*/
}
