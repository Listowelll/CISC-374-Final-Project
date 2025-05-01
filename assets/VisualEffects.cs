using UnityEngine;
using System.Collections;

public class VisualEffects : MonoBehaviour
{
    public GameObject confettiPrefab;
    public RectTransform canvasRect;
    
    // Screen shake parameters
    public float shakeDuration = 0.5f;
    public float shakeAmount = 5f;
    private Vector3 originalPosition;
    private RectTransform panelRectTransform;
    
    void Start()
    {
        panelRectTransform = GetComponent<RectTransform>();
        originalPosition = panelRectTransform.localPosition;
    }
    
    public void PlayCorrectEffect()
    {
        if (confettiPrefab != null && canvasRect != null)
        {
            // Instantiate confetti at random positions
            for (int i = 0; i < 20; i++)
            {
                float randomX = Random.Range(-canvasRect.rect.width/2, canvasRect.rect.width/2);
                float randomY = Random.Range(-canvasRect.rect.height/2, canvasRect.rect.height/2);
                
                Vector3 position = new Vector3(randomX, randomY, 0);
                GameObject confetti = Instantiate(confettiPrefab, position, Quaternion.identity);
                confetti.transform.SetParent(canvasRect, false);
                
                // Destroy after 2 seconds
                Destroy(confetti, 2f);
            }
        }
    }
    
    public void PlayWrongEffect()
    {
        StartCoroutine(ShakePanel());
    }
    
    private IEnumerator ShakePanel()
    {
        float elapsed = 0f;
        
        while (elapsed < shakeDuration)
        {
            Vector3 randomPos = originalPosition + Random.insideUnitSphere * shakeAmount;
            randomPos.z = originalPosition.z; // Keep the z-position unchanged
            
            panelRectTransform.localPosition = randomPos;
            
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }
        
        panelRectTransform.localPosition = originalPosition;
    }
}