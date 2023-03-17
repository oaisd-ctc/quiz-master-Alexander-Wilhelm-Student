using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class quiz : MonoBehaviour
{
    [SerializeField] QuestionSO question;
    [SerializeField] TextMeshProUGUI questionText;

    [SerializeField] GameObject[] answerButtons;

    int correctAnswerIndex;

    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    void Start()
    {
        GetNextQuestion();
    }

    void GetNextQuestion() {
        SetButtonState(true);
        SetDefaultButtonSprites();
        displayQuestion();
    }
    public void displayQuestion()
    {
        questionText.text = question.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
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
        Image buttonImage;

        if (x == question.GetCorrectAnswer())
        {
            questionText.text = "based";
            buttonImage = answerButtons[x].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else
        {
            correctAnswerIndex = question.GetCorrectAnswer();
            questionText.text = $"wrong. stupid. it was {question.GetAnswer(correctAnswerIndex)}";
            answerButtons[correctAnswerIndex].GetComponent<Image>().sprite = correctAnswerSprite; // epic line of code
        }

        SetButtonState(false);
    }

    void SetDefaultButtonSprites() {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponent<Image>().sprite = defaultAnswerSprite;
        }
    }
}
