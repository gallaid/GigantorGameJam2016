using UnityEngine;
using System.Collections;

public class monsterSpawner : MonoBehaviour {
    public GameObject basicMonster;
    public int waveNumber = -1;
    public float timeBetweenWaves = 5;

    public int[] numMonsters;
    public int[] numDirections;
    public float[] minDelay;
    public float[] maxDelay;

    public int enemiesAlive = 0;
    private float timer;
    private int currentDirection = 0;

    // Use this for initialization
    void Start () {
	
	}
    
    // Update is called once per frame
    void Update() {
        enemiesAlive = GameObject.FindGameObjectsWithTag("enemy").Length;
        timer -= Time.deltaTime;
        
        //(short circit) if there are no more monsters...
        if (waveNumber < 0 || (enemiesAlive <= 0 && numMonsters[waveNumber] <= 0))
        {
            timer = timeBetweenWaves; //set the grace period
            waveNumber++; //go to the next wave
            currentDirection = Random.Range(0, 4);
        }

        //spawn a monster at intervals
        if(timer <= 0 && numMonsters[waveNumber] > 0)
        {
            spawnMonster(currentDirection, numDirections[waveNumber]);
            numMonsters[waveNumber]--;
            timer = Random.Range(minDelay[waveNumber], maxDelay[waveNumber]);
        }
    }

    void spawnMonster(int mainDirection, int directions)
    {
        MainMap map = GetComponent<MainMap>();
        int direction = Random.Range(mainDirection, mainDirection + directions) % 4; //0-N, 1-E, 2-S, 3-W
        Vector3 spawnPoint = new Vector3(0, 0, 0);

        if(direction == 0) //north
        {
            spawnPoint.x = Random.Range(0, map.tileSizeX * map.mapSizeX);
            spawnPoint.y = map.tileSizeY * map.mapSizeY;
        }
        if (direction == 1) //east
        {
            spawnPoint.x = map.tileSizeX * map.mapSizeX;
            spawnPoint.y = Random.Range(0, map.tileSizeY * map.mapSizeY);
        }
        if (direction == 2) //south
        {
            spawnPoint.x = Random.Range(0, map.tileSizeX * map.mapSizeX);
            spawnPoint.y = 0;
        }
        if (direction == 3)
        {
            spawnPoint.x = 0;
            spawnPoint.y = Random.Range(0, map.tileSizeY * map.mapSizeY);
        }

        Instantiate(basicMonster, spawnPoint, Quaternion.identity);
    }
}
