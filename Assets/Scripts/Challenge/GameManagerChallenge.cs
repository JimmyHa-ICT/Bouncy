using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerChallenge : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject levelMenu;

    public GameObject losePanel;

    public GameObject[] level;
    public int currentLevel;
    public Image[] star;

    public Text trialText;

    void Start()
    {
        //StartLevel(3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StopLevel(int trials, bool completed)
    {        
        if (completed)
        {
            gameOverPanel.SetActive(true);

            if (trials > 3)
            {    
                star[0].color = new Color(1, 1, 1, 1);
                star[1].color = new Color(0, 0, 0, 0.3f);
                star[2].color = new Color(0, 0, 0, 0.3f);
            }

            else if (trials > 1)
            {
                star[0].color = new Color(1, 1, 1, 1);
                star[1].color = new Color(0, 0, 0, 0.3f);
                star[2].color = new Color(1, 1, 1, 1);
            }

            else
            {
                star[0].color = new Color(1, 1, 1, 1);
                star[1].color = new Color(1, 1, 1, 1);
                star[2].color = new Color(1, 1, 1, 1);
            }
        }

        else
        {
            losePanel.SetActive(true);
        }
        

        ResetLevel(currentLevel);
        
        foreach (GameObject ball in GameObject.FindGameObjectsWithTag("Ball"))
        {
            Destroy(ball);
        }
        level[currentLevel - 1].SetActive(false);
        trialText.gameObject.SetActive(false);
    }

    public void StartLevel(int levelNo)
    {
        GetComponent<AudioSource>().Play();
        levelMenu.SetActive(false);
        currentLevel = levelNo;
        level[currentLevel - 1].SetActive(true);
        trialText.gameObject.SetActive(true);
    }

    public void ShowLevels()
    {
        level[currentLevel - 1].SetActive(false);
        trialText.gameObject.SetActive(false);
        GetComponent<AudioSource>().Play();
        gameOverPanel.SetActive(false);
        losePanel.SetActive(false);
        levelMenu.SetActive(true);
    }

    public void RestartLevel()
    {
        GetComponent<AudioSource>().Play();
        gameOverPanel.SetActive(false);
        losePanel.SetActive(false);
        level[currentLevel - 1].SetActive(true);
        trialText.gameObject.SetActive(true);
    }

    void ResetLevel(int l)
    {
        if (GameObject.Find("Traject"))
            GameObject.Find("Traject").SetActive(false);
        
        if (GameObject.Find("Trigger"))
            GameObject.Find("Trigger").GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);

        if (GameObject.FindWithTag("Basket").GetComponent<Complete>())
            GameObject.FindWithTag("Basket").GetComponent<Complete>().completed = false;

        level[l - 1].GetComponent<LevelManager>().trials = 0;
        level[l - 1].GetComponent<LevelManager>().DisplayTrial();
    }

    public void LoadScene(int scene)
    {
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(scene);
    }
}
