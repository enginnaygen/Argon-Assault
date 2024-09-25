using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    int score;
    TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = "Start";
    }

    public void IncreaseScore(int IncreaseAmount)
    {
        score += IncreaseAmount;
        scoreText.text = score.ToString("000");
        //Debug.Log(score);
    }
}
