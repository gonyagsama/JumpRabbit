using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndingScore : MonoBehaviour
{

    [SerializeField] private Text highScoreTmp;
    [SerializeField] private TextMeshProUGUI scoreTmp;

    void Start()
    {
        highScoreTmp.text = ScoreManager.instance.highScore.ToString();
        scoreTmp.text = ScoreManager.instance.totalScore.ToString();
    }

    void Update()
    {
        
    }
}
