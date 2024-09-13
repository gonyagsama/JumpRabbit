using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePopupManager : MonoBehaviour
{
    public Text currentScoreText;  // 현재 스코어를 표시할 UI 텍스트
    public Text highScoreText;     // 최고 스코어를 표시할 UI 텍스트

    private int currentScore = 0;  // 현재 스코어
    private int highScore = 0;     // 최고 스코어

    void Start()
    {
        // 최고 스코어를 PlayerPrefs에서 불러오기 (저장된 최고 스코어가 있는 경우)
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateHighScoreText();
    }

    // 스코어를 증가시키는 메서드
    public void AddScore(int points)
    {
        currentScore += points;
        UpdateCurrentScoreText();

        // 현재 스코어가 최고 스코어보다 높으면 갱신
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);  // 최고 스코어를 저장
            PlayerPrefs.Save();  // 저장된 데이터 즉시 적용
            UpdateHighScoreText();
        }
    }

    // 현재 스코어 UI 업데이트
    private void UpdateCurrentScoreText()
    {
        currentScoreText.text = "Score: " + currentScore;
    }

    // 최고 스코어 UI 업데이트
    private void UpdateHighScoreText()
    {
        highScoreText.text = "High Score: " + highScore;
    }

    // 스코어 리셋 (게임이 끝나거나 리셋할 때 호출 가능)
    public void ResetScore()
    {
        currentScore = 0;
        UpdateCurrentScoreText();
    }
}
