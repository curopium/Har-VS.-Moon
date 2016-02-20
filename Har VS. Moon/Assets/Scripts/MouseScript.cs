using UnityEngine;
using System.Collections;

public class MouseScript : MonoBehaviour {
	//Drag & Drop Functionality
	//Detect which tile the mouse is over in the farm, or which slot of the inventory
	//If mouse was just clicked, see if mouse is over a valid slot of the inventory
	//If so, change active item to one of what seed/harvested product was selected
	//When mouse button is released, check to see if mouse is over an unoccupied grid tile
	//If so, and if active item is seed, plant seed of the corresponding species inthe grid tile then remove active item
	//Otherwise, return item to inventory and then remove active item

	//Requires ability to detect position and occupancy of grid tiles
	//Requires ability to plant seed in grid tile
	//Requires ability to detect position of inventory slot, and access contents
	//Requires ability to add/remove items from inventory

	public Inventory inventory;
	public GridManager gridController;
	public Item activeItem = null;
	public GameObject tileObject;
	public float tileSize;
	public bool mouseDown = false;
	public int mouseReleaseTimer = 0;

	// Use this for initialization
	void Start () {
		gridController = GameObject.Find ("GridObject").GetComponent<GridManager> ();
		tileObject = GameObject.Find ("Ground");
		tileSize = tileObject.GetComponent<Renderer>().bounds.size.x;
		GameObject inventoryObject = GameObject.Find ("InventoryObject");
		inventory = inventoryObject.GetComponent<Inventory> ();
		activeItem = new Item ();
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, this.transform.position.z);
		if (mouseDown) {
			if (Input.GetMouseButton (0) == false) {
				//If mouse was just pressed
				//Give a frame or two for other scripts to fire off before checking if active item was used up or not
				mouseReleaseTimer = 3;
			}
		} else {
			if (mouseReleaseTimer > 0) {
				mouseReleaseTimer--;
			} else if (mouseReleaseTimer == 0) {
				mouseReleaseTimer--;
				//Timer has gone. If active item was not used up, return it to its location in the inventory
				if (activeItem != null) {
					inventory.AddItem (activeItem);
					activeItem = null;
				}
			}
		}
	}

	private Vector2 calcGridPos(Vector2 worldPos)
	{
		Vector2 gridPos = new Vector2();
		gridPos.x = Mathf.Floor(worldPos.x/tileSize);
		gridPos.y = Mathf.Floor(worldPos.y/tileSize);

		return gridPos;
	}

	//Receive message with grid position if tile is empty and released over
	//If item is seed, plant seed in relevant tile of appropriate species
	void mouseReleasedOverEmptyTile(Vector2 gridPos){
		if (activeItem.itemType == "seed") {
			gridController.plant (activeItem.species, gridPos);
			activeItem = null;
		}
	}

	//Receive message with inventory index if slot is valid object
	//Change active item to one of what seed/harvested product was selected and update inventory
	void mousePressedOnValidItem(Item itemToTake){
		int index = inventory.CheckItem (itemToTake);
		if (index != -1) {
			activeItem = inventory.items [index].removeItem ();
			inventory.RefreshList ();
		} else {
			Debug.Log ("Slot and Item list inconsistency");
		}
	}
}
