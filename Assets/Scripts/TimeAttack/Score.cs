using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public GameObject levelObject;

    private LevelManager levelManager;
    private AudioSource collectedSound;

    public GameObject tween;
    public GameObject tweenParent;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = levelObject.GetComponent<LevelManager>();   
        collectedSound = GetComponent<AudioSource>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("In");
            int hitCount = other.GetComponent<Ball>().hitCount;

            if (hitCount == levelManager.levelMission)
            {
                collectedSound.Play();
                levelManager.score += (levelManager.utilScore + 1);
                
                if (levelManager.utilScore == 0)
                    CreateTween("+" + (levelManager.utilScore + 1));
                else
                    CreateTween("Streak +" + (levelManager.utilScore + 1));
                levelManager.utilScore++;

                if (levelManager.score > levelManager.highscore)
                {
                    levelManager.highscore = levelManager.score;
                    levelManager.UpdateHighScore();
                }

                levelManager.DisplayScore();
                levelManager.DisplayHighscore();
            }
        }
    }

    private void CreateTween(string s)
    {
        GameObject t =  Instantiate(tween);
        t.transform.SetParent(tweenParent.transform);
        t.GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(4.5f, 5.5f), -1);
        t.GetComponent<Tween>().SetText(s);
    }
}
