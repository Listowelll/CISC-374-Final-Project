using UnityEngine;
using TMPro;

public class FailPanel : MonoBehaviour
{
    public GameObject panel;               
    public TextMeshProUGUI feedbackText;    
    public TimerController timer;

    public void ShowFail(string tip)
    {
        timer.PauseTimer(true);
        feedbackText.text = tip;
        panel.SetActive(true);
    }

    public void ShowFail()
    {
        ShowFail(string.Empty);
    }

    public void Restart() => UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    public void Close()   => panel.SetActive(false);
}