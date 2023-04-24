using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private AudioSource _audioSource;

    public AudioSource Source => _audioSource;

    private void Awake()
    {
        if (AudioManager.Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _audioSource = GetComponent<AudioSource>();

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetVolume(float value)
    {
        _audioSource.volume = value;
    }

    public void PlaySound(AudioClip clip)
    {
        if (clip != null)
            _audioSource.PlayOneShot(clip);
    }
}
