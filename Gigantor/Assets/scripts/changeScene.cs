using UnityEngine;
using System.Collections;

public class changeScene : MonoBehaviour {
    public int sceneIndex = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown && Time.timeSinceLevelLoad > 3) //buffer
        {
            Application.LoadLevel(sceneIndex);
        }
	}
}
