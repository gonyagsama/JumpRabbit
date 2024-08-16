using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [System.Serializable]
    public class Data
    {
        public int GroupCount;
        [SerializeField] public float LargePercent;
        [SerializeField] public float MiddlePercent;
        [SerializeField] public float SmallPercent;

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
    [SerializeField] private Platform[] LargePlatformArr;
    [SerializeField] private Platform[] MiddlePlatformArr;
    [SerializeField] private Platform[] SmallPlatformArr;
    [SerializeField] private Data[] DataArray;
    private int platformNum = 0;
    [SerializeField] private float GapIntervalMin = 1.0f;
    [SerializeField] private float GapIntervalMax = 2.0f;

    Dictionary<int, Platform[]> PlatformArrDic = new Dictionary<int, Platform[]>();
    internal void Active()
    {
        Vector3 pos = spawmPosTrf.position;

        int platformGroupSum = 0;
        foreach(Data data in DataArray)
        {
            platformGroupSum += data.GroupCount;
            Debug.Log($"platformGroupSum: {platformGroupSum} ============= ");

            while(platformNum < platformGroupSum)
            {
                int platformID = data.GetPlatformID();
                pos = ActiveOne(pos, platformID);
                platformNum++;
            }
        }
    }

    private Vector3 ActiveOne(Vector3 pos, int platformID)
    {
        Platform[] platforms = PlatformArrDic[platformID];

        int randID = Random.Range(0, platforms.Length);
        Platform randomPlatform = platforms[randID];

        Platform platform = Instantiate(randomPlatform);
        platform.Active(pos);
        Debug.Log("Platform[{platform},{}]");

        if (platformNum != 0)
            pos = pos + Vector3.right * platform.GetHaIfSizeX();
        platform.Active(pos);
        float gap = Random.Range(GapIntervalMin, GapIntervalMax);
        pos = pos + Vector3.right * (platform.GetHaIfSizeX() + gap);

        return pos;
    }


    internal void Init()
    {
        PlatformArrDic.Add(0, SmallPlatformArr);
        PlatformArrDic.Add(1, MiddlePlatformArr);
        PlatformArrDic.Add(2, LargePlatformArr);
    }

   
}
