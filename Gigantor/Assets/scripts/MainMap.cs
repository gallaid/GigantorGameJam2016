using UnityEngine;
using System.Collections;

public class MainMap : MonoBehaviour {
    
    //path = 0
    //tree = 1

    public GameObject[] tiles;
    public int mapSizeX;
    public int mapSizeY;
    private int[,] map;

    public float tileSizeX;
    public float tileSizeY;

    public int townInset;
    public Vector3[] buildings;

    // Use this for initialization
    void Start () {
        map = new int[mapSizeX, mapSizeY];

        Sprite s = tiles[0].GetComponent<SpriteRenderer>().sprite;
        tileSizeX = s.bounds.size.x;
        tileSizeY = s.bounds.size.y;

        //populate the map with trees and a road
        for (int x = 0; x < mapSizeX; x++)
        {
            //tree or path?
            for (int y = 0; y < mapSizeY; y++)
            {
                if ((x == townInset || x == mapSizeX - townInset) && y >= townInset && y <= mapSizeY - townInset)
                {
                    map[x, y] = 0; //path

                }
                else if ((y == townInset || y == mapSizeY - townInset) && x >= townInset && x <= mapSizeX - townInset)
                {
                    map[x, y] = 0; //path

                }
                else
                {
                    map[x, y] = 1; //fill with trees
                }
            }
        }

        //add the buildings
        foreach (Vector3 b in buildings)
        {
            map[(int)b.x, (int)b.y] = (int)b.z + 2;
        }

        //load in the level
        for (int x = 0; x < mapSizeX; x++)
        {
            for (int y = 0; y < mapSizeY; y++)
            {
                //for different building models
                int buildingType = 0;
                if (map[x, y] > 2)
                {
                    buildingType = map[x, y] - 2;
                    map[x, y] = 2;
                }

                GameObject tile = tiles[map[x, y]];

                //if it is a tree, they are placed in a 3x3 grid within the tile
                if(map[x,y] == 1)
                {
                    for(int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            if(Random.value > 0.7)
                                Instantiate(tile, new Vector3((x + (float)i/3) * tileSizeX, (y + (float)j/3) * tileSizeY, 0), Quaternion.identity);
                        }
                    }
                }
                else if(map[x, y] == 2)
                {
                    GameObject temp = Instantiate(tile, new Vector3(x * tileSizeX, y * tileSizeY, 0), Quaternion.identity) as GameObject;
                    temp.GetComponent<buildingManager>().type = buildingType;
                }
                else
                {
                    Instantiate(tile, new Vector3(x * tileSizeX, y * tileSizeY, 0), Quaternion.identity);
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {

    }
}
