using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private AudioSource bgmAudioSource;
    [SerializeField] private AudioSource sfxAudioSource;

    public void Init()
    {
        Instance = this;
    }

    public void PlayBgm()
    {

    }

    public void PlaySfx(Define.SfxType sfxType)
    {
        DataBaseManager.SfxData sfxData = DataBaseManager.Instance.GetSfxData(sfxType);
        sfxAudioSource.PlayOneShot(sfxData.clip);
    }

    public void PlayBgm(Define.BgmType bgmType)
    {
        DataBaseManager.BgmData bgmData = DataBaseManager.Instance.GetBgmData(bgmType);
        bgmAudioSource.clip = bgmData.clip;
        bgmAudioSource.Play();
    }
}
