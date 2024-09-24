using UnityEngine;
using UnityEngine.UI;           // UI 사용을 위해 필요
using UnityEngine.SceneManagement;
using TMPro;  // 씬 전환을 위해 필요

public class GameTimer : MonoBehaviour
{
    public float gameTime = 60f;   // 게임 시간이 60초로 설정
    public TextMeshProUGUI timerText;         // UI에 시간을 표시할 텍스트
    public string nextSceneName;   // 전환할 씬의 이름

    private bool isGameOver = false;

    void Update()
    {
        if (isGameOver)
            return;

        // 게임 시간 감소
        gameTime -= Time.deltaTime;

        // 시간이 0 이하가 되면 게임 종료 처리
        if (gameTime <= 0)
        {
            gameTime = 0;
            EndGame();
        }

        // 시간 UI 업데이트
        UpdateTimerUI();
    }

    void UpdateTimerUI()
    {
        // 남은 시간을 UI 텍스트에 표시 (초 단위로 표시)
        timerText.text = "Time Left: " + Mathf.Ceil(gameTime).ToString();
    }

    void EndGame()
    {
        isGameOver = true;
        timerText.text = "Game Over!";

        // 특정 씬으로 전환 (씬 이름은 Inspector에서 지정)
        SceneManager.LoadScene(nextSceneName);
    }
}