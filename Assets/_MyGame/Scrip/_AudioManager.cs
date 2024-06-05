using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class _AudioManager : MonoBehaviour
{
    private static _AudioManager _instance;
    public static _AudioManager Instance
    {
        get { return _instance; }
        set
        {
            _instance = value;
        }
    }
    public AudioClip[] backGrounds;
    public AudioClip click;
    public AudioClip fireAudio;
    public AudioClip explusion;
    public AudioClip Colect;
    public AudioClip jumAudio;
    public AudioClip Water;
    public AudioClip Dead;
    public AudioClip KillEnemy;
    public AudioClip Skill;

    public AudioSource backgroundMusic;
    public AudioSource soundFx;

    private void Start()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        BackGroundMusic();
    }
    private void Update()
    {
        if(!backgroundMusic.isPlaying)
        {
            backgroundMusic.Play();
        }
    }
    public void PlayBackGroundMusic(AudioClip clip)
    {
        backgroundMusic.clip = clip;
        backgroundMusic.Play();
    }
    public void PlaySoundEffectMusic(AudioClip clip)
    {
        soundFx.PlayOneShot(clip);
    }
    public void BackGroundMusic()
    {
        PlayBackGroundMusic(backGrounds[Random.Range(0, backGrounds.Length)]);
    }

}
