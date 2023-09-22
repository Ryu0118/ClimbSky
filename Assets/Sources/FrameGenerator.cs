using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class FrameGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject flamePrefab;
    GameObject player;
    float currentMaxPosition = 0.0f;
    void Start()
    {
        player = GameObject.Find("cat");
        for (int i = 0; i < 5; i++)
        {
            GameObject flame = Instantiate(flamePrefab);
            int positionX = UnityEngine.Random.Range(-2, 3);
            int positionY = UnityEngine.Random.Range(-3, 5);
            flame.transform.position = new Vector2(positionX, positionY);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float createRate = 1.0f;
        Vector2 playerPosition = player.transform.position;

        if (playerPosition.y - currentMaxPosition > createRate)
        {
            GameObject flame = Instantiate(flamePrefab);
            int positionX = UnityEngine.Random.Range(-2, 3);
            int positionY = UnityEngine.Random.Range((int)playerPosition.y + 5, (int)playerPosition.y + 10);
            flame.transform.position = new Vector3(positionX, positionY, 0); 
            currentMaxPosition = playerPosition.y;
        }
    }
}
