using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StopwatchScript : MonoBehaviour
{
    private System.Diagnostics.Stopwatch stopwatch;
    private System.TimeSpan timeSpan;

    public void StartStopwatch()
    {
        stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();
    }

    public void StopStopwatch()
    {
        stopwatch.Stop();
        timeSpan = stopwatch.Elapsed;
    }

    public System.TimeSpan GetTime()
    {
        return timeSpan;
    }
}
