using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mark : MonoBehaviour
{
    private const int Add = 50;
    private const int Remove = -10;
    private int _value;
    private int mark;
    [SerializeField] private Event _onUpdated = new Event();

    public void ResetScore()
    {
        mark = 0;
        _value = 0;
        _onUpdated.Invoke(_value);
    }

    public void AddRemove(bool addRemove)
    {
        _value += addRemove == true ? Add : Remove;
        if (_value < 0)
        {
            _value = 0;
        }
        _onUpdated.Invoke(mark);
    }

    public void SetMark()
    {
        if (_value >= 1000 && _value < 1500)
        {
            mark = 10;
        }
        else if (_value >= 600 && _value < 1000)
        {
            mark = 9;
        }
        else if (_value >= 300 && _value < 600)
        {
            mark = 7;
        }
        else if (_value >= 150 && _value < 300)
        {
            mark = 6;
        }
        else if (_value >= 50 && _value < 150)
        {
            mark = 5;
        }
        else if (_value < 50)
        {
            mark = 4;
        }

        _onUpdated.Invoke(_value);
        _onUpdated.Invoke(mark);
    }
}

[System.Serializable]

public class Event : UnityEvent<int>
{
}
