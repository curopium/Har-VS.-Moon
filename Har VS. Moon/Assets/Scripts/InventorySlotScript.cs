using UnityEngine;
using System.Collections;

public class InventorySlotScript : MonoBehaviour {
	public MouseScript mouseScript;
	public Vector2 gridPos;
	public Item itemInSlot = null;
	public GameObject itemObject = null;

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

	void setItem(Item itemToSet){
		if (itemToSet.itemType == "seed") {
			if (itemToSet.species == "light") {
				GameObject item = GameObject.Find("LightBulb");
				itemObject = (GameObject)Instantiate(item, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
			} else if (itemToSet.species == "grass") {

			}
		} else if (itemToSet.itemType == "harvested") {
			if (itemToSet.species == "light") {

			} else if (itemToSet.species == "grass") {

			}
		}
	}

	void OnMouseDown(){
		if (itemInSlot != null) {
			mouseScript.SendMessage("mousePressedOnValidItem", itemInSlot);
		}
	}
}
