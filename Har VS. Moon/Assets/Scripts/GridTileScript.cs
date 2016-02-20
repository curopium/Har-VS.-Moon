using UnityEngine;
using System.Collections;

public class GridTileScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
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
		//If so, send message to MouseScript to commence planting
		Debug.Log ("Plant here!");
	}
}
