using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource backGroundAudioSource;
    public AudioSource effectAudioSource;

    public AudioClip backGroundClip;
    public AudioClip jumpClip;
    public AudioClip coinClip;

    public Slider sfxSlider;

    void Awake()
    {
        // Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        PlayBackGroundMusic();
        sfxSlider.onValueChanged.AddListener(delegate {OnValueChange(); }); 
        LoadVolume(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBackGroundMusic()
    {
        backGroundAudioSource.clip = backGroundClip;
        backGroundAudioSource.Play();
    }

    public void PlayCoinSound()
    {
        effectAudioSource.PlayOneShot(coinClip);
    }

    public void PlayJumpSound()
    {
        effectAudioSource.PlayOneShot(jumpClip);
    }

    public void SetVolume(float volume)
    {
        backGroundAudioSource.volume = volume; 
        effectAudioSource.volume = volume;
    }

    public void OnValueChange()
    {
        SetVolume(sfxSlider.value);
    }
    void LoadVolume()
    {
        float volume = PlayerPrefs.GetFloat("MasterVolume", 1f);

        backGroundAudioSource.volume = volume;
        effectAudioSource.volume = volume;
    }
}
