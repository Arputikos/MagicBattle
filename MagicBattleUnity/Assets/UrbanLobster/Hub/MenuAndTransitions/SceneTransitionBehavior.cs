using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class SceneTransitionBehavior : MonoBehaviour
{
    public BackgroundMusic BackgroundMusic;
    public ControllerTeleport ControllerTeleport;

    //TODO A class between SceneTransitionBehavior TransitionTo***Script 
    protected Vector3 positionToTeleport;
    protected Quaternion rotationToTeleport;

    public abstract void StartTransition(LevelOfDifficulty.Level level);
}
