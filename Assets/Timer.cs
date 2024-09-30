using System;
using UnityEngine;

public class Timer
{
    public Action TimeEnded;

    private float _currentTime;
    private float _timer;

    private float _timeBetween = 1;

    public Timer(float timer, float timeBetween)
    {
        _timer = 0;
        _timeBetween = timeBetween;
        _currentTime = timer;
    }

    public void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > _timeBetween)
        {
            _timer = 0;
            _currentTime -= _timeBetween;

            Debug.Log(_currentTime);

            if (_currentTime < 0)
            {
                TimeEnded?.Invoke();
            }
        }
    }
}
