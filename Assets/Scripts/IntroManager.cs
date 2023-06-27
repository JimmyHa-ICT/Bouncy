using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ExitIntro", 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ExitIntro()
    {
        SceneManager.LoadScene(1);
    }
}
