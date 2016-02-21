using UnityEngine;
using System.Collections;

public class StartScript : MonoBehaviour {

    public GameObject gridObject;
    public GridManager gridManager;

	// Use this for initialization
	void Start () {

        gridObject = GameObject.Find("GridObject");
        if (gridObject == null)
        {
            Debug.LogError("grid not found!");
        }
        gridManager = gridObject.GetComponent<GridManager>();
	}
	
	// Update is called once per frame
	void Update () {

	
	}

    void OnMouseUp()
    {
        Debug.Log("start!");
        //if (Input.GetMouseButtonDown(1) == true)
       // {
            gridManager.createGrid();
            gridManager.drawGrid();
            Destroy(gameObject);
       // }
    }
}
