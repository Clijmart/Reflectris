using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;

    internal static AudioManager instance;

    public void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public void PlayRandomSound(AudioClip[] audioClips)
    {
        int rand = Random.Range(0, audioClips.Length);
        PlaySound(audioClips[rand]);
    }
}
