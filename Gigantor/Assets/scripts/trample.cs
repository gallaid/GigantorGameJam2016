using UnityEngine;
using System.Collections;

public class trample : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    //when it passes through a tree
    void OnTriggerEnter2D(Collider2D c)
    {
        GameObject other = c.gameObject;

        if (other.tag == "building")
        {
            //Destroy(other);
            other.GetComponent<buildingManager>().health = 0;
        }

        if (other.tag == "enemy")
        {
            //Destroy(other);
            other.GetComponent<MonsterAI>().health = 0;
        }
    }
}
