using UnityEngine;
using System.Collections;

public class monsterSpawner : MonoBehaviour {
    public GameObject basicMonster;

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update() {
        Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        point.z = 0;
        if (Input.GetKeyDown(KeyCode.Space))
            Instantiate(basicMonster, point, Quaternion.identity);
    }
}
