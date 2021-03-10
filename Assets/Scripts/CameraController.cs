using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField, Tooltip("Distance from player to camera")]
    private float camHeight = 7;
    [SerializeField, Tooltip("The player object")]
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = player.transform.position + new Vector3(0, camHeight, 0);//tell the camera to move to a point 7 units above the player

    }

}
