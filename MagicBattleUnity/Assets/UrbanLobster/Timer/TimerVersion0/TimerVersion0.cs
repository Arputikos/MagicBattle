using System.Collections;
using System.Collections.Generic;
using System;
using System.Timers;
using UnityEngine;

public class TimerVersion0 : ShowTimerTextScript
{
    public TextMesh timerText;
    public GameObject timerObject;

    public override void UpdateTime(int timeLeft)
    {
        timerText.text = timeLeft.ToString();
    }

    public override void Deactivate()
    {
        timerObject.SetActive(false);
    }

    public override void Activate()
    {
        timerObject.SetActive(true);
    }
}
