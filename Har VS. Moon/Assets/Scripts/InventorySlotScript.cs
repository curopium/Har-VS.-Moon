using UnityEngine;
using System.Collections;

public class InventorySlotScript : MonoBehaviour {
	public MouseScript mouseScript;
	public Item itemInSlot = null;
	private int tileIndex = 0;
	public int gridWidth = 5;
	public int gridHeight = 5;


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
			//mouseScript.SendMessage("mousePressedOnValidItem", IList);
		}
	}
}
