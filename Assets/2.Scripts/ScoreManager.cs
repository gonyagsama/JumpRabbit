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
    public int highScore;  // 최고 스코어 변수 추가


    public void Init()
    {
        instance = this;

        DontDestroyOnLoad(gameObject);

        // 최고 스코어를 PlayerPrefs에서 불러오기
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    public void Active()
    {
        StartCoroutine(OnScoreCor());

        scoreTmp.text = totalScore.ToString();
        bonusTmp.text = totalBonus.TopercentString();

        // 최고 스코어 UI 업데이트
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
        // 애니메이션 처리
        scoreDataList.Add(new ScoreData()
        {
            str = score.ToString(),
            color = DataBaseManager.Instance.ScoreColor,
            pos = scorePos
        });

        // 점수 갱신
        totalScore += score;
        scoreTmp.text = totalScore.ToString();


   
        // 보너스 점수 계산
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
        // 애니메이션 처리
        scoreDataList.Add(new ScoreData()
        {
            str = "Bonus " + bonus.TopercentString(),
            color = DataBaseManager.Instance.BonusColor,
            pos = position
        });

        // 보너스 갱신
        totalBonus += bonus;
        bonusTmp.text = totalBonus.TopercentString();
    }

    internal void ResetBonus(Vector2 bonusPos)
    {
        // 애니메이션 처리
        scoreDataList.Add(new ScoreData()
        {
            str = "보너스 초기화",
            color = DataBaseManager.Instance.BonusColor,
            pos = bonusPos
        });

        totalBonus = 0;
        bonusTmp.text = totalBonus.TopercentString();
    }

    public void CalBestScore()
    {
        //최고 스코어 갱신
        if (totalScore > highScore)
        {
            highScore = totalScore;

            // 최고 스코어를 PlayerPrefs에서 불러오기
            PlayerPrefs.SetInt("HighScore", highScore);

            // 최고 스코어 UI 업데이트
            highScoreTmp.text = highScore.ToString();

        }
    }
}
