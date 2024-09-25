using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    int score;

    public void IncreaseScore(int IncreaseAmount)
    {
        score += IncreaseAmount;
        Debug.Log(score);
    }
}
