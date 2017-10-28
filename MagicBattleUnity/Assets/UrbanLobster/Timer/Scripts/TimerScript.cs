using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TimerScript : MonoBehaviour
{
    public ShowTimerTextScript ShowTimerTextScript;

    private double timeLeft;

    public void StartTimer(double prepareTime, System.Action afterTimerCountdownAction)
    {
        ShowTimerTextScript.Activate();
        timeLeft = prepareTime;
        StartCoroutine(TimerCountdown(afterTimerCountdownAction));
    }

    IEnumerator TimerCountdown(System.Action afterTimerCountdownAction)
    {
        while (timeLeft > 0)
        {
            ShowTimerTextScript.UpdateTime((int)timeLeft);
            yield return new WaitForSeconds(1.0f);
            timeLeft--;
        }
        ShowTimerTextScript.UpdateTime((int)timeLeft);
        ShowTimerTextScript.Deactivate();
        if (afterTimerCountdownAction != null)
            afterTimerCountdownAction.Invoke();
    }
}
