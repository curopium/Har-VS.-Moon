﻿using UnityEngine;
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

	// Use this for initialization
	void Start () {
		gridController = GameObject.Find ("GridObject").GetComponent<GridManager> ();
		tileObject = gridController.getTileObject();
		tileSize = tileObject.GetComponent<Renderer>().bounds.size.x;

	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, this.transform.position.z);
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
		}
	}

	//Receive message with inventory index if slot is valid object
	//Change active item to one of what seed/harvested product was selected and update inventory
	void mousePressedOnValidItem(int itemindex){
		activeItem = inventory.items [itemindex].removeItem ();
	}
}
