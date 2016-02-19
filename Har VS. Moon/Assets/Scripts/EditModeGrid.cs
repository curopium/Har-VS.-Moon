using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(GridManager))]
public class GridEditor : Editor
{

    //public Object Tile;
    //public GameObject tile;
    public GameObject tile;
    public int width = 10;
    public int height = 10;

    public override void OnInspectorGUI()
    {
        GridManager myTarget = GameObject.Find("GridObject").GetComponent<GridManager>();

        //base.OnInspectorGUI();
        //EditorGUILayout.PrefixLabel("Build Grid");

        EditorGUILayout.BeginHorizontal();
        width = EditorGUILayout.IntField("width:", width);
        height = EditorGUILayout.IntField("height:", height);
        EditorGUILayout.EndHorizontal();

        //EditorGUILayout.ObjectField("tile:", tile, typeof(GameObject),true);
        //tile = EditorGUILayout.ObjectField("tile:", tile, typeof(GameObject), true) as GameObject;

        if (GUILayout.Button("Build Grid"))
        {

            myTarget.setSize(width, height);

            //myTarget.setObject(tile);
            myTarget.createGrid();

            myTarget.drawGrid();
        }

    }

}
