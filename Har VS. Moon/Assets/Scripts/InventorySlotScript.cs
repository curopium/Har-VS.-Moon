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
		if (itemToSet.seedState == true) {
			if (itemToSet.species == "light") {
				GameObject item = GameObject.Find ("LightBulb");
				itemObject = (GameObject)Instantiate (item, new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
				PlantObject plObject = itemObject.GetComponent<PlantObject> ();
				plObject.stage1.SetActive (false);
				plObject.stage2.SetActive (false);
				plObject.stage3.SetActive (false);
				plObject.stage4.SetActive (false);
				plObject.item.SetActive (false);
				plObject.seed.SetActive (true);
			} else if (itemToSet.species == "grass") {
				GameObject item = GameObject.Find ("Grass");
				itemObject = (GameObject)Instantiate (item, new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
				PlantObject plObject = itemObject.GetComponent<PlantObject> ();
				plObject.stage1.SetActive (false);
				plObject.stage2.SetActive (false);
				plObject.stage3.SetActive (false);
				plObject.stage4.SetActive (false);
				plObject.item.SetActive (false);
				plObject.seed.SetActive (true);
			}
		} else {
			if (itemToSet.species == "light") {
				GameObject item = GameObject.Find ("LightBulb");
				itemObject = (GameObject)Instantiate (item, new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
				PlantObject plObject = itemObject.GetComponent<PlantObject> ();
				plObject.stage1.SetActive (false);
				plObject.stage2.SetActive (false);
				plObject.stage3.SetActive (false);
				plObject.stage4.SetActive (false);
				plObject.item.SetActive (true);
				plObject.seed.SetActive (false);
			} else if (itemToSet.species == "grass") {
				GameObject item = GameObject.Find ("Grass");
				itemObject = (GameObject)Instantiate (item, new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
				PlantObject plObject = itemObject.GetComponent<PlantObject> ();
				plObject.stage1.SetActive (false);
				plObject.stage2.SetActive (false);
				plObject.stage3.SetActive (false);
				plObject.stage4.SetActive (false);
				plObject.item.SetActive (true);
				plObject.seed.SetActive (false);
			}
		}
	}

	void clearItem(){
		itemInSlot = null;
		itemObject = null;
	}

	void OnMouseDown(){
		if (itemInSlot != null) {
			mouseScript.SendMessage("mousePressedOnValidItem", itemInSlot);
		}
	}

	void OnMouseUp(){
		//If inventory can add item, store item in inventory, else return it to its source
		mouseScript.SendMessage("mouseReleasedOverInventory", gridPos);
	}
}
