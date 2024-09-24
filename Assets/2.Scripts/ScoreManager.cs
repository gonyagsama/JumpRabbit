using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private struct ScoreData
    {
        public string str;
        public Color color;
        public Vector2 pos;
    }

    public static ScoreManager instance;
    [SerializeField] private TextMeshProUGUI scoreTmp;
    [SerializeField] private TextMeshProUGUI bonusTmp;
    [SerializeField] private Text highScoreTmp;
    [SerializeField] private Score baseScore;
    private List<ScoreData> scoreDataList = new List<ScoreData>();

    public int totalScore;
    public float totalBonus;
    public int highScore;  // �ְ� ���ھ� ���� �߰�


    public void Init()
    {
        instance = this;

        DontDestroyOnLoad(gameObject);

        // �ְ� ���ھ PlayerPrefs���� �ҷ�����
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    public void Active()
    {
        StartCoroutine(OnScoreCor());

        scoreTmp.text = totalScore.ToString();
        bonusTmp.text = totalBonus.TopercentString();

        // �ְ� ���ھ� UI ������Ʈ
        highScoreTmp.text = highScore.ToString();
    }

    private IEnumerator OnScoreCor()
    {
        while (true)
        {
            if (scoreDataList.Count > 0)
            {
                ScoreData data = scoreDataList[0];

                Score scoreObj = Instantiate<Score>(baseScore);
                scoreObj.transform.position = data.pos;
                scoreObj.Active(data.str, data.color);

                scoreDataList.RemoveAt(0);
                yield return new WaitForSeconds(DataBaseManager.Instance.ScorePopInterval);
            }
            else
            {
                yield return null;
            }
        }
    }

    public void AddScore(int score, Vector2 scorePos, bool isCalcBonus = true)
    {
        // �ִϸ��̼� ó��
        scoreDataList.Add(new ScoreData()
        {
            str = score.ToString(),
            color = DataBaseManager.Instance.ScoreColor,
            pos = scorePos
        });

        // ���� ����
        totalScore += score;
        scoreTmp.text = totalScore.ToString();


   
        // ���ʽ� ���� ���
        if (isCalcBonus)
        {
            int bonusScore = (int)(score * totalBonus);
            if (bonusScore > 0)
            {
                AddScore(bonusScore, scorePos, false);
            }
        }
    }

    internal void AddBonus(float bonus, Vector2 position)
    {
        // �ִϸ��̼� ó��
        scoreDataList.Add(new ScoreData()
        {
            str = "Bonus " + bonus.TopercentString(),
            color = DataBaseManager.Instance.BonusColor,
            pos = position
        });

        // ���ʽ� ����
        totalBonus += bonus;
        bonusTmp.text = totalBonus.TopercentString();
    }

    internal void ResetBonus(Vector2 bonusPos)
    {
        // �ִϸ��̼� ó��
        scoreDataList.Add(new ScoreData()
        {
            str = "���ʽ� �ʱ�ȭ",
            color = DataBaseManager.Instance.BonusColor,
            pos = bonusPos
        });

        totalBonus = 0;
        bonusTmp.text = totalBonus.TopercentString();
    }

    public void CalBestScore()
    {
        //�ְ� ���ھ� ����
        if (totalScore > highScore)
        {
            highScore = totalScore;

            // �ְ� ���ھ PlayerPrefs���� �ҷ�����
            PlayerPrefs.SetInt("HighScore", highScore);

            // �ְ� ���ھ� UI ������Ʈ
            highScoreTmp.text = highScore.ToString();

        }
    }
}
