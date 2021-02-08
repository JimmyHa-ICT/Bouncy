using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class GameManagerArcade : MonoBehaviour
{
    [SerializeField] int timeLeft = 60;
    public Text timeText;
    public Text scoreText;
    public Text highScoreText;
    public Button pauseButton;

    public GameObject gameOverPanel;
    public GameObject pausePanel;
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

        if (timeLeft <= 0)
            StopLevel();
    }

    void UpdateTimeText()
    {
        timeText.text = "Time: " + timeLeft;
    }

    void StopLevel()
    {
        timeLeft = 0;
        pauseButton.gameObject.SetActive(false);
        gameOverPanel.SetActive(true);
        Text score = gameOverPanel.transform.GetChild(1).gameObject.GetComponent<Text>();
        score.text = scoreText.text;
        ResetLevel(currentLevel);
        scoreText.gameObject.SetActive(false);
        timeText.gameObject.SetActive(false);
        highScoreText.gameObject.SetActive(false);

        foreach (GameObject ball in GameObject.FindGameObjectsWithTag("Ball"))
        {
            Destroy(ball);
        }
        level[currentLevel - 1].SetActive(false);
    }

    public void StartLevel(int levelNo)
    {
        pauseButton.gameObject.SetActive(true);
        GetComponent<AudioSource>().Play();
        levelMenu.SetActive(false);
        currentLevel = levelNo;
        scoreText.gameObject.SetActive(true);
        timeText.gameObject.SetActive(true);
        highScoreText.gameObject.SetActive(true);   
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
        highScoreText.gameObject.SetActive(true);   
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

        if (GameObject.Find("Traject"))
            GameObject.Find("Traject").SetActive(false);
        if (GameObject.Find("Trigger"))
            GameObject.Find("Trigger").GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
    }

    public void LoadScene(int scene)
    {
        GetComponent<AudioSource>().Play();
        
        if (Advertisement.IsReady())
            Advertisement.Show();

        SceneManager.LoadScene(scene);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);

    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void QuitLevel()
    {
        pausePanel.SetActive(false);
        StopCoroutine("TimeCounting");
        StopLevel();
        Time.timeScale = 1;
    }
}
