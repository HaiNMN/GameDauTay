using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixerManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider audioSound;
    public Slider audioMusic;

    [SerializeField] float fMusic = -20;
    [SerializeField] float fSound = -20;
    // Start is called before the first frame update
    void Start()
    {
        float music = GetVolumMusic();
        float sound = GetVolumSound();
        audioMusic.value = music;
        audioSound.value = sound;
        

    }

    // Update is called once per frame
    public void UpdateMusic(float value)
    {
        //audioMixer.SetFloat("MusicVolum",value); đây là cách cũ chúng ta phải lấy name rất mất thời gian
        audioMixer.SetFloat(ConstanerGame.KeyMusic, value); // đây là cách mới gọi ConstanerGame.KeyMusic là được
        OnStoreMusic(value);
    }
    public void UpdateSound(float value)
    {
        audioMixer.SetFloat("SoundVolum",value);
        OnStoreSound(value);
    }
    private void OnStoreMusic(float value)
    {
        PlayerPrefs.SetFloat("MusicVolum", value);
    }
    private void OnStoreSound(float value)
    {
        PlayerPrefs.SetFloat("SoundVolum", value);
    }
    
    float GetVolumMusic()
    {
        return PlayerPrefs.GetFloat("MusicVolum", fMusic);
    }
    float GetVolumSound()
    {
        return PlayerPrefs.GetFloat("SoundVolum", fSound);
    }
}
