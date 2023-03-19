using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float completionLength = 10f;
    [SerializeField] float reviewLength = 3f;
    
    [System.NonSerialized] public bool answering;

    float timer;

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
        if (answering) timerImage.fillAmount = timer/completionLength;
            else timerImage.fillAmount = timer/reviewLength;
        if (timer <= 0) {

            if (answering) timer = reviewLength;
            else timer = completionLength;
            answering = !answering;
            Debug.Log(timer);
        }
    }
}
