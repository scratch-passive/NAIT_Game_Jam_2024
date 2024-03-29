using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform player;
    public Vector2 offset;

    // make sure to disable MSAA (or any AntiAliasing?) to solve issues with sprite sheet edges

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // get the camera to follow the player
        transform.position = new(player.position.x, player.position.y, transform.position.z);
    }
}
