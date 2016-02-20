using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlantObject : MonoBehaviour {

    public int id;
    public int stages;
    public int hp;
    public int hunger;
    public int age;
    public int currentStage;
    public GameObject currentPlantObject;
    //public List<GameObject> plantObjects = new List<GameObject>();

    public GameObject stage1;
    public GameObject stage2;
    public GameObject stage3;
    public GameObject stage4;
    //public GameObject stage5;

    public int growTime1;
    public int growTime2;
    public int growTime3;

    public WorldManager worldManager;

    public float timer;

    bool change = true;
    
	// Use this for initialization
	void Start () {
        age = 0;
        timer = 0;
        stage1.SetActive(true);
        stage2.SetActive(false);
        stage3.SetActive(false);
        stage4.SetActive(false);

        worldManager = GameObject.Find("World").GetComponent<WorldManager>();
	}
	
	// Update is called once per frame
    //super hacky
	void Update () {
        timer += worldManager.getDeltaTime(); 
        if ((timer > 10.0f)) 
        {
            grow();
            timer = 0;
            
        }
	}

    void grow()
    {
        age = age + 1;
        hunger = hunger - 1;

        if (age == growTime1)
        {
            currentPlantObject = stage2;

            stage1.SetActive(false);
            stage2.SetActive(true);
            stage3.SetActive(false);
            stage4.SetActive(false);
        }
        if (age == growTime2)
        {
            currentPlantObject = stage3;
            stage1.SetActive(false);
            stage2.SetActive(false);
            stage3.SetActive(true);
            stage4.SetActive(false);
        }
        if (age == growTime3)
        {
            currentPlantObject = stage4;
            stage1.SetActive(false);
            stage2.SetActive(false);
            stage3.SetActive(false);
            stage4.SetActive(true);
        }

    }

    /*
    void insertPlantObject(int index, GameObject gameObject)
    {
        plantObjects.Insert(index, gameObject);
    }

    void addPlantObject(int index, GameObject gameObject)
    {
        plantObjects.Add(gameObject);
    }
    */

}
