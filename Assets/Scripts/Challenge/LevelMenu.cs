using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    [SerializeField] int levelAt;
    public Button[] levelButton;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void OnEnable()
    {
        levelAt = PlayerPrefs.GetInt("levelAt", 1);

        for (int i = 0; i < levelButton.Length; i++)
        {
            if (i + 1 > levelAt)
                levelButton[i].interactable = false;
            else
                levelButton[i].interactable = true;
        }
    }
}
