using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile
{
    public int id;
    public int type;
    public Vector2 gridPosition;
    public GameObject tileObject;
    public GameObject plantObject;

    public Tile(int _id, Vector2 _gridPosition, GameObject _tileObject)
    {
        id = _id;
        gridPosition = _gridPosition;
        tileObject = _tileObject;
    }

    public Tile(int _id, Vector2 _gridPosition)
    {
        id = _id;
        gridPosition = _gridPosition;
    }

    public Tile(Vector2 _gridPosition)
    {
        gridPosition = _gridPosition;
    }

    public bool isInvalid()
    {
        return (this == null);
    }
}

public class GridManager : MonoBehaviour
{

    private int tileIndex = 0;
    public int gridWidth = 5;
    public int gridHeight = 5;

    public GameObject tileObject;
    TileLibrary tileLibrary;
    public List<Tile> tileList = new List<Tile>();

    // Use this for initialization
    // Grabs Game object from TileLibrary
    void Start()
    {
        tileObject = GameObject.Find("Ground");

        if (tileObject == null)
        {
            Debug.Log("Ground not found");
            return;
        }

        /*
        TileLibrary tileLibrary = GameObject.Find("TileLibraryObject").GetComponent<TileLibrary>();
        if (tileLibrary != null)
        {
            //Todo Fix
            //tileObject = new GameObject();
            
            if (tileLibrary.findTile("Dirt") == null)
            {
                Debug.Log("Dirt not found");
                return;
            }

            if (tileLibrary.findTile("Dirt").getTileObject() == null)
            {
                Debug.Log("Dirt Object went wrong");
                return;
            }
            

            tileObject = tileLibrary.findTile("Dirt").getTileObject();
            //tileObject = tileLibrary.findTile("Dirt").getTileObject();
        }
        else
        {
            Debug.Log("Tile Library not found");
            return;
        }
         */
    }

    // Update is called once per frame
    void Update()
    {

    }

    public List<Tile> getTileList()
    {
        return tileList;
    }

    public Tile findTile(Vector2 _gridPost)
    {
        foreach (Tile t in tileList)
        {
            if (t.gridPosition == _gridPost)
            {
                return t;
            }
        }

        return null;
    }

    public GameObject getTileObject()
    {
        return tileObject;
    }

    public void setSize(int w, int h)
    {
        gridWidth = w;
        gridHeight = h;
    }

    public void setObject(GameObject gameObject)
    {
        tileObject = gameObject;
    }

    public void createGrid()
    {
        Debug.Log("build");
        for (float x = 0; x < gridHeight; x++)
        {
            for (float y = 0; y < gridWidth; y++)
            {

                //Current position in grid
                Vector2 gridPos = new Vector2(x, y);

                //TODO remove
                /*
                TileLibrary tileLibrary = GameObject.Find("TileLibraryObject").GetComponent<TileLibrary>();
                if (Random.Range(1, 3) == 1)
                {

                    tileObject = tileLibrary.findTile("Dirt").getTileObject();
                    //tileObject = tileLibrary.findTile("Dirt").getTileObject();
                }
                else
                {
                    Debug.Log("wall!");
                    tileObject = tileLibrary.findTile("Wall").getTileObject();
                }
                 */
                //tileObject = tileLibrary.findTile("Ground").getTileObject();
                //GameObject tileObject2;
                //tileObject2 = GameObject.Find("Ground");

                Tile newTile = new Tile(tileIndex, gridPos, tileObject);
                //GameObject clone = Instantiate(newTile) as GameObject;

               

                newTile.tileObject.SetActive(false);

                newTile.tileObject = (GameObject)Instantiate(tileObject, Vector2.zero, Quaternion.identity);

                if (newTile == null)
                {
                    Debug.Log("Tile is null");
                    return;
                }

                if (tileList == null)
                {
                    Debug.Log("List is null");
                    return;
                }

                tileList.Add(newTile);

                tileIndex++;

                //yield return 0; 
            }
        }
        //return tileList;
    }

    public void drawGrid()
    {
        GridDrawer gridLayer = GameObject.Find("GridObject").GetComponent<GridDrawer>();

        if (gridLayer == null)
        {
            Debug.Log("gridLayer is null");
            return;
        }

        gridLayer.drawGrid();
    }

    public void plant(string type, Vector2 _gridPos)
    {
        if (type == "light")
        {
            //Tile newTile = new Tile(tileIndex, gridPos, tileObject);
            //newTile.tileObject.SetActive(false);
            GameObject plant = GameObject.Find("LightBulb");

            if (plant == null)
            {
                Debug.Log("solarplant is null");
                return;
            }

            Tile tile = findTile(_gridPos);

            tile.plantObject = (GameObject)Instantiate(plant, new Vector2(tile.tileObject.transform.position.x, tile.tileObject.transform.position.y), Quaternion.identity);
            //tile.plantObject.transform.position = tile.tileObject.transform.position;
        }

        else if (type == "grass")
        {
            //Tile newTile = new Tile(tileIndex, gridPos, tileObject);
            //newTile.tileObject.SetActive(false);
            GameObject plant = GameObject.Find("Grass");

            if (plant == null)
            {
                Debug.Log("grassplant is null");
                return;
            }

            Tile tile = findTile(_gridPos);

            tile.plantObject = (GameObject)Instantiate(plant, new Vector2(tile.tileObject.transform.position.x, tile.tileObject.transform.position.y), Quaternion.identity);
            //tile.plantObject.transform.position = tile.tileObject.transform.position;
        }
    }
}

