using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerArcade : MonoBehaviour
{
    [SerializeField] int timeLeft = 60;
    public Text timeText;
    public Text scoreText;
    public GameObject gameOverPanel;
    public GameObject levelMenu;

    public GameObject[] level;
    public int currentLevel;

    void Start()
    {
        //StartLevel(3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TimeCounting()
    {
        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(1.0f);

            timeLeft--;
            UpdateTimeText();
        }

        if (timeLeft == 0)
            StopLevel();
    }

    void UpdateTimeText()
    {
        timeText.text = "Time: " + timeLeft;
    }

    void StopLevel()
    {
        gameOverPanel.SetActive(true);
        Text score = gameOverPanel.transform.GetChild(1).gameObject.GetComponent<Text>();
        score.text = scoreText.text.Remove(0, 7);
        ResetLevel(currentLevel);
        scoreText.gameObject.SetActive(false);
        timeText.gameObject.SetActive(false);
        foreach (GameObject ball in GameObject.FindGameObjectsWithTag("Ball"))
        {
            Destroy(ball);
        }
        level[currentLevel - 1].SetActive(false);
    }

    public void StartLevel(int levelNo)
    {
        GetComponent<AudioSource>().Play();
        levelMenu.SetActive(false);
        currentLevel = levelNo;
        scoreText.gameObject.SetActive(true);
        timeText.gameObject.SetActive(true);        
        level[currentLevel - 1].SetActive(true);
        UpdateTimeText();
        StartCoroutine("TimeCounting");
    }

    public void ShowLevels()
    {
        GetComponent<AudioSource>().Play();
        gameOverPanel.SetActive(false);
        levelMenu.SetActive(true);
    }

    public void RestartLevel()
    {
        GetComponent<AudioSource>().Play();
        gameOverPanel.SetActive(false);
        scoreText.gameObject.SetActive(true);
        timeText.gameObject.SetActive(true);        
        level[currentLevel - 1].SetActive(true);
        UpdateTimeText();
        StartCoroutine("TimeCounting");
    }

    void ResetLevel(int l)
    {
        timeLeft = 60;
        UpdateTimeText();
        LevelManager lm = level[l - 1].GetComponent<LevelManager>();
        lm.score = 0;
        lm.utilScore = 0;
        lm.trials = 0;
        lm.DisplayScore();
        GameObject.Find("Traject").SetActive(false);
        GameObject.Find("Trigger").GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
    }

    public void LoadScene(int scene)
    {
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(scene);
    }
}
