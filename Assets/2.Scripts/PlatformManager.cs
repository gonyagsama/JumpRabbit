using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager Instance;
    [System.Serializable]
    public class Data
    {
        [Tooltip("ÇÃ·§Æû ±×·ì °³¼ö")] public int GroupCount;
        [Tooltip("Å« ÇÃ·§Æû ºñÀ²(0~1.0)"), Range(0, 1f)] [SerializeField] public float LargePercent;
        [Tooltip("Áß°£ ÇÃ·§Æû ºñÀ²(0~1.0)"), Range(0, 1f)] [SerializeField] public float MiddlePercent;
        [Tooltip("ÀÛÀº ÇÃ·§Æû ºñÀ²(0~1.0)"), Range(0, 1f)] [SerializeField] public float SmallPercent;

        public int GetPlatformID()
        {
            float randVal = Random.value;
            int platformID;
            if(randVal <= LargePercent)
            {
                platformID = 2;
            }
            else if (randVal <= LargePercent + MiddlePercent)
            {
                platformID = 1;
            }
            else
            {
                platformID = 0;
            }
            return platformID;
        }
    }

    [SerializeField] private Transform spawmPosTrf;
    private Vector3 spawnPos;
    private int platformNum = 0;
    public int LandingPlatformNum;
    private Data lastData;


    Dictionary<int, Platform[]> PlatformArrDic = new Dictionary<int, Platform[]>();
    internal void Active()
    {
        spawnPos = spawmPosTrf.position;

        int platformGroupSum = 0;
        foreach(Data data in DataBaseManager.Instance.DataArr)
        {
            platformGroupSum += data.GroupCount;
            Debug.Log($"platformGroupSum: {platformGroupSum} ============= ");

            while(platformNum < platformGroupSum)
            {
                int platformID = data.GetPlatformID();
                ActiveOne(platformID);
            }
        }
    }

    public void Update()
    {
        if(platformNum - LandingPlatformNum < DataBaseManager.Instance.remainPlatformCount)
        {
            int lastIndex = DataBaseManager.Instance.DataArr.Length - 1;
            Data lastData = DataBaseManager.Instance.DataArr[lastIndex];

            for(int i = 0; i < lastData.GroupCount; i++)
            {
                int platformID = lastData.GetPlatformID();
                ActiveOne(platformID);
            }
        }
    }

    private void ActiveOne(int platformID)
    {
        platformNum++;
        Platform[] platforms = PlatformArrDic[platformID];

        int randID = Random.Range(0, platforms.Length);
        Platform randomPlatform = platforms[randID];

        Platform platform = Instantiate(randomPlatform);


        if (platformNum > 1)
            spawnPos = spawnPos + Vector3.right * platform.HalfSizeX;

        platform.Active(spawnPos, platformNum);

        float gap = Random.Range(DataBaseManager.Instance.GapIntervalMin, DataBaseManager.Instance.GapIntervalMax);
        spawnPos = spawnPos + Vector3.right * (platform.HalfSizeX + gap);
        return;
    }


    internal void Init()
    {
        Instance = this;

        PlatformArrDic.Add(0, DataBaseManager.Instance.SmallPlatformArr);
        PlatformArrDic.Add(1, DataBaseManager.Instance.MiddlePlatformArr);
        PlatformArrDic.Add(2, DataBaseManager.Instance.LargePlatformArr);
    }

   
}
