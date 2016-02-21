using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class ItemDrop : MonoBehaviour {

    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;
	public MouseScript mouseScript;

	// Use this for initialization
	void Start () {
		GameObject mouseObject = GameObject.Find ("MouseObject");
		mouseScript = mouseObject.GetComponent<MouseScript> ();
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetMouseButtonDown(0))
        //{
            
       // }
	}

    void OnMouseDrag()
    {
        //Debug.Log("hello");
        //Debug.Log("Held");
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);

    }
}
