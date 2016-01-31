using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    int baseDamage = 1;
    float Distance;
    int TotalDamage;
    bool fired = false;
    Vector3 startPoint;
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
    }
    public void DistanceCheck()
    {
        if (Distance <= Vector2.Distance(startPoint, gameObject.transform.position))
        {
            Destroy(gameObject);
        }
    }
    
}
