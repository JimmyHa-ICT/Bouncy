using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SFXController : MonoBehaviour, IPointerUpHandler
{
    Slider sfxSlider;

    // Start is called before the first frame update
    void Start()
    {
        sfxSlider = GetComponent<Slider>();
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);
    }
}
