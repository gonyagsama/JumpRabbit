using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DataBaseManager : ScriptableObject
{ 
    public static DataBaseManager Instance;

    [Header("�÷��̾�")]
    public float JumpPowerIncrease = 1;

    [Header("�÷���")]
    public Platform[] LargePlatformArr;
    public Platform[] MiddlePlatformArr;
    public Platform[] SmallPlatformArr;
    public PlatformManager.Data[] DataArray;

    public float GapIntervalMin = 1.0f;
    public float GapIntervalMax = 2.0f;
    public float BonusValue = 0.05f;

    [Header("ī�޶�")]
    public float followSpeed = 5;


    public void Init()
    {
        Instance = this;
    }
}
