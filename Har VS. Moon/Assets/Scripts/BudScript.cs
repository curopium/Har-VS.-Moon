using UnityEngine;
using System.Collections;

public class BudScript : MonoBehaviour {

    public GameObject parent;
    public PlantObject plantObject;
    public FoodScript currentFood;

	// Use this for initialization
	void Start () {
        parent = transform.parent.gameObject;
        plantObject = parent.GetComponent<PlantObject>();

        //Debug.Log("Trigger: " );
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnCollisionEnter2D(Collision2D col)
    {
        //plantObject.feed( 
        Debug.Log("ahhh!");
        currentFood = col.gameObject.GetComponent<FoodScript>();
        if (currentFood)
        {
            Debug.Log("nom!");
            plantObject.feed(currentFood);
            Destroy(col.gameObject);
        }
    }

}
