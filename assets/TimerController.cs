using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    public float timeLeft = 60.0f;
    public TMP_Text timerText;
    public TMP_Text failText;
    public GameObject failPanel; 

    void Start()
    {
        if (failText != null)
        {
            failText.gameObject.SetActive(false);
        }
        if (failPanel != null)
        {
            failPanel.SetActive(false);
        }
    }

    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            
            float displayTime = Mathf.Max(timeLeft, 0);
            
            if (timerText != null)
            {
                timerText.text = Mathf.Ceil(displayTime).ToString();
            }
        }
        else
        {
            if (timerText != null)
            {
                timerText.text = "0";
            }
            
            if (failPanel != null && !failPanel.activeSelf)
            {
                failPanel.SetActive(true);
            }
            if (failText != null && !failText.gameObject.activeSelf)
            {
                failText.gameObject.SetActive(true);
            }
        }
    }
}