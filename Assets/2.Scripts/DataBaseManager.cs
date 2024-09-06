using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DataBaseManager : ScriptableObject
{ 
    public static DataBaseManager Instance;

    [Header("����")]
    public Color ScoreColor;
    public Color BonusColor;
    public float ScorePopInterval = 0.2f;
    public Effect effect;

    [Header("������")]
    public Item baseItem;
    public float itemSpawnPer = 0.2f;
    public float itemBonus = 0.25f;

    [Header("����")]
    public SfxData[] sfxDatasArr;
    public BgmData[] bgmDataArr;
    private Dictionary<Define.SfxType, SfxData> sfxDataDic = new Dictionary<Define.SfxType, SfxData>();
    private Dictionary<Define.BgmType, BgmData> bgmDataDic = new Dictionary<Define.BgmType, BgmData>();
    public void Init()
    {
        Instance = this;
        sfxDataDic = new Dictionary<Define.SfxType, SfxData>();
        bgmDataDic = new Dictionary<Define.BgmType, BgmData>();

        foreach (SfxData sfxData in sfxDatasArr)
        {
            sfxDataDic.Add(sfxData.sfxType, sfxData);
        }

        foreach (BgmData bgmData in bgmDataArr)
        {
            bgmDataDic.Add(bgmData.bgmType, bgmData);
        }
    }

    [Header("�÷��̾�")]
    public float JumpPowerIncrease = 1;
    public float GameOverY = -6f;

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


    public SfxData GetSfxData(Define.SfxType type)
    {
        return this.sfxDataDic[type];
    }
    public BgmData GetBgmData(Define.BgmType type) 
    {
        return this.bgmDataDic[type];
    }
    
    [System.Serializable]

    public class SfxData
    {
        public Define.SfxType sfxType;
        public AudioClip clip;
    }
    [System.Serializable]
    public class BgmData
    {
        public Define.BgmType bgmType;
        public AudioClip clip;
    }


}
