using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShowTimerTextScript : MonoBehaviour
{
    public abstract void UpdateTime(int timeLeft);
    public abstract void Deactivate();
    public abstract void Activate();
}
