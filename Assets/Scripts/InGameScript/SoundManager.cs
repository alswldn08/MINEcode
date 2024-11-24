using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

    public AudioSource SoundSource;
    public AudioSource EffectSource;

    public Slider BackGroundSoundSlider;
    public Slider EffectSoundSlider;

    public List<AudioClip> SoundPlayList;
    public List<AudioClip> EffectPlayList;

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

    //소리 출력
    public void PlaySound(int Index)
    {
        SoundSource.Play();
    }
    public void PlayEffect(int Index)
    {
        EffectSource.Play();
    }

    //소리 조절
    public void SetVolumSound(float value)
    {
        SoundSource.volume = value;
    }

    public void SetVolumEffect(float value)
    {
        EffectSource.volume = value;
    }
}