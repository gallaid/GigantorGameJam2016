using UnityEngine;
using System.Collections;

public class MonsterAI : MonoBehaviour {
    public GameObject targetBuilding;
    public float health = 1f;
    public float speed = 0.01f;
    Rigidbody2D myRigidbody;

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        targetBuilding = FindClosestBuilding();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 moveVetor = (targetBuilding.transform.position - transform.position).normalized * speed;
        myRigidbody.velocity = (Vector2)moveVetor;
	}

    GameObject FindClosestBuilding()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("building");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach (GameObject b in gos)
        {
            Vector3 diff = b.transform.position - position;
            float curDistance = diff.sqrMagnitude;

            //get the closest non destroyed building
            if (curDistance < distance && b.GetComponent<buildingManager>().health > 0)
            {
                closest = b;
                distance = curDistance;
            }
        }

        return closest;
    }
}
