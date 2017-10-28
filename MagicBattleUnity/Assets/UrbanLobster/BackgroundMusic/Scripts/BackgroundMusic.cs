using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BackgroundMusic : MonoBehaviour
{
    public enum MusicPlace { Hub, Shop, City };

    public AudioSource HubAudioSource;
    public AudioSource ShopAudioSource;
    public AudioSource CityAudioSource;

    private AudioSource CurrentAudioSource;

    void Start()
    { 
        CurrentAudioSource = HubAudioSource;
        CurrentAudioSource.Play();
    }

    public void ChangeBackgroundMusic(MusicPlace musicPlace)
    {
        CurrentAudioSource.Stop();
        switch (musicPlace)
        {
            case MusicPlace.City:
                CurrentAudioSource = CityAudioSource;
                break;
            case MusicPlace.Shop:
                CurrentAudioSource = ShopAudioSource;
                break;
            default:
                CurrentAudioSource = HubAudioSource;
                break;
        }
        CurrentAudioSource.Play();
    }
}
