using UnityEngine;
using System.Collections;

public class cameraControler : MonoBehaviour {
    public GameObject player;
    private Camera mainCamera;

    private float zoom = 5;
    public float minZoom = 2;
    public float maxZoom = 20;
    public float zoomSpeed = 1;

    public float panSpeed = 1;
    public float playerEdgeTolerance = 0.1f;

    // Use this for initialization
    void Start () {
        mainCamera = Camera.main;
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update () {
        //zooming in and out
        zoom += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        if (zoom < minZoom)
            zoom = minZoom;
        if (zoom > maxZoom)
            zoom = maxZoom;

        mainCamera.orthographicSize = zoom;

        //move camera with right click drag
        if (Input.GetKey(KeyCode.Mouse1))
        {
            transform.position += new Vector3(Input.GetAxis("Mouse X") * -panSpeed, Input.GetAxis("Mouse Y") * -panSpeed, 0);
        }
        
        //keep the player on the screen
        Vector3 lowLeftBound = mainCamera.ViewportToWorldPoint(new Vector3(playerEdgeTolerance, playerEdgeTolerance));
        Vector3 topRightBound = mainCamera.ViewportToWorldPoint(new Vector3(1- playerEdgeTolerance, 1 - playerEdgeTolerance));
        Vector3 temp = new Vector3(0,0,0);

        if (player.transform.position.x < lowLeftBound.x)
            temp.x = player.transform.position.x - lowLeftBound.x;
        if (player.transform.position.y < lowLeftBound.y)
            temp.y = player.transform.position.y - lowLeftBound.y;
        if (player.transform.position.x > topRightBound.x)
            temp.x = player.transform.position.x - topRightBound.x;
        if (player.transform.position.y > topRightBound.y)
            temp.y = player.transform.position.y - topRightBound.y;

        transform.position += temp;
    }
}
