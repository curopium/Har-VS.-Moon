using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class UIScript : MonoBehaviour {
    public GameObject cheese;

    private GameObject parent;
    private WorldManager world;
    //public Texture2D GUITexture;
    public TextAsset imageAsset;
    Texture2D tex;
    //public Renderer rend;
	// Use this for initialization

    void Start()
    {

        parent = transform.parent.gameObject;
        world = parent.GetComponent<WorldManager>();

        tex = new Texture2D(2, 2);
        tex.LoadImage(imageAsset.bytes);

        //GUITexture = (Texture2D)cheese.GetComponent<SpriteRenderer>().material.GetTexture("_MainTex");
        //GUITexture = (Texture2D)cheese.GetComponent<SpriteRenderer>().material.mainTexture;
        
    }
	
	// Update is called once per frame
    void Update()
    {
        //transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0));
    }

    void OnGUI()
    {
        //GUI.Box(new Rect(0, 0, 100, 50), "Top-left");
        //GUI.Box(new Rect(Screen.width - 100, 0, 100, 50), );
        GUI.Box(new Rect(Screen.width - 100, 0, 100, 50), tex);
        GUI.Box(new Rect(Screen.width - 100, 0, 100, 50), world.cheese.ToString());
        //GUI.Box(new Rect(0, Screen.height - 50, 100, 50), "Bottom-left");
        //GUI.Box(new Rect(Screen.width - 100, Screen.height - 50, 100, 50), "Bottom right");
    }
}
