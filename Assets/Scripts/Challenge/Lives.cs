using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    public GameObject[] heart;
    //private int lives = 3;
    private LevelManager levelManager;

    void OnEnable()
    {
        levelManager = GameObject.FindWithTag("Level").GetComponent<LevelManager>();
        UpdateLives();
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateLives();
    }

    public void UpdateLives()
    {
        for (int i = 0; i < heart.Length; i++)
        {
            if (i < 3 - levelManager.trials)
                heart[i].SetActive(true);
            else
                heart[i].SetActive(false);
        }
    }
}
