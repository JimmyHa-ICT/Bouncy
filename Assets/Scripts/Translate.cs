using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translate : MonoBehaviour
{
    public float angle = 0;
    public float xVelocity = 0;
    public float yVelocity = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = GetComponent<RectTransform>().anchoredPosition;
        GetComponent<RectTransform>().anchoredPosition = position + new Vector2(Mathf.Sin(angle) * xVelocity, Mathf.Sin(angle) * yVelocity);
        
        angle += Mathf.PI / 2 * Time.deltaTime;
        if (angle > 2 * Mathf.PI)
            angle -= Mathf.PI * 2;
    }
}
