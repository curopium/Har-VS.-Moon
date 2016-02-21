using UnityEngine;
using System.Collections;

public class SellBoxScript : MonoBehaviour {


    public GameObject worldObject;
    public WorldManager worldManager;
    public FoodScript currentFood;

    // Use this for initialization
    void Start()
    {
       // GridDrawer gridLayer = GameObject.Find("GridObject").GetComponent<GridDrawer>();
        worldObject = GameObject.Find("World");
        if (worldObject == null)
        {
            Debug.LogError("World not found!");
        }
        worldManager = worldObject.GetComponent<WorldManager>();

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D col)
    {
        //plantObject.feed( 
        //Debug.Log("ahhh!");
        currentFood = col.gameObject.GetComponent<FoodScript>();

        if (currentFood)
        {
            Debug.Log("cha-ching!");
            worldManager.cheese = worldManager.cheese + currentFood.moneyValue;
            Destroy(col.gameObject);
        }
    }
}

