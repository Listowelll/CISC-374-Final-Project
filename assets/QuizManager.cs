using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizController : MonoBehaviour
{
    [System.Serializable]
    public class Question
    {
        public string questionText;         
        public string[] options = new string[4];  
        public int correctOptionIndex;        
    }

    [Header("Quiz Data")]
    public Question[] questions;       

    [Header("UI References")]
    public TMP_Text questionTextUI;             
    public Button[] optionButtons;          
    public GameObject quizPanel;            
    public GameObject failPanel;      
    public GameObject completePanel; 
    public GameObject stopButton;

    private int currentQuestionIndex = 0;

    void Start()
    {
        if (failPanel != null)
        {
            failPanel.SetActive(false);
        }
        if (completePanel != null)
        {
            completePanel.SetActive(false);
        }
        if (stopButton != null) {
            stopButton.SetActive(true);
        }
        if (questions.Length > 0)
        {
            ShowQuestion();
        }
    }
    
    void ShowQuestion()
    {
        if (currentQuestionIndex < questions.Length)
        {
            Question q = questions[currentQuestionIndex];
            questionTextUI.text = q.questionText;
            for (int i = 0; i < optionButtons.Length; i++)
            {
                TMP_Text btnText = optionButtons[i].GetComponentInChildren<TMP_Text>();
                btnText.text = q.options[i];
            }
        }
        else
        {
            Debug.Log("Quiz completed successfully!");
            if (quizPanel != null)
            {
                quizPanel.SetActive(false);
            }
            if (completePanel != null)
            {
                completePanel.SetActive(true);
            }
            if (stopButton != null)
            {
                stopButton.SetActive(false);
            }
        }
    }

    public void OnOptionSelected(int optionIndex)
    {
        if (currentQuestionIndex < questions.Length)
        {
            Question q = questions[currentQuestionIndex];
            if (optionIndex == q.correctOptionIndex)
            {
                Debug.Log("Correct answer!");
                currentQuestionIndex++;
                ShowQuestion();
            }
            else
            {
                Debug.Log("Wrong answer!");
                if (failPanel != null)
                {
                    failPanel.SetActive(true);
                }
                if (stopButton != null)
                {
                    stopButton.SetActive(false);
                }
            }
        }
    }
}