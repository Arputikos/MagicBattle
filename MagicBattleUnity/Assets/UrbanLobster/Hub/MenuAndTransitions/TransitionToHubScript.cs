using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TransitionToHubScript : SceneTransitionBehavior
{
    public Transform transormToTeleport;

    void Start()
    {
        positionToTeleport = transormToTeleport.position;
        rotationToTeleport = transormToTeleport.rotation;
    }

    public override void StartTransition(LevelOfDifficulty.Level level = LevelOfDifficulty.Level.Medium)
    {
        ControllerTeleport.Teleport(positionToTeleport, rotationToTeleport, null);
        BackgroundMusic.ChangeBackgroundMusic(BackgroundMusic.MusicPlace.Hub);
    }
}
