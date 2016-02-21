using UnityEngine;
using System.Collections;

public class MoonScript : MonoBehaviour {
    public WorldManager world;
    public float currentTime;
    public float endTime;
    public GameObject startPosition;
    public GameObject endPosition;
    public bool gameEnded = false;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        currentTime = world.getTime();
        if(gameEnded == false)
        {
            if(currentTime >= endTime)
            {
                gameEnded = true;
            }
            else
            {
                transform.position = Vector3.Lerp(startPosition.transform.position, endPosition.transform.position, currentTime / endTime);
            }
        }
	}
}
