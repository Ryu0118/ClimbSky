using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    void Start()
    {
        this.player = GameObject.Find("cat");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = this.player.transform.position;
        transform.position = new Vector3(transform.position.x, Math.Max(0, playerPosition.y), transform.position.z);
    }
}
