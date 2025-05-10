using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI resultText;
    public Button[] optionButtons;

    private GameManager gm;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        for (int i = 0; i < optionButtons.Length; i++)
        {
            int captured = i;
            optionButtons[i].onClick.AddListener(() => gm.SubmitAnswer(captured));
        }
    }

    public void DisplayQuestion(QuestionData q)
    {
        questionText.text = q.question;
        for (int i = 0; i < optionButtons.Length; i++)
        {
            optionButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = q.options[i];
            optionButtons[i].gameObject.SetActive(i < q.options.Length);
        }
        resultText.text = "";
    }

    public void ShowAnswerResult(bool success)
    {
        resultText.text = success ? "Correct! Chest opened!" : "Wrong! Try again.";
    }

    public void ShowGameWon()
    {
        questionText.text = "Congratulations! You collected all treasures!";
        foreach (var btn in optionButtons)
            btn.gameObject.SetActive(false);
        resultText.text = "";
    }
}