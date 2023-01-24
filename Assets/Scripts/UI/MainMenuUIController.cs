using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuUIController : MenuUI
{
    private void Start()
    {
        GameObject.FindGameObjectWithTag("BackgroundAudio").GetComponent<BackgroundAudio>().PlayMusic();
    }
}
