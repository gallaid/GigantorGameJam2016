using UnityEngine;
using System.Collections;

public class MonsterAI : MonoBehaviour {
    public GameObject targetBuilding;
    Rigidbody2D myRigidbody;

    public float health = 1f;
    public float speed = 0.01f;

    public float damage = 0.2f;
    public float attackCooldown = 1;
    private float attackTimer = 0;

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        InvokeRepeating("FindClosestBuilding", 0, 3);
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 moveVetor = (targetBuilding.transform.position - transform.position).normalized * speed;
        myRigidbody.velocity = (Vector2)moveVetor;

        if(health <= 0)
        {
            Destroy(gameObject); //die
        }
	}

    //for attacking buildings
    void OnCollisionStay2D(Collision2D coll)
    {
        attackTimer -= Time.deltaTime;

        if(coll.gameObject.tag == "building" && attackTimer < 0)
        {
            coll.gameObject.GetComponent<buildingManager>().health -= damage;
            attackTimer = attackCooldown;
            GetComponent<Animator>().Play("MonsterAttack");
        }
    }

    void FindClosestBuilding()
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

        targetBuilding = closest;
    }
}
