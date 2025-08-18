using System.Collections;
using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AlarmTriggerZone _alarmZone;

    private readonly float _minVolume = 0f;
    private readonly float _maxVolume = 1f;
    private readonly float _volumeStep = 0.1f;
    private readonly float _delay = 2;

    private Coroutine _currentCorutine;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _minVolume;
    }

    private void OnEnable()
    {
        _alarmZone.RogueCame += EnableAlarm;
        _alarmZone.RogueGone += DisableAlarm;
    }

    private void OnDisable()
    {
        _alarmZone.RogueCame -= EnableAlarm;
        _alarmZone.RogueGone -= DisableAlarm;
    }

    private void EnableAlarm()
    {
        if (_currentCorutine != null)
        {
            StopCoroutine(_currentCorutine);
        }

        _audioSource.Play();
        _currentCorutine = StartCoroutine(ChangeVolume(_maxVolume));
    }

    private void DisableAlarm()
    {
        if (_currentCorutine != null)
        {
            StopCoroutine(_currentCorutine);
        }

        _currentCorutine = StartCoroutine(ChangeVolume(_minVolume));
    }

    private IEnumerator ChangeVolume(float targetValue)
    {
        var wait = new WaitForSeconds(_delay);

        while (_audioSource.volume != targetValue)
        {
            yield return wait;

            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetValue, _volumeStep * _delay);
        }

        if (_audioSource.volume == _minVolume)
            _audioSource.Stop();
    }
}
