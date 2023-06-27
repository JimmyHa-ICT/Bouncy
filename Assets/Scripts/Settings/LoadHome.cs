using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadHome : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(int scene)
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.volume = PlayerPrefs.GetFloat("SFXVolume", 1.0f);
        audio.Play();
        SceneManager.LoadScene(scene);
    }
}
