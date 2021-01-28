using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
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
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(scene);
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
