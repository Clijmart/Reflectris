using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuUI : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField]
    private AudioClip clickSound;

    public void PlayClickSound()
    {
        AudioManager.instance.PlaySound(clickSound, 0.5f);
    }
}
