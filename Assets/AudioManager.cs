using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Tạo biến lưu trữ audio source
    public AudioSource musicAudioSource;
    public AudioSource VfxAudioSource;
    //Tạo biến lưu trữ audio Clip
    public AudioClip musicClip;
    public AudioClip scorClip;
    // Start is called before the first frame update
    void Start()
    {
        musicAudioSource.clip = musicClip;
        musicAudioSource.Play();
    }
    public void PlaySFX(AudioClip sfxClip)
    {
        VfxAudioSource.clip = sfxClip;
        VfxAudioSource.PlayOneShot(sfxClip);
    }

}
