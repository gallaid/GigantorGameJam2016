using UnityEngine;
using System.Collections;

public class MainMap : MonoBehaviour {
    
    //path = 0
    //tree = 1

    public GameObject[] tiles;
    public int mapSizeX;
    public int mapSizeY;
    private int[,] map;
    

    

    // Use this for initialization
    void Start () {
        map = new int[mapSizeX, mapSizeY];
        int n1 = Random.Range(0, 10);
        int m1 = Random.Range(0, 10);
        int n2 = mapSizeX - Random.Range(0, 10);
        int m2 = mapSizeY - Random.Range(0, 10);

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

                GameObject tile = tiles[map[x, y]];
                Sprite tileSprite = tile.GetComponent<SpriteRenderer>().sprite;

                //put the stuff in the level
                Instantiate(tile, new Vector3(x * tileSprite.bounds.size.x, y * tileSprite.bounds.size.y, 0), Quaternion.identity);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {

    }
}
