using System.Collections;
using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _soundSource;
    [SerializeField] private float _quicknessOfVolume;

    private Coroutine _coroutine;
    private bool _isPlay = true;
    private float _maxVolume = 1f;
    private float _minVolume = 0f;
    private enum Volume
    {
        Up,
        Down
    }

    public void PlaySound(AudioClip clip)
    {
        if (_isPlay)
        {
            _soundSource.clip = clip; 
            _soundSource.volume = _minVolume;
            _soundSource.Play();
            _coroutine = StartCoroutine(RegulateVolume(Volume.Up));
        }
    }

    public void StopSound()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        
        StartCoroutine(RegulateVolume(Volume.Down));
    }


    private IEnumerator RegulateVolume(Volume volume)
    {
        _isPlay = false;
        float currentVolume;

        if (volume == Volume.Up)
        {
            currentVolume = _maxVolume;
            float currentTime = Time.time;
            float totalTime = Time.time + _soundSource.clip.length;

            while (currentTime < totalTime)
            {
                currentTime = Time.time;
                _soundSource.volume = Mathf.MoveTowards(_soundSource.volume, currentVolume, _quicknessOfVolume * Time.deltaTime);
                yield return null;
            }
        }

        else if (volume == Volume.Down)
        {
            currentVolume = _minVolume;

            while (_soundSource.volume > currentVolume)
            {
                _soundSource.volume = Mathf.MoveTowards(_soundSource.volume, currentVolume, _quicknessOfVolume * Time.deltaTime);
                yield return null;
            }
        }

        _isPlay = true;
    }
}
