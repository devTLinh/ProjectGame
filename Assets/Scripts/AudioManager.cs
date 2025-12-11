using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioClip backgroundMusic; 
    void Start()
    {
        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }

}
