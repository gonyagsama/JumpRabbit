using UnityEngine;
using UnityEngine.UI;           // UI ����� ���� �ʿ�
using UnityEngine.SceneManagement;
using TMPro;  // �� ��ȯ�� ���� �ʿ�

public class GameTimer : MonoBehaviour
{
    public float gameTime = 60f;   // ���� �ð��� 60�ʷ� ����
    public TextMeshProUGUI timerText;         // UI�� �ð��� ǥ���� �ؽ�Ʈ
    public string nextSceneName;   // ��ȯ�� ���� �̸�

    private bool isGameOver = false;

    void Update()
    {
        if (isGameOver)
            return;

        // ���� �ð� ����
        gameTime -= Time.deltaTime;

        // �ð��� 0 ���ϰ� �Ǹ� ���� ���� ó��
        if (gameTime <= 0)
        {
            gameTime = 0;
            EndGame();
        }

        // �ð� UI ������Ʈ
        UpdateTimerUI();
    }

    void UpdateTimerUI()
    {
        // ���� �ð��� UI �ؽ�Ʈ�� ǥ�� (�� ������ ǥ��)
        timerText.text = "Time Left: " + Mathf.Ceil(gameTime).ToString();
    }

    void EndGame()
    {
        isGameOver = true;
        timerText.text = "Game Over!";

        // Ư�� ������ ��ȯ (�� �̸��� Inspector���� ����)
        SceneManager.LoadScene(nextSceneName);
    }
}