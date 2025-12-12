using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioClip backgroundMusic;
    public AudioClip attackMusic;
    public AudioClip buttonMusic;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.clip = clip;
        sfxSource.PlayOneShot(clip);
    }
}
