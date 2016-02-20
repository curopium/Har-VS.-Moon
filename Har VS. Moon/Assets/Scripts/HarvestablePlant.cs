using UnityEngine;
using System.Collections;

public class HarvestablePlant : MonoBehaviour {

    GameObject parent;
    PlantObject plant;
	// Use this for initialization
	void Start () {

        parent = transform.parent.gameObject;
        plant = parent.GetComponent<PlantObject>();
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        Debug.Log("hello");
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("hello");
            if (plant.age > plant.harvestTime)
            {
                plant.stage4.SetActive(false);
                plant.item.SetActive(true);
            }
        }

    }

}
