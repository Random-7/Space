using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{

    public static BackgroundMusic backgroundMusic;

    [SerializeField] AudioClip[] audioClips;
    [SerializeField] AudioSource audioSource;
    int currentClip = 0;

    void Awake()
    {
        if (backgroundMusic == null)
            backgroundMusic = this;
        else
            Destroy(gameObject);
        
        DontDestroyOnLoad(gameObject);

        audioSource.clip = audioClips[currentClip];
        audioSource.Play();
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            currentClip++;
            if (currentClip > audioClips.Length - 1)
                currentClip = 0;
            audioSource.clip = audioClips[currentClip];
            audioSource.Play();
        }
    }
}
