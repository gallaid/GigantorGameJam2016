using UnityEngine;
using System.Collections;

public class buildingManager : MonoBehaviour {

    public static int numBuildings = 0;
    public float health = 1f;
    public enum buildingType { basic, basic2, orphanage};

	// Use this for initialization
	void Start () {
        //track the total humber of buildings
        numBuildings++;
	}
	
	// Update is called once per frame
	void Update () {

        //when destroyed
	    if(health <= 0)
        {
            GetComponent<Animator>().Play("BuildingDestroy");
            Destroy(GetComponent<Collider2D>());
        }
	}
}
