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
    public Text highScoreText;
    
    public int trials = 0;
    public int highscore;


    // Start is called before the first frame update
    void OnEnable()
    {
        score = 0;

        string key = "highscore" + gameObject.name.Remove(0, 5);
        highscore = PlayerPrefs.GetInt(key, 0);

        DisplayScore();

        if (highScoreText)
            DisplayHighscore();

        if (trialText)
            DisplayTrial();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayScore()
    {
        if (scoreText)
            scoreText.text = score.ToString();
    }

    public void DisplayTrial()
    {
        if (trialText)
            trialText.text = "Trials: " + (6 - trials);
    }

    public void UpdateHighScore()
    {
        string key = "highscore" + gameObject.name.Remove(0, 5);
        PlayerPrefs.SetInt(key, highscore);
    }

    public void DisplayHighscore()
    {
        highScoreText.text = "High score: " + highscore;
    }
}
