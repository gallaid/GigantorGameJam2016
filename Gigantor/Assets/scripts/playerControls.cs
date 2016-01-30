using UnityEngine;
using System.Collections;

public class playerControls : MonoBehaviour {
    public float forwardSpeed = 0.05f;
    public float reverseSpeed = 0.02f;
    public float turnSpeed = 1f;
    

	// Use this for initialization
	void Start () {
	    
	}
	
	void FixedUpdate () {
        //turn when rotating
        transform.Rotate(new Vector3(0, 0, -turnSpeed * Input.GetAxis("Horizontal")));

        //if speed is forward
        if (Input.GetAxis("Vertical") > 0){
            transform.position += transform.up * forwardSpeed * Input.GetAxis("Vertical");

        } else if (Input.GetAxis("Vertical") < 0){
            transform.position += transform.up * reverseSpeed * Input.GetAxis("Vertical");

        }
    }
}
