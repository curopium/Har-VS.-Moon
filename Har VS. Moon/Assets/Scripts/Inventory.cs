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
					items[i].addItems(addedItem);
					return true;
				}
			}
		}
		return false;
	}
}
