using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePopupManager : MonoBehaviour
{
    public Text currentScoreText;  // ���� ���ھ ǥ���� UI �ؽ�Ʈ
    public Text highScoreText;     // �ְ� ���ھ ǥ���� UI �ؽ�Ʈ

    private int currentScore = 0;  // ���� ���ھ�
    private int highScore = 0;     // �ְ� ���ھ�

    void Start()
    {
        // �ְ� ���ھ PlayerPrefs���� �ҷ����� (����� �ְ� ���ھ �ִ� ���)
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateHighScoreText();
    }

    // ���ھ ������Ű�� �޼���
    public void AddScore(int points)
    {
        currentScore += points;
        UpdateCurrentScoreText();

        // ���� ���ھ �ְ� ���ھ�� ������ ����
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);  // �ְ� ���ھ ����
            PlayerPrefs.Save();  // ����� ������ ��� ����
            UpdateHighScoreText();
        }
    }

    // ���� ���ھ� UI ������Ʈ
    private void UpdateCurrentScoreText()
    {
        currentScoreText.text = "Score: " + currentScore;
    }

    // �ְ� ���ھ� UI ������Ʈ
    private void UpdateHighScoreText()
    {
        highScoreText.text = "High Score: " + highScore;
    }

    // ���ھ� ���� (������ �����ų� ������ �� ȣ�� ����)
    public void ResetScore()
    {
        currentScore = 0;
        UpdateCurrentScoreText();
    }
}
