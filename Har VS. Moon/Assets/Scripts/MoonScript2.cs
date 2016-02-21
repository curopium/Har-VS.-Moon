using UnityEngine;
using System.Collections;

public class MoonScript2 : MonoBehaviour {

    public ItemDrop currentItem;

    public WorldManager world;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        //plantObject.feed( 
        //Debug.Log("ahhh!");
        currentItem = col.gameObject.GetComponent<ItemDrop>();

        Debug.Log("moooon!");

        if (currentItem)
        {
            if (currentItem.plantObject.species == "mouse")
            {
                Debug.Log("win!");
                Destroy(gameObject);
                world.cheese = world.cheese + 1000000;
            }
        }
    }
}
