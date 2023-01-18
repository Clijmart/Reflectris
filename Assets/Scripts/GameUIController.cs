using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUIController : MonoBehaviour
{
    [SerializeField]
    private GameDataManager GameDataManager;

    [SerializeField]
    private TextMeshProUGUI livesText;

    void Update()
    {
        livesText.text = string.Format("{0} Lives", GameDataManager.Lives());
    }
}
