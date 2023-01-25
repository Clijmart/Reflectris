using UnityEngine;

public class AudioController : MonoBehaviour
{
    [Header("Audio Options")]
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private float volume = 1f;

    /// <summary>
    /// Called just before any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        AudioManager.instance.PlaySound(audioClip, volume);
    }
}