using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileType
{
    private int id;
    private GameObject tileObject;
    private string name;
    private int traversable;



    public TileType(int _id, GameObject _tileObject, string _name, int _traversable)
    {
        id = _id;
        tileObject = _tileObject;
        name = _name;
        traversable = _traversable;
    }

    public TileType(string _name)
    {
        name = _name;
    }

    public string getName()
    {
        return name;
    }

    public GameObject getTileObject()
    {
        return tileObject;
    }
}

//TODO change this to its own editor in inspector
public class TileLibrary : MonoBehaviour
{

    //public GameObject dirt;
    //public int trav1 = 0;
    bool started = false;

    /*
    public GameObject wall = GameObject.Find("WallObject");
    public int trav2 = 0;

    public GameObject dirt = GameObject.Find("DirtObject");
    public int trav3 = 1;

    
    public GameObject rock = GameObject.Find("RockObject");
    public int trav4 = 1;
    */

    public List<TileType> tileTypeList = new List<TileType>();

    // Use this for initialization
    void Start()
    {

        //dirt
        GameObject dirt = GameObject.Find("DirtObject");
        if (dirt == null)
        {
            Debug.Log("somthing went wrong with dirt");
            return;
        }
        TileType dirtTile = new TileType(1, dirt, "Dirt", 1);
        tileTypeList.Add(dirtTile);
        //Debug.Log("added tile");

        //wall
        GameObject wall = GameObject.Find("WallObject");
        if (wall == null)
        {
            Debug.Log("somthing went wrong with dirt");
            return;
        }
        TileType wallTile = new TileType(2, wall, "Wall", 0);
        tileTypeList.Add(wallTile);


        started = true;
    }

    //TODO add error handling
    public TileType findTile(string title)
    {
        //TileType foundTile;

        if (started == false)
        {
            Start();
        }

        //Debug.Log("searching");
        foreach (TileType t in tileTypeList)
        {
            //Debug.Log("tile searched");
            if (t.getName() == title)
            {
                //Debug.Log("found tile by name!");
                //foundTile = t;
                //return foundTile;
                return t;
            }
        }

        return null;
    }

    // Update is called once per frame

    void Update()
    {

    }
}
