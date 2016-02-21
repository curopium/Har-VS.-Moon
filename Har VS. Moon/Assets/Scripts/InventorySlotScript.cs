using UnityEngine;
using System.Collections;

public class InventorySlotScript : MonoBehaviour {
	public MouseScript mouseScript;
	public Vector2 gridPos;
	public Item itemInSlot = null;
	public GameObject itemObject = null;
	public ItemDrop itemDrop = null;

	public InventorySlotScript(){
		
	}

	// Use this for initialization
	void Start () {
		GameObject mouseObject = GameObject.Find ("MouseObject");
		mouseScript = mouseObject.GetComponent<MouseScript> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setItem(Item itemToSet){
		itemInSlot = itemToSet;
		if (itemToSet.seedState == true) {
			if (itemToSet.species == "light") {
				
			} else if (itemToSet.species == "grass") {
				
			}
		} else {
			if (itemToSet.species == "light") {
				
			} else if (itemToSet.species == "grass") {
				
			}
		}
	}

	public void clearItem(){
		itemInSlot = null;
		itemObject = null;
		itemDrop = null;
	}

	void OnMouseDown(){
		if (itemInSlot != null) {
			mouseScript.SendMessage("mousePressedOnValidItem", itemInSlot);
		}
	}

	void OnMouseUp(){
		//If inventory can add item, store item in inventory, else return it to its source
		mouseScript.SendMessage("mouseReleasedOverInventory");
		GameObject inventoryObject = GameObject.Find ("InventoryObject");
		Inventory inventory = inventoryObject.GetComponent<Inventory> ();
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (Input.GetMouseButtonUp (0)) {
			mouseScript.itemDrag.originalPosition = transform.position;
			itemDrop = mouseScript.itemDrag;
		}
	}
}
