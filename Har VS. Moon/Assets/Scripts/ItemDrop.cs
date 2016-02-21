using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class ItemDrop : MonoBehaviour {

    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;
	public MouseScript mouseScript;
    public PlantObject plantObject;
    GameObject parent;
	int timerSinceDragRelease = -1;
	Vector3 originalPosition;

	// Use this for initialization
	void Start () {
        
		GameObject mouseObject = GameObject.Find ("MouseObject");
		mouseScript = mouseObject.GetComponent<MouseScript> ();
        parent = transform.parent.gameObject;
        plantObject = parent.GetComponent<PlantObject>();
		originalPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) == false)
        {
			timerSinceDragRelease--;
			if (timerSinceDragRelease == 0) {
				//Just stopped being dragged, return to former location on farm
				transform.position = originalPosition;

				timerSinceDragRelease--;
			}
       	}
	}

    void OnMouseDrag()
    {
        //Debug.Log("hello");
        //Debug.Log("Held");
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);

        mouseScript.setActiveItem(plantObject.harvestedProduct);

		timerSinceDragRelease = 4;
    }
}
