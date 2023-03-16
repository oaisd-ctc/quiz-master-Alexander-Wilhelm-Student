using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "super based question", menuName = "epic question", order = 0)]
public class QuestionSO : ScriptableObject {

    [TextArea(2, 6)]
    [SerializeField] string Question {get;} = "what conundrum do you bring before the gods of knowledge";
    [SerializeField] string[] Answers {get;} = new string[4];
}
