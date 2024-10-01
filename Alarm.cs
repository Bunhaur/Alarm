using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    private AudioSource _audioSource;
    private Coroutine _changeVolumeWork;
    private float _speedChange = 0.25f;
    private float _maxVolume = 1f;
    private float _minVolume = 0f;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void OnEnter()
    {
        StopVolumeChange();

        if (_audioSource.isPlaying == false)
            _audioSource.Play();

        _changeVolumeWork = StartCoroutine(ChangeVolume(_maxVolume));
    }

    public void OnExit()
    {
        StopVolumeChange();
        _changeVolumeWork = StartCoroutine(ChangeVolume(_minVolume));
    }

    private void StopVolumeChange()
    {
        if (_changeVolumeWork != null)
            StopCoroutine(_changeVolumeWork);
    }

    private IEnumerator ChangeVolume(float target)
    {
        while (_audioSource.volume != target)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, _speedChange * Time.deltaTime);

            yield return null;
        }

        if (_audioSource.volume == _minVolume)
            _audioSource.Stop();
    }
}
