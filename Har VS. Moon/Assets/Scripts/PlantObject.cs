using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlantObject : MonoBehaviour {

    public int id;
    public int stages;
    public int hp;
    public float hunger;
    public float hungerRate;
    public bool isHungry;
    public float starving;
    public int age;
    public int currentStage;
    public bool growing;
    public GameObject currentPlantObject;
    //public List<GameObject> plantObjects = new List<GameObject>();

    public GameObject stage1;
    public GameObject stage2;
    public GameObject stage3;
    public GameObject stage4;
    public GameObject item;
    public GameObject hungryIcon;

    public int growTime1;
    public int growTime2;
    public int growTime3;
    public int harvestTime;

    public WorldManager worldManager;

    public float timer;

    bool change = true;
    
	// Use this for initialization
	void Start () {
        growing = true;
        age = 0;
        timer = 0;
        stage1.SetActive(true);
        stage2.SetActive(false);
        stage3.SetActive(false);
        stage4.SetActive(false);
        item.SetActive(false);
        hungryIcon.SetActive(false);

        worldManager = GameObject.Find("World").GetComponent<WorldManager>();
	}
	
	// Update is called once per frame
    //super hacky
	void Update () {
        if (growing)
        {
            timer += worldManager.getDeltaTime();
            if ((timer > 10.0f))
            {

                grow();

            }

        }

	}



    void grow()
    {
        
        hunger = hunger - hungerRate;
        if (hunger < starving)
        {
            hungryIcon.SetActive(true);
            isHungry = true;
        }
        else
        {
            hungryIcon.SetActive(false);
            isHungry = false;
        }
        timer = 0;
        

        age = age + 1;  
        if (age == growTime1)
        {
            currentPlantObject = stage2;

            stage1.SetActive(false);
            stage2.SetActive(true);

        }
        if (age == growTime2)
        {
            currentPlantObject = stage3;

            stage2.SetActive(false);
            stage3.SetActive(true);
        }
        if (age == growTime3)
        {
            currentPlantObject = stage4;
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
