using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class quiz : MonoBehaviour
{
    [Header("Questions")]
    QuestionSO currentQuestion;
    [SerializeField] List<QuestionSO> questions;
    [SerializeField] TextMeshProUGUI questionText;


    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;

    int correctAnswerIndex;

    bool answeredEarly;

    [Header("Colors")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;

    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI scoreText;
    Score score;
    Slider slider;

    public bool complete;
    void Start()
    {
        timer = FindObjectOfType<Timer>();
        score = FindObjectOfType<Score>();
        slider = FindObjectOfType<Slider>();
        slider.maxValue = questions.Count;
        slider.value = 0;
    }

    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if (timer.loadquestion)
        {
            answeredEarly = false;
            GetNextQuestion();
            timer.loadquestion = false;
        }
        else if (!answeredEarly && !timer.answering)
        {
            DisplayAnswer(-1);
        }
    }



    void GetNextQuestion()
    {
        if (questions.Count > 0)
        {
            GetRandomQuestion();
            SetButtonState(true);
            SetDefaultButtonSprites();
            displayQuestion();
            slider.value = score.GetQuestionsSeen(); //ez
            score.IncrementSeen();
        } else complete = true;
    }

    void GetRandomQuestion()
    {
        int rand = Random.Range(0, questions.Count);
        currentQuestion = questions[rand];

        if (questions.Contains(currentQuestion)) questions.Remove(currentQuestion);
        Debug.Log($"QUESTIONS: {questions.Count}");
    }
    public void displayQuestion()
    {
        questionText.text = currentQuestion.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.GetAnswer(i);
        }
    }

    void SetButtonState(bool state)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }
    public void OnAnswerSelected(int x)
    {
        answeredEarly = true;
        DisplayAnswer(x);

        timer.CancelTimer();
        SetButtonState(false);
        scoreText.text = $"score: {score.CalculateScore()}%";

        if (slider.value == slider.maxValue) complete = true;
    }

    public void DisplayAnswer(int x)
    {
        Image buttonImage;

        if (x == currentQuestion.GetCorrectAnswer())
        {
            questionText.text = "based";
            buttonImage = answerButtons[x].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
            score.IncrementCorrect();
        }
        else
        {
            correctAnswerIndex = currentQuestion.GetCorrectAnswer();
            questionText.text = $"wrong. stupid. it was {currentQuestion.GetAnswer(correctAnswerIndex)}";
            answerButtons[correctAnswerIndex].GetComponent<Image>().sprite = correctAnswerSprite; // epic line of code
        }
    }
    void SetDefaultButtonSprites()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponent<Image>().sprite = defaultAnswerSprite;
        }
    }

}
