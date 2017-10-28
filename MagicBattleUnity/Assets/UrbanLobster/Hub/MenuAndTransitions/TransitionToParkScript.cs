using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TransitionToParkScript : SceneTransitionBehavior
{ 
    public StartActionParkScript StartActionParkScript;
    public Transform transormToTeleport;
    public Config Config;

    private ScenarioParkSettings scenarioParkSettings;

    void Start()
    {
        positionToTeleport = transormToTeleport.position;
        rotationToTeleport = transormToTeleport.rotation;
    }

    public override void StartTransition(LevelOfDifficulty.Level level)
    {
        var scenarioParkSettings = Config.GetScenarioParkSettings();
        ScenarioParkSettings.ParkDifficultyStruct parkDifficultyStruct = scenarioParkSettings.GetSettings(level);
        StartActionParkScript.SetPrepareTime(parkDifficultyStruct.PrepareTime);

        ControllerTeleport.Teleport(positionToTeleport, rotationToTeleport, StartActionParkScript.StartAction);
        //TODO A mpark music
        BackgroundMusic.ChangeBackgroundMusic(BackgroundMusic.MusicPlace.Hub);
    }
    
}
