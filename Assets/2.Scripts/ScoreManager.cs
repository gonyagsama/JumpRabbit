using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
    [SerializeField] private Score baseScore;
    private List<ScoreData> scoreDataList = new List<ScoreData>();

    private int totalScore;
    private float totalBonus;
    public void Init()
    {
        instance = this;
        StartCoroutine(OnScoreCor());
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


    public void AddScore(int score, Vector2 scorePos)
    {
        //애니
        scoreDataList.Add(new ScoreData()
        {
            str = score.ToString(),
            color = DataBaseManager.Instance.ScoreColor,
            pos = scorePos
        });

        //canvas
        totalScore += score;
        scoreTmp.text = totalScore.ToString();
    }

    internal void AddBonus(float bonus, Vector2 position)
    {
        //애니
        scoreDataList.Add(new ScoreData()
        {
            str = "Bonus " + bonus.TopercentString(),
            color = DataBaseManager.Instance.BonusColor,
            pos = position
        });

        //canvas
        totalBonus += bonus;
        bonusTmp.text = totalBonus.TopercentString();
    }

    internal void ResetBonus()
    {
        totalBonus = 0;
        bonusTmp.text = totalBonus.TopercentString();
    }
}
