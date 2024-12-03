using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

    public AudioSource SoundSource;//����� �Ҹ�
    public AudioSource EffectSource;//ȿ���� �Ҹ�

    public Slider BackGroundSoundSlider;//����� �Ҹ� �����̴�
    public Slider EffectSoundSlider;//����Ʈ �Ҹ� �����̴�

    public List<AudioClip> SoundPlayList;//����� ����Ʈ
    public List<AudioClip> EffectPlayList;//ȿ���� ����Ʈ

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(Instance);


        if (BackGroundSoundSlider != null)
        {
            BackGroundSoundSlider.onValueChanged.AddListener(SetVolumSound);
            BackGroundSoundSlider.value = 1;
        }
        if (EffectSoundSlider != null)
        {
            EffectSoundSlider.onValueChanged.AddListener(SetVolumEffect);
            EffectSoundSlider.value = 1;
        }

    }

    //�Ҹ� ���
    public void PlaySound(int Index)
    {
        if (SoundPlayList != null)
        {
            SoundSource.clip = SoundPlayList[Index];
            SoundSource.Play();
        }
    }
    public void PlayEffect(int Index)
    {
        if (EffectPlayList != null)
        {
            EffectSource.clip = EffectPlayList[Index];
            EffectSource.Play();
        }
    }

    //�Ҹ� ����
    public void SetVolumSound(float value)
    {
        SoundSource.volume = value;
    }

    public void SetVolumEffect(float value)
    {
        EffectSource.volume = value;
    }
}
