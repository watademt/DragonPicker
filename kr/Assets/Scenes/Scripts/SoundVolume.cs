using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundVolume: MonoBehaviour
{
    public AudioSource audioSource;
    private float volume = 1f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        audioSource.volume = volume;
    }
    public void SetVolume(float vol)
    {
        volume = vol;
        PlayerPrefs.SetFloat("VolumeValue", volume);
        PlayerPrefs.Save();
    }

}
