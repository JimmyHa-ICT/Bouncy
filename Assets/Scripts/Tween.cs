using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tween : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SelfDestroy");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 1f) * Time.deltaTime;
        Text t = GetComponent<Text>();
        t.color = new Color(t.color.r, t.color.g, t.color.b, t.color.a - 1 * Time.deltaTime);
    }

    IEnumerator SelfDestroy()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            Destroy(gameObject);
        }        
    }

    public void SetText(string s)
    {
        GetComponent<Text>().text = s;
    }
}
