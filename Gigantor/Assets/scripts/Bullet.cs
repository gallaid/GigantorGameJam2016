using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    int baseDamage = 1;
    float Distance;
    int PayLoad;
    int TotalDamage;
    bool fired = false;
    Vector3 startPoint;
    public GameObject[] ExplosionMaster;
    private GameObject[] Explosions;
	// Use this for initialization
	void Start ()
    {
	startPoint = gameObject.transform.position;
	}

    // Update is called once per frame
    void Update()
    {
        if (fired) {
        DistanceCheck();
    }

	}
    public void Discharged(int payLoad,float distance)
    {
        Distance = distance;
        fired = true;
        PayLoad = payLoad;
        
    }
    public void DistanceCheck()
    {
        if (Distance <= Vector2.Distance(startPoint, gameObject.transform.position))
        {
            Explode();
        }
    }
    public void Explode()
    {
            GameObject exp = ExplosionMaster[PayLoad];
            GameObject Boom=Instantiate(exp, gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(Boom, .5f);
       
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag=="building"|| collider.gameObject.tag == "enemy")
        {
            Explode();
        }
    }
    
}
