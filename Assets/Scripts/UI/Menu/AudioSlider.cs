using UnityEngine;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private AudioSource _audioSource;

    private void OnEnable()
    {
        if(_audioSource == null)
            _audioSource = FindObjectOfType<AudioSource>();

        _volumeSlider.value = _audioSource.volume;
    }

    public void SetVolume()
    {
        _audioSource.volume = _volumeSlider.value; 
    }
}