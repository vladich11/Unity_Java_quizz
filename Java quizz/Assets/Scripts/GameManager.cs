using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Question[] questions;
    private static List<Question> unansweredQuestions;

    private Question currentQuestion;


    [SerializeField]
    private Text ExplainText;
    [SerializeField]
    private Text factText;
    [SerializeField]
    private float timeBetweenQuestion = 1f;
    [SerializeField]
    private float timeBetweenExplain = 1f;
    [SerializeField]
    private Text trueAnswerText;
    [SerializeField]
    private Text falseAnswerText;
    [SerializeField]
    private Animator animator;

    void Start()
    {
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>();
        }

        SetCurrentQuestion();
    }
    void SetCurrentQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];
        factText.text = currentQuestion.fact;
        ExplainText.text = currentQuestion.Explain;
        unansweredQuestions.RemoveAt(randomQuestionIndex);

        if (currentQuestion.isTrue)
        {
            trueAnswerText.text = "WRONG";
            falseAnswerText.text = "CORRECT";
        }
        else
        {
            trueAnswerText.text = "CORRECT";
            falseAnswerText.text = "WRONG";
        }
    }
  

    IEnumerator TransitionToNextQuestion()
    {
        unansweredQuestions.Remove(currentQuestion);
        yield return new WaitForSeconds(timeBetweenQuestion);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    IEnumerator TransitionToNextExplain()
    {
        yield return new WaitForSeconds(timeBetweenExplain);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void UserSelectTrue()
    {
        animator.SetTrigger("true");
        
        if (falseAnswerText .text == "CORRECT")
        {
            animator.SetTrigger("explain");
            StartCoroutine(TransitionToNextExplain());
        
        }
        else
        {
            StartCoroutine(TransitionToNextQuestion());
        }
    }
    public void UserSelectFalse()
    {
        animator.SetTrigger("false");
        if (trueAnswerText.text == "CORRECT")
        { 
            animator.SetTrigger("explain");
            StartCoroutine(TransitionToNextExplain());
        }
        else
        {
            StartCoroutine(TransitionToNextQuestion());
        }
    }
}
