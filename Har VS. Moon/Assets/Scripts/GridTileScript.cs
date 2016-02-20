using UnityEngine;
using System.Collections;

public class GridTileScript : MonoBehaviour {
	public Tile tile;
	public MouseScript mouseScript;

	public GridTileScript(Tile thisTile){
		tile = thisTile;
	}

	public GridTileScript(){

	}

	// Use this for initialization
	void Start () {
		GameObject mouseObject = GameObject.Find ("MouseObject");
		mouseScript = mouseObject.GetComponent<MouseScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseUp(){
		//Find grid position of tile
		//Locate tile object
		//Check if tile's plantobject variable is null or not
		if (tile.plantObject == null) {
			//If so, send message to MouseScript to commence planting
			mouseScript.SendMessage("mouseReleasedOverEmptyTile", tile.gridPosition);
		}

	}
}
