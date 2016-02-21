using UnityEngine;
using System.Collections;

public class WorldManager : MonoBehaviour {

    public float time;
    public float speed;
    public int cheese;

    public GameObject endScene;

	// Use this for initialization
	void Start () {
        //time += Time.deltaTime;
        //speed = 1;
        //cheese = 100;
        endScene.SetActive(false);
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

    public void endGame()
    {
        endScene.SetActive(true);
    }

}
