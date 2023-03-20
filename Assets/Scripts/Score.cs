using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour


{

    int questionsCorrect;
    int questionsSeen;


    public int GetQuestionsCorrect() {
        return questionsCorrect;
    }

    public int GetQuestionsSeen() {
        return questionsSeen;
    }

    public void IncrementCorrect() {
        questionsCorrect++;
    }

    public void IncrementSeen() {
        questionsSeen++;
    }

    public int CalculateScore() {
        return Mathf.RoundToInt(questionsCorrect/((float)questionsSeen)*100);
    }
}
