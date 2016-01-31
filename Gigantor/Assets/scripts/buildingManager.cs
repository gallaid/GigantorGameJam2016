using UnityEngine;
using System.Collections;

public class buildingManager : MonoBehaviour {

    public static int numBuildings = 0;
    public float health = 1f;
    public int type = 0;

	// Use this for initialization
	void Start () {
        //track the total humber of buildings
        numBuildings++;
        GetComponent<Animator>().Play("buildingStart" + type);
        type = 0; //we only have one building right now so fix this
    }
	
	// Update is called once per frame
	void Update () {

        //when destroyed
	    if(health <= 0)
        {
            GetComponent<Animator>().Play("buildingDead" + type);
            Destroy(GetComponent<Collider2D>());
            numBuildings--;

        }
        else if(health < 0.25)
        {
            GetComponent<Animator>().Play("buildingLow" + type);
        }
        else if (health < 0.5)
        {
            GetComponent<Animator>().Play("buildingHigh" + type);
        }
    }
}
