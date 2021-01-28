using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Trigger : MonoBehaviour, IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] Canvas parentCanvas;
    private RectTransform rectTransform;
    public GameObject ball;
    public float velocityModifier;
    public float radius;
    public GameObject[] trajectory;
    public LevelManager levelManager;

    private AudioSource shootSound;

    [SerializeField] int trajectory_step = 7;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        shootSound = GetComponent<AudioSource>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / parentCanvas.scaleFactor;
        
        Vector2 pos = rectTransform.anchoredPosition;
        if (pos.magnitude > radius)
        {
            rectTransform.anchoredPosition = pos * radius / pos.magnitude;
        }

        Rigidbody2D ballRb = ball.GetComponent<Rigidbody2D>();
        Vector2 velocity = -rectTransform.anchoredPosition / velocityModifier;
        Debug.Log(velocity);

        Vector2[] location = Plot(ballRb, new Vector2(0, 0), velocity, trajectory_step);

        trajectory[0].transform.parent.gameObject.SetActive(true);
        for (int i = 0; i < trajectory.Length;i++)
        {
            //Debug.Log(location);
            //trajectory[i].SetActive(true);
            trajectory[i].GetComponent<RectTransform>().anchoredPosition = location[i];  
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ThrowBall();
        rectTransform.anchoredPosition = new Vector2(0, 0);
    }

    private void ThrowBall()
    {
        shootSound.Play();
        levelManager.trials++;
        LevelManager lv = GameObject.FindWithTag("Level").GetComponent<LevelManager>();
        lv.DisplayTrial();

        GameObject newBall = Instantiate(ball);
        newBall.transform.SetParent(transform.parent.transform.parent);
        newBall.GetComponent<RectTransform>().anchoredPosition = GameObject.Find("Aim Controller").GetComponent<RectTransform>().anchoredPosition;
        newBall.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

        Rigidbody2D ballRb = newBall.GetComponent<Rigidbody2D>();
        ballRb.velocity = -rectTransform.anchoredPosition / velocityModifier;
    }

    public static Vector2[] Plot(Rigidbody2D rigidbody, Vector2 pos, Vector2 velocity, int steps)
    {
        Vector2[] results = new Vector2[steps];
    
        float timestep = 0;
        //Vector2 gravityAccel = Physics2D.gravity * rigidbody.gravityScale * timestep * timestep;
    
        for (int i = 0; i < steps; ++i)
        {
            timestep += 5f;
            pos.x = timestep * velocity.x;
            pos.y = velocity.y * timestep - 0.42f * Physics2D.gravity.magnitude * rigidbody.gravityScale
                                                * timestep * timestep * Time.fixedDeltaTime;        // convert gravity from m/s2 to m/timestep^2 (timestep relate to FPS)
            results[i] = pos;
        }
    
        return results;
    }
}