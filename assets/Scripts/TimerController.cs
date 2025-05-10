using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    public float startSeconds = 60f;
    public TextMeshProUGUI timerText;

    private float timeLeft;
    private bool ticking;
    private GameManager gm;

    private void Awake() => gm = FindObjectOfType<GameManager>();

    public void StartTimer()
    {
        timeLeft = startSeconds;
        ticking = true;
        UpdateText();
    }

    public void PauseTimer(bool pause) => ticking = !pause;

    private void Update()
    {
        if (!ticking) return;

        timeLeft -= Time.deltaTime;
        UpdateText();

        if (timeLeft <= 0f)
        {
            ticking = false;
            AudioManager.I?.PlayWrong();
            gm.HandleFail();
        }
    }

    private void UpdateText() =>
        timerText.text = Mathf.CeilToInt(timeLeft).ToString("00");
}