using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	public List<Item> items = new List<Item> (10);
	public List<InventorySlotScript> slots = new List<InventorySlotScript> (10);
	public int capacity = 10;

	public int gridWidth = 5;
	public int gridHeight = 2;
	public float tileSize;
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

		createGrid ();
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
		return (((int)y * gridWidth) + (int)x);
	}

	public void createGrid()
	{
		setSize (10, 1);
		for (float x = 0; x < gridWidth; x++)
		{
			for (float y = 0; y < gridHeight; y++)
			{

				//Current position in grid
				Vector2 gridPos = new Vector2(x, y);

				GameObject newSlotObject = (GameObject)Instantiate(slotObject, Vector2.zero, Quaternion.identity);
				InventorySlotScript slotScript = newSlotObject.AddComponent<InventorySlotScript> () as InventorySlotScript;
				slotScript.gridPos = gridPos;
				//Debug.Log (gridPos.ToString ());

				if (newSlotObject == null || slotScript == null) {
					Debug.Log ("Slot is null");
					return;
				}

				slots.Add (newSlotObject.GetComponent<InventorySlotScript> ());
			}
		}
		capacity = gridWidth * gridHeight;
		slots.Capacity = capacity;
		items.Capacity = capacity;

		//Draw the grid
		GameObject slotGrid = new GameObject("HexInventorySlotGrid");
		tileSize = slotObject.GetComponent<Renderer>().bounds.size.x;

		foreach (InventorySlotScript slot in slots)
		{
			slot.gameObject.SetActive(true);
			slot.gameObject.transform.position = calcWorldCoordinate(slot.gridPos);
			slot.gameObject.transform.parent = slotGrid.transform;
		}
	}

	private Vector3 calcWorldCoordinate(Vector2 gridPos)
	{
		float x = gridPos.x * tileSize;
		float y = (gridPos.y + 1) * (-tileSize);

		return new Vector3(x, y, 11);
	}
}
