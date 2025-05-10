using UnityEngine;

public class PausePanel : MonoBehaviour
{
    public GameObject panel;         
    public TimerController timer;

    private void Awake() => panel.SetActive(false);

    public void TogglePause()
    {
        bool show = !panel.activeSelf;
        panel.SetActive(show);
        timer.PauseTimer(show);
        Time.timeScale = show ? 0 : 1;   
    }

    public void Restart()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}