using UnityEngine;
using System.Collections;

public class GridDrawer : MonoBehaviour
{


    private float tileDemension;
    private GameObject tileObject;
    // Use this for initialization
    //private GridController parent = 

    private void setDemension()
    {
        tileDemension = tileObject.GetComponent<Renderer>().bounds.size.x;

    }

    private Vector3 calcWorldCoordinate(Vector2 gridPos)
    {
        float x = gridPos.x * tileDemension;
        float y = gridPos.y * tileDemension;

        return new Vector3(x, y, 10);
    }

    public void drawGrid()
    {

        GameObject tileGrid = new GameObject("HexGrid");
        GridManager gridController = GameObject.Find("GridObject").GetComponent<GridManager>();
        tileObject = gridController.getTileObject();
        setDemension();

        foreach (Tile t in gridController.getTileList())
        {
            t.tileObject.SetActive(true);
            t.tileObject.transform.position = calcWorldCoordinate(t.gridPosition);
            t.tileObject.transform.parent = tileGrid.transform;
        }
    }
}
