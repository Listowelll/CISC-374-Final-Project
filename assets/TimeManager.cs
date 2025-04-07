// TimeManager.cs
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float initialTime = 60f;
    [SerializeField] float timePenalty = 5f;
    
    [Header("References")]
    [SerializeField] TMP_Text timerText;
    
    private float _currentTime;
    private bool _isActive = true;

    void Start() => ResetTimer();

    void Update()
    {
        if (!_isActive) return;
        
        _currentTime -= Time.deltaTime;
        UpdateDisplay();
        
        if (_currentTime <= 0) TriggerGameOver();
    }

    public void ApplyPenalty() => _currentTime -= timePenalty;

    private void UpdateDisplay()
    {
        timerText.text = $"<mspace=0.6em>{Mathf.Max(_currentTime, 0):00.00}</mspace>";
        timerText.color = Color.Lerp(Color.red, Color.green, _currentTime / initialTime);
    }

    public void ResetTimer()
    {
        _currentTime = initialTime;
        _isActive = true;
    }

    private void TriggerGameOver()
    {
        _isActive = false;
        // 连接游戏结束逻辑
    }
}