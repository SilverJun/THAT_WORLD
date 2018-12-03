//	Copyright (c) KimPuppy.
//	http://bakak112.tistory.com/

using UnityEngine;

public class Timer
{
    private float _startTime = 0.0f;
    private float _elapsedTime = 0.0f;
    private float _delay = 0.0f;

    private bool _isLoop = false;
    private bool _isStopped = false;
    private bool _isEnable = false;

    public float NowTime
    {
        get
        {
            if (_isStopped)
                _startTime = Time.time - (_elapsedTime - _startTime);
            _elapsedTime = Time.time;
            return _elapsedTime - _startTime;
        }
    }

    public bool IsLoop
    {
        get
        {
            return _isLoop;
        }

        set
        {
            _isLoop = value;
        }
    }

    public bool IsDone
    {
        get
        {
            if (NowTime > _delay && _isEnable)
            {
                if (_isLoop) _startTime = Time.time;
                return true;
            }
            return false;
        }
    }

    public bool IsStopped
    {
        get
        {
            return _isStopped;
        }

        set
        {
            _isStopped = value;
        }
    }

    public bool IsEnable
    {
        get
        {
            return _isEnable;
        }

        set
        {
            _startTime = Time.time;
            _elapsedTime = Time.time;
            _isEnable = value;
        }
    }

    public float Delay
    {
        get
        {
            return _delay;
        }
    }

    public float StartTime
    {
        get
        {
            return _startTime;
        }

        set
        {
            _startTime = value;
        }
    }

    public float ElapsedTime
    {
        get
        {
            return _elapsedTime;
        }

        set
        {
            _elapsedTime = value;
        }
    }

    public Timer(float delay, bool isLoop)
    {
        _startTime = Time.time;
        _elapsedTime = Time.time;
        _delay = delay;
        _isEnable = false;
        _isLoop = isLoop;
    }
}