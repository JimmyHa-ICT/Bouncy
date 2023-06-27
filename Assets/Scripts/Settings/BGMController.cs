using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BGMController : MonoBehaviour, IPointerUpHandler
{
    private AudioSource audioSource;
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.Find("BGM").GetComponent<AudioSource>();
        slider = GetComponent<Slider>();
        slider.value = PlayerPrefs.GetFloat("BGMVolume", audioSource.volume);
        slider.onValueChanged.AddListener(delegate {AdjustVolume(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AdjustVolume()
    {
        audioSource.volume = slider.value;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        PlayerPrefs.SetFloat("BGMVolume", audioSource.volume);
    }
}