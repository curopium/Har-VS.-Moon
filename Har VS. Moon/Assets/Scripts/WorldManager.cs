using UnityEngine;
using System.Collections;

public class WorldManager : MonoBehaviour {

    public float time;
    public float speed; 

	// Use this for initialization
	void Start () {
        //time += Time.deltaTime;
        //speed = 1;

        
	}

    void FixedUpdate(){
        time += (Time.deltaTime * speed);
    }
	
	// Update is called once per frame
	void Update () {

	}

    public float getTime()
    {
        return Mathf.Round(time);
    }

    public float getDeltaTime()
    {
        return (Time.deltaTime * speed);
    }

}
