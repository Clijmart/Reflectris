using UnityEngine;

/// <summary>
/// Object used to play background audio.
/// Made using https://answers.unity.com/questions/1260393/make-music-continue-playing-through-scenes.html
/// </summary>
public class BackgroundAudio : MonoBehaviour
{
    private static BackgroundAudio instance = null;

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
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Called every frame.
    /// </summary>
    private void Update()
    {
        audioSource.volume = AudioManager.instance.VolumeMultiplier();
    }

    /// <summary>
    /// Toggle the background music on.
    /// </summary>
    public void PlayMusic()
    {
        if (audioSource.isPlaying) return;
        audioSource.Play();
    }

    /// <summary>
    /// Toggle the background music off.
    /// </summary>
    public void StopMusic()
    {
        audioSource.Stop();
    }

    /// <summary>
    /// 
    /// Restart the background music.
    /// </summary>
    public void ReplayMusic()
    {
        StopMusic();
        PlayMusic();
    }

    /// <summary>
    /// Pause the background music.
    /// </summary>
    public void PauseMusic()
    {
        audioSource.Pause();
    }

    /// <summary>
    /// Unpause the background music.
    /// </summary>
    public void UnPauseMusic()
    {
        audioSource.UnPause();
    }
}