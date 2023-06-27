using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    public Button nextLevelButton;
    public Button menuButton;
    public GameManagerChallenge gm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        Debug.Log(gm.currentLevel);
        if (gm.currentLevel > gm.level.Length - 1)
        {
            nextLevelButton.gameObject.SetActive(false);
            menuButton.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -180);
        }
        else
        {
            nextLevelButton.gameObject.SetActive(true);
            menuButton.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(160, -180);
        }
    }
}
