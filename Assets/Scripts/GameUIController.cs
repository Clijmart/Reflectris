using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUIController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI livesText;
    [SerializeField]
    private TextMeshProUGUI scoreText;

    void Update()
    {
        livesText.text = string.Format("{0} Lives", GameDataManager.instance.Lives());
        scoreText.text = string.Format("{0} Score", GameDataManager.instance.Score());
    }
}
