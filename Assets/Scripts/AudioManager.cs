using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager I;      

    [Header("Clips")]
    public AudioClip bgmClip;
    public AudioClip correctClip;
    public AudioClip wrongClip;
    public AudioClip victoryClip;

    private AudioSource src;

    private void Awake()
    {
        if (I == null) { I = this; DontDestroyOnLoad(gameObject); }
        else { Destroy(gameObject); return; }

        src = GetComponent<AudioSource>();
        src.loop = true;
        src.playOnAwake = false;
    }

    private void Start()  
    {
        if (bgmClip != null)
        {
            src.clip = bgmClip;
            src.Play();
        }
    }

    public void PlayCorrect()  => src.PlayOneShot(correctClip);
    public void PlayWrong()    => src.PlayOneShot(wrongClip);
    public void PlayVictory()  => src.PlayOneShot(victoryClip);
}
