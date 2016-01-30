using UnityEngine;
using System.Collections;

public class treeDestroy : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update() {

    }

    //when it passes through a tree
    void OnTriggerEnter2D(Collider2D c){
        GameObject other = c.gameObject;

        if (other.tag == "tree"){
            //Destroy(other);
            other.GetComponent<Animator>().Play("TreeDestroy");
        }
    }
}
