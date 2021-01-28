using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public int score;
    public int levelMission;

    public int utilScore = 0;

    public Text scoreText;
    public Text trialText;
    public int trials = 0;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        DisplayScore();

        if (trialText)
            DisplayTrial();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void DisplayTrial()
    {
        if (trialText)
            trialText.text = "Trials: " + (6 - trials);
    }
}
