using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float completionLength = 10f;
    [SerializeField] float reviewLength = 3f;
    
    [System.NonSerialized] public bool loadquestion;
    [System.NonSerialized] public bool answering;

    float timer;
    [System.NonSerialized] public float fillFraction;
    Image timerImage;
    // Start is called before the first frame update
    void Start()
    {
        timerImage = GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer() {
        timer -= Time.deltaTime;
        if (answering) fillFraction = timer/completionLength;
            else fillFraction = timer/reviewLength;
        if (timer <= 0) {

            if (answering) timer = reviewLength;
            else {
                timer = completionLength;
                loadquestion = true;
            } 
            answering = !answering;
            Debug.Log(timer);
        }
    }

    public void CancelTimer()
    {
        timer = 0;
    }

}
