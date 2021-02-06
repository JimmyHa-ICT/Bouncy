using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translate : MonoBehaviour
{
    public float angle = 0;
    public float xMagnitude = 0;
    public float yMagnitude = 0;
    private Vector2 position;

    // Start is called before the first frame update
    void Start()
    {
        position = GetComponent<RectTransform>().anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        angle += Mathf.PI / 2 * Time.deltaTime;
        if (angle > 2 * Mathf.PI)
            angle -= Mathf.PI * 2;

        GetComponent<RectTransform>().anchoredPosition = position + new Vector2(Mathf.Sin(angle) * xMagnitude, Mathf.Sin(angle) * yMagnitude);    
        
    }
}
