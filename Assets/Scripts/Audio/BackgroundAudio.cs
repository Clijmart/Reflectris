using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Made using https://answers.unity.com/questions/1260393/make-music-continue-playing-through-scenes.html
public class BackgroundAudio : MonoBehaviour
{
    private static BackgroundAudio instance = null;

    private AudioSource audioSource;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;

        DontDestroyOnLoad(transform.gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        audioSource.volume = AudioManager.instance.VolumeMultiplier();
    }

    public void PlayMusic()
    {
        if (audioSource.isPlaying) return;
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }

    public void ReplayMusic()
    {
        StopMusic();
        PlayMusic();
    }
}
