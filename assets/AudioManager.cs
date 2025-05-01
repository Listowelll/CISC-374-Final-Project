using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip correctAnswerSound;
    public AudioClip wrongAnswerSound;
    public AudioClip buttonClickSound;
    public AudioClip gameCompletedSound;
    
    private AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }
    
    public void PlayCorrectSound()
    {
        PlaySound(correctAnswerSound);
    }
    
    public void PlayWrongSound()
    {
        PlaySound(wrongAnswerSound);
    }
    
    public void PlayButtonClickSound()
    {
        PlaySound(buttonClickSound);
    }
    
    public void PlayGameCompletedSound()
    {
        PlaySound(gameCompletedSound);
    }
    
    private void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}