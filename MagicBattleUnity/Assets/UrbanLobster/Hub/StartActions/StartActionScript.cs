using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;

public abstract class StartActionScript : MonoBehaviour
{
    public StopwatchScript StopwatchScript;
    public TimerScript Timer;

    public abstract void StartAction();

    protected double prepareTime;
    public void SetPrepareTime(double _prepareTime)
    {
        prepareTime = _prepareTime;
    }

    protected void Reset(double prepareTime, Action action)
    {
        Timer.StartTimer(prepareTime, action);
        StopwatchScript.StartStopwatch();
    }
}
