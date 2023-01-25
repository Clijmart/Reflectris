using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField]
    private AudioClip audioClip;
    [SerializeField]
    private float volume = 1f;

    private void Start()
    {
        AudioManager.instance.PlaySound(audioClip, volume);
    }
}
