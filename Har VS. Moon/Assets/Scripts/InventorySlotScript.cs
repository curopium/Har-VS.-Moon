using UnityEngine;
using System.Collections;

public class InventorySlotScript : MonoBehaviour {
	public GameObject slotObject;
	public MouseScript mouseScript;
	public Item itemInSlot = null;

	public InventorySlotScript(GameObject _slotObject){
		slotObject = _slotObject;
	}

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

	void OnMouseDown(){
		if (itemInSlot != null) {
			mouseScript.SendMessage("mousePressedOnValidItem", itemInSlot);
		}
	}
}
