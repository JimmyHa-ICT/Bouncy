using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Complete : MonoBehaviour
{
    public GameObject levelObject;

    private LevelManager levelManager;
    private AudioSource collectedSound;

    public GameManagerChallenge gameManager;

    public bool completed = false;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = levelObject.GetComponent<LevelManager>();
        collectedSound = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void LateUpdate() {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Ball"))
        {
            //Debug.Log("In");
            int hitCount = other.GetComponent<Ball>().hitCount;

            if (hitCount == levelManager.levelMission)
            {   
                completed = true;     
                collectedSound.Play();
                Invoke("StopLevel", 1.0f);
            }
        }
    }

    public void StopLevel()
    {
        gameManager.StopLevel(levelManager.trials, completed);
    }
}
