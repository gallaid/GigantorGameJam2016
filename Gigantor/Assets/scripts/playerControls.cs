using UnityEngine;
using System.Collections;

public class playerControls : MonoBehaviour
{
    public float forwardSpeed = 0.05f;
    public float reverseSpeed = 0.02f;
    public float turnSpeed = 1f;
    public float speedMod = 1f;

    // Use this for initialization
    void Start()
    {

    }

    /*
    void Update()
    {
        if (Mathf.Abs(angle.x) > Mathf.Abs(angle.y))
        {
            if (angle.x > 0)
                GetComponent<Animator>().Play("playerWalkRight");

            if (angle.x < 0)
                GetComponent<Animator>().Play("playerWalkLeft");
        }

        if (Mathf.Abs(angle.x) < Mathf.Abs(angle.y))
        {
            if (angle.y > 0)
                GetComponent<Animator>().Play("playerWalkUp");

            if (angle.x < 0)
                GetComponent<Animator>().Play("playerWalkDown");
        }
    }

	void FixedUpdate () {
        //turn when rotating
        //transform.Rotate(new Vector3(0, 0, -turnSpeed * Input.GetAxis("Horizontal")));
        angle = Quaternion.Euler(0, 0, -turnSpeed * Input.GetAxis("Horizontal")) * angle;


        //if speed is forward
        if (Input.GetAxis("Vertical") > 0){
            transform.position += angle * forwardSpeed * speedMod * Input.GetAxis("Vertical");

        } else if (Input.GetAxis("Vertical") < 0){
            transform.position += angle * reverseSpeed * speedMod * Input.GetAxis("Vertical");

        }
    }
    */

    void FixedUpdate()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * forwardSpeed * speedMod;
        transform.position += direction;

        GetComponent<Animator>().speed = 1;

        if (direction.magnitude == 0)
        {
            GetComponent<Animator>().speed = 0;

        }

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
                GetComponent<Animator>().Play("playerWalkRight");

            if (direction.x < 0)
                GetComponent<Animator>().Play("playerWalkLeft");
        }

        if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
                GetComponent<Animator>().Play("playerWalkUp");

            if (direction.x < 0)
                GetComponent<Animator>().Play("playerWalkDown");
        }
    }
}
