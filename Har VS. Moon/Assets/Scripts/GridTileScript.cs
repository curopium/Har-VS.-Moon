using UnityEngine;
using System.Collections;

public class GridTileScript : MonoBehaviour {
	public Tile tile;
	public PolygonCollider2D collider;
	public MouseScript mouseScript;

	public GridTileScript(Tile thisTile){
		tile = thisTile;
	}

	public GridTileScript(){

	}

	// Use this for initialization
	void Start () {
		collider = GetComponent<PolygonCollider2D> ();
		GameObject mouseObject = GameObject.Find ("MouseObject");
		mouseScript = mouseObject.GetComponent<MouseScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/*private Vector2 calcGridPos(Vector2 worldPos)
	{
		Vector2 gridPos = new Vector2();
		gridPos.x = Mathf.Floor(worldPos.x/tileSize);
		gridPos.y = Mathf.Floor(worldPos.y/tileSize);

		return gridPos;
	}*/

	void OnMouseUp(){
		//Find grid position of tile
		//Locate tile object
		//Check if tile's plantobject variable is null or not
		if (tile.plantObject == null) {
			//If so, send message to MouseScript to commence planting

			Debug.Log ("Plant here!");
		}

	}
}
