using UnityEngine;
using System.Collections;

public class CameraObject : MonoBehaviour {

    public float minimumY   = 1.0F;
    public float maximumY   = 4.0F;
    public float zoomZ   = 4.0F;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        // Mouse wheel moving forwards
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            //transform.position.x = 500;
            //transform.position = new Vector3(transform.position.x, Mathf.Lerp(maximumY, minimumY, Time.time), Mathf.Lerp(transform.position.z, transform.position.z + zoomZ, Time.time));
            //transform.position.y = Mathf.Lerp(maximumY, minimumY, Time.time);
            //transform.position.z = Mathf.Lerp(transform.position.z, transform.position.z + zoomZ, Time.time);
            //print("Wheel Forward" + transform.position);
        }

        // Mouse wheel moving backwards
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            //transform.position.x = 500;
            //transform.position = new Vector3(transform.position.x, Mathf.Lerp(minimumY, maximumY, Time.time), Mathf.Lerp(transform.position.z, transform.position.z - zoomZ, Time.time));
            //transform.position.y = Mathf.Lerp(minimumY, maximumY, Time.time);
            //transform.position.z = Mathf.Lerp(transform.position.z, transform.position.z - zoomZ, Time.time);
            //print("Wheel Backward" + transform.position);
        }
	
	}
}
