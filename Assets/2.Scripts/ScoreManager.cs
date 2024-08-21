using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField] private TextMeshProUGUI scoreTmp;

    private int totalScore;
    public void Init()
    {
        instance = this;
    }

    public void AddScore(int score)
    {
        totalScore += score;
        scoreTmp.text = totalScore.ToString();
    }
}
