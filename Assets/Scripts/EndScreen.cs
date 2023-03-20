using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class EndScreen : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreText;
    Score score;

    void Start()
    {
        score = FindObjectOfType<Score>();
    }

    public void ShowFinalScore() {
        scoreText.text = $"{score.CalculateScore()}%";
    }

    

}
