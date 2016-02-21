using UnityEngine;
using System.Collections;

public class BuyScript : MonoBehaviour {

    public GameObject worldObject;
    public WorldManager worldManager;

    public int cost;
    public string type;

	// Use this for initialization
	void Start () {

        worldObject = GameObject.Find("World");
        if (worldObject == null)
        {
            Debug.LogError("World not found!");
        }
        worldManager = worldObject.GetComponent<WorldManager>();

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        if (worldManager.cheese > cost)
        {
            worldManager.cheese = worldManager.cheese - cost;
        }
    }
}
