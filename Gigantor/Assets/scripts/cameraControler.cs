using UnityEngine;
using System.Collections;

public class cameraControler : MonoBehaviour {
    public GameObject player;
    private Camera mainCamera;

    private float zoom = 5;
    public float minZoom = 2;
    public float maxZoom = 20;
    public float zoomSpeed = 1;

	// Use this for initialization
	void Start () {
        mainCamera = Camera.main;
    }
	
	// Update is called once per frame
	void Update () {
        //camera follows player
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

        //zooming in and out
        zoom += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        if (zoom < minZoom)
            zoom = minZoom;
        if (zoom > maxZoom)
            zoom = maxZoom;

        mainCamera.orthographicSize = zoom;
    }
}
