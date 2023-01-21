using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUIController : MonoBehaviour
{
    [Header("Stats UI")]
    [SerializeField]
    private TextMeshProUGUI livesText;
    [SerializeField]
    private TextMeshProUGUI scoreText;

    [Header("Objective UI")]
    [SerializeField]
    private TextMeshProUGUI equationText;

    private void Update()
    {
        // Stats
        livesText.text = string.Format("{0} Lives", GameDataManager.instance.Lives());
        scoreText.text = string.Format("{0} Score", GameDataManager.instance.Score());

        // Objective
        equationText.text = ObjectiveManager.instance.CurrentObjective().GetEquation();
    }
}
