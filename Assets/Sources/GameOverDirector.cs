using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameScoreStatic
{
    public static float score = 0;
}

public class GameOverDirector : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject report;
    void Start()
    {
        report = GameObject.Find("report");
        report.GetComponent<TextMeshProUGUI>().text = GameScoreStatic.score.ToString("F1") + "M";
    }

    public void tapToRestart() {
        SceneManager.LoadScene("GameScene"); 
    }
}
