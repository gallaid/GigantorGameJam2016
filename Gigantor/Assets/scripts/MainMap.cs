﻿using UnityEngine;
using System.Collections;

public class MainMap : MonoBehaviour {
    
    //path = 0
    //tree = 1

    public GameObject[] tiles;
    public int mapSizeX;
    public int mapSizeY;
    private int[,] map;

    private float tileSizeX;
    private float tileSizeY;

    // Use this for initialization
    void Start () {
        map = new int[mapSizeX, mapSizeY];
        int n1 = Random.Range(0, 10);
        int m1 = Random.Range(0, 10);
        int n2 = mapSizeX - Random.Range(0, 10);
        int m2 = mapSizeY - Random.Range(0, 10);


        Sprite s = tiles[0].GetComponent<SpriteRenderer>().sprite;
        tileSizeX = s.bounds.size.x;
        tileSizeY = s.bounds.size.y;

        //populate the map
        for (int x = 0; x < mapSizeX; x++)
        {
            //tree or path
            for (int y = 0; y < mapSizeY; y++)
            {
                if ((x == n1 || x == n2) && y >= m1 && y <= m2)
                {
                    map[x, y] = 0; //path

                }
                else if ((y == m1 || y == m2) && x >= n1 && x <= n2)
                {
                    map[x, y] = 0; //path

                }
                else
                {
                    map[x, y] = 1; //fill with trees
                }
            }
        }

        for (int x = 0; x < mapSizeX; x++)
        {
            //tree or path
            for (int y = 0; y < mapSizeY; y++)
            {
                int n = 0;
                if (x - 1 > 0 && x + 1 < mapSizeX && y - 1 > 0 && y + 1 < mapSizeY && map[x, y] != 0) //out of bounds checker
                {
                    if (map[x - 1, y] == 0)
                        n++;
                    if (map[x , y - 1] == 0)
                        n++;

                    if (map[x + 1, y] == 0)
                        n++;

                    if (map[x, y + 1] == 0)
                        n++;
                }

                if(Random.value * n >= 0.5)
                {
                    map[x, y] = 2;
                }

                //put the stuff in the level
                GameObject tile = tiles[map[x, y]];
                if(map[x,y] == 1)
                {
                    for(int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            Instantiate(tile, new Vector3((x + (float)i/3) * tileSizeX, (y + (float)j/3) * tileSizeY, 0), Quaternion.identity);
                        }
                    }
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
