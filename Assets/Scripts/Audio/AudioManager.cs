using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private AudioSource audioSource;

    /// <summary>
    /// Called when the instance is being loaded.
    /// </summary>
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(transform.gameObject);
    }

    /// <summary>
    /// Called just before any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Play an audio clip at a given volume.
    /// </summary>
    /// <param name="audioClip">The audio clip to play.</param>
    /// <param name="volume">The base volume the clip will be played at.</param>
    public void PlaySound(AudioClip audioClip, float volume)
    {
        audioSource.clip = audioClip;
        audioSource.volume = volume * VolumeMultiplier();
        audioSource.Play();
    }

    /// <summary>
    /// Play a random audio clip from an array at a given volume.
    /// </summary>
    /// <param name="audioClips">The array of audio clips to play from.</param>
    /// <param name="volume">The base volume the clip will be played at.</param>
    public void PlayRandomSound(AudioClip[] audioClips, float volume)
    {
        int rand = Random.Range(0, audioClips.Length);
        PlaySound(audioClip: audioClips[rand], volume: volume * VolumeMultiplier());
    }

    /// <summary>
    /// Get the volume multiplier from settings.
    /// </summary>
    /// <returns>The volume multiplier.</returns>
    public float VolumeMultiplier()
    {
        return SettingsManager.instance.volume;
    }
}