using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int hitCount = 0;

    private Rigidbody2D ballRb;

    private AudioSource hitSound;

    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
        hitSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        RectTransform rt = GetComponent<RectTransform>();

        if (ballRb.velocity.magnitude < 0.1 && rt.anchoredPosition.y <= -110)
        {
            Destroy(gameObject);
            ProcessBall();
        }

        if (rt.anchoredPosition.x < -500 || rt.anchoredPosition.x > 500)
        {
            Destroy(gameObject);
            ProcessBall();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Box"))
        {
            hitSound.Play();
            hitCount++;
            Debug.Log("Hit");
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            if (GameObject.FindWithTag("Level"))
                GameObject.FindWithTag("Level").GetComponent<LevelManager>().utilScore = 0;
        }
    }

    void ProcessBall()
    {
        GameObject lives = GameObject.Find("Lives");
        Complete complete = GameObject.FindWithTag("Basket").GetComponent<Complete>();
        LevelManager lvManager = GameObject.FindWithTag("Level").GetComponent<LevelManager>();

        if (lives)
            lives.GetComponent<Lives>().UpdateLives();

        if (complete && !complete.completed && lvManager.trials >= 3)
        {
            complete.StopLevel();
        }
    }
}
