using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField] private TextMeshProUGUI scoreTmp;
    [SerializeField] private TextMeshProUGUI bonusTmp;
    [SerializeField] private Score baseScore;

    private int totalScore;
    private float totalBonus;
    public void Init()
    {
        instance = this;
    }

    public void AddScore(int score, Vector2 scorePos)
    {
        Score scoreObject = Instantiate(baseScore);
        scoreObject.transform.position = scorePos;
        scoreObject.Active(score);

        totalScore += score;
        scoreTmp.text = totalScore.ToString();
    }

    internal void AddBonus(float bonus, Vector3 position)
    {
        totalBonus += bonus;
        bonusTmp.text = (totalBonus * 100).ToFormatString() + "%";
    }

    internal void ResetBonus()
    {
        totalBonus = 0;
        bonusTmp.text = (totalBonus * 100).TopercentString();
    }
}
