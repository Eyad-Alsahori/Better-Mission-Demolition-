using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Create a static reference to the AudioManager
    public static AudioManager instance;

    // Add any audio clips or audio sources you need
    public AudioClip backgroundMusic;
    public AudioSource backgroundMusicSource;
    public AudioClip gunshotSound;
    public AudioSource gunshotSoundSource;

    private void Awake()
    {
        // Implement the Singleton pattern
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        // Initialize audio sources
        backgroundMusicSource = gameObject.AddComponent<AudioSource>();
        gunshotSoundSource = gameObject.AddComponent<AudioSource>();
    }

    private void Start()
    {
        // Play background music when the game starts
        AudioManager.instance.PlayBackgroundMusic(backgroundMusic);
    }
    public void PlayBackgroundMusic(AudioClip music)
    {
        backgroundMusicSource.clip = music;
        backgroundMusicSource.loop = true;
        backgroundMusicSource.Play();
    }

    public void PlayGunshotSound()
    {
        gunshotSoundSource.PlayOneShot(gunshotSound);
    }

    // Add more audio-related functions as needed
}