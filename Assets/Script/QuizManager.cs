using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{

    public List<QnAScript> QnA;
    public GameObject[] options;
    public int currentQuestion;

    // public Texture Questiontexture;

    public SpriteRenderer spriteRenderer;
    
    public TMP_Text QuestionText;

    private void Start()
    {
        generateQuestion();
    }
    public void correct()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }
    void SetAnswers()
    {
        for(int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = QnA[currentQuestion].Answers[i];
        
            if(QnA[currentQuestion].CorrectAnswer ==i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        currentQuestion = Random.Range(0, QnA.Count);
        QuestionText.text = QnA[currentQuestion].Question;
        //QuestionImage = QnA[currentQuestion].image;
        spriteRenderer.sprite = QnA[currentQuestion].image;

        SetAnswers();
    }
}
