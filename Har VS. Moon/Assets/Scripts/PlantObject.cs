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
    //private bool gethungry = false;

    public float starving;
    public int age;
    public int currentStage;
    public bool growing;
    public GameObject currentPlantObject;
    //public List<GameObject> plantObjects = new List<GameObject>();
	public string species;
	public Item harvestedProduct;
    public List<string> canEat = new List<string>();

    public GameObject stage1;
    public GameObject stage2;
    public GameObject stage3;
    public GameObject stage4;
    public GameObject item;
    public GameObject hungryIcon;
    public GameObject seed;

    public int growTime1;
    public int growTime2;
    public int growTime3;
    public int harvestTime;

    public WorldManager worldManager;

    public float timer;

    bool change = true;
    
	// Use this for initialization
	void Start () {
        //gethungry = isHungry;
        currentStage = 1;
		harvestedProduct = new Item(species);
        growing = true;
        age = 0;
        timer = 0;
        stage1.SetActive(true);
        stage2.SetActive(false);
        stage3.SetActive(false);
        stage4.SetActive(false);
        item.SetActive(false);
        hungryIcon.SetActive(false);
        seed.SetActive(false);

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


    public void feed(FoodScript food)
    {
        if (canEat.Contains(food.species))
        {
            hunger = hunger + food.value;
        }
    }


    void grow()
    {


        //if (gethungry)
        //{

            if (currentStage == 3)
            {
                hunger = hunger - hungerRate;
                if (hunger < starving)
                {
                    age = age - 1;
                    hp = hp - 1;
                    hungryIcon.SetActive(true);
                    isHungry = true;

                    if (hunger == 0)
                    {
                        Destroy(gameObject);
                    }
                }
                else
                {
                    if (hp < 100)
                    {
                        hp = hp + 1;
                    }
                    hungryIcon.SetActive(false);
                    isHungry = false;
                }
            }
        //}
        timer = 0;
        

        age = age + 1;  
        if (age == growTime1)
        {
            currentPlantObject = stage2;
            currentStage = 2;

            stage1.SetActive(false);
            stage2.SetActive(true);

        }
        if (age == growTime2)
        {
            currentPlantObject = stage3;
            currentStage = 3;

            stage2.SetActive(false);
            stage3.SetActive(true);
        }
        if (age == growTime3)
        {
            currentStage = 4;
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
