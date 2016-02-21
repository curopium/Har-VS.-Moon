using UnityEngine;
using System.Collections;

public class SeedScript : MonoBehaviour {

    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;
    public int cost;
    public string type;
    public Vector2 origin;

    public GameObject worldObject;
    public WorldManager worldManager;

    public GameObject gridObject;
    public GridManager gridManager;

    GridTileScript currentcol;

	// Use this for initialization
	void Start () {
        origin = transform.position;

        worldObject = GameObject.Find("World");
        if (worldObject == null)
        {
            Debug.LogError("World not found!");
        }
        worldManager = worldObject.GetComponent<WorldManager>();

        gridObject = GameObject.Find("GridObject");
        if (gridObject == null)
        {
            Debug.LogError("grid not found!");
        }
        gridManager = gridObject.GetComponent<GridManager>();
	
	}
	
	// Update is called once per frame
	void Update () {

        //mousePosition = Input.mousePosition;
       // mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        
	}

    void OnMouseUp()
    {
        //if (Input.GetMouseButtonDown(0) == false)
        //{
            //if over tile
            if (currentcol)
            {
                //Debug.Log("ahh found it");
                if (worldManager.cheese > cost)
                {
                    transform.position = origin;
                    worldManager.cheese = worldManager.cheese - cost;
                     //currentcol.tile.gridPosition
                    gridManager.plant(type,currentcol.tile.gridPosition);

                }
            }

        //}
    }

    void OnMouseDrag()
    {
        //Debug.Log("hello");
        //Debug.Log("Held");
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("foo!");
        
        //currentcol = collision.gameObject.GetComponent<GridTileScript>();
        if (collision.gameObject.GetComponent<GridTileScript>())
        {
            currentcol = collision.gameObject.GetComponent<GridTileScript>();
        }
        else
        {
            currentcol = null;
        }
    }

}
