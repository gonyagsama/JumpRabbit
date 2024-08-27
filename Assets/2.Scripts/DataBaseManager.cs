using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DataBaseManager : ScriptableObject
{ 
    public static DataBaseManager Instance;

    [Header("연출")]
    public Color ScoreColor;
    public Color BonusColor;

    [Header("플레이어")]
    public float JumpPowerIncrease = 1;

    [Header("플랫폼")]
    public Platform[] LargePlatformArr;
    public Platform[] MiddlePlatformArr;
    public Platform[] SmallPlatformArr;
    public PlatformManager.Data[] DataArray;

    public float GapIntervalMin = 1.0f;
    public float GapIntervalMax = 2.0f;
    public float BonusValue = 0.05f;

    [Header("카메라")]
    public float followSpeed = 5;


    public void Init()
    {
        Instance = this;
    }
}
