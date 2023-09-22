using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameDirector : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject cat;
    GameObject distance;
    float offsetY = 0;
    float max = 0;
    void Start()
    {
        cat = GameObject.Find("cat");
        distance = GameObject.Find("distance");
        offsetY = cat.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        max = Math.Max(max, cat.transform.position.y - offsetY);
        distance.GetComponent<TextMeshProUGUI>().text = max.ToString("F1") + "M";
        GameScoreStatic.score = max;
    }
}
