using UnityEngine;
using System.Collections;

public class treeDestroy : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //when it passes through a tree
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "tree")
        {
            //Destroy(other);
            c.GetComponent<Animator>().Play("TreeDestroy");
        }
    }
}
