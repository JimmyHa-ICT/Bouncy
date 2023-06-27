using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    private SpriteRenderer spRender;
    [SerializeField] Color secondColor;
    Color defaultColor;

    Animation anim; 

    // Start is called before the first frame update
    void Start()
    {
        spRender = GetComponent<SpriteRenderer>();
        //secondColor = new Color(240/255, 200/255, 65/255, 1);
        defaultColor = spRender.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col) 
    {
        if (col.gameObject.CompareTag("Ball"))
            TweenColor();
    }

    void TweenColor()
    {
        spRender.color =  secondColor;
        Invoke("ResetColor", 0.25f);
    }

    void ResetColor()
    {
        spRender.color = new Color(217, 0, 165, 255);
    }
}
