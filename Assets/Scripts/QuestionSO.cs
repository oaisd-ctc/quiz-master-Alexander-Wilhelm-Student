using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "super based question", menuName = "epic question", order = 0)]
public class QuestionSO : ScriptableObject {

    [TextArea(2, 6)]
    [SerializeField] string Question = "what conundrum do you bring before the gods of knowledge";
    [SerializeField] string[] Answers = new string[4];

    [SerializeField] int CorrectAnswer;

    public string GetQuestion() {
        return Question;
    }

    public string GetAnswer(int x) {
        return Answers[x];
    }

    public int GetCorrectAnswer() {
        return CorrectAnswer;
    }
}

