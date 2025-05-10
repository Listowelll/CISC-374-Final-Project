using UnityEngine;

public class StartPanel : MonoBehaviour
{
    public GameObject panel;             
    public GameManager gameManager;
    public TimerController timer;

    private void Awake() => panel.SetActive(true);

    public void StartGame()
    {
        panel.SetActive(false);
        gameManager.StartFirstQuestion(); 
        timer.StartTimer();
    }
}