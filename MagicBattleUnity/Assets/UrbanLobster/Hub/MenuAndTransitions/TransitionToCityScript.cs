using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionToCityScript : SceneTransitionBehavior
{
    public StartActionCityScript StartActionCityScript;
    public StartFinishPointsManager StartFinishPointsManager;
    public Config Config;

    public override void StartTransition(LevelOfDifficulty.Level level)
    {
        var scenarioCitySettings = Config.GetScenarioCitySettings();
        ScenarioCitySettings.CityDifficultyStruct cityDifficultyStruct = scenarioCitySettings.GetSettings(level);
        StartActionCityScript.SetPrepareTime(cityDifficultyStruct.PrepareTime);

        StartFinishPointsManager.GenerateStartGinishPoints(level);
        positionToTeleport = StartFinishPointsManager.GetStartPointPosition();
        rotationToTeleport = StartFinishPointsManager.GetStartPointRotation();

        ControllerTeleport.Teleport(positionToTeleport, rotationToTeleport, StartActionCityScript.StartAction);
        BackgroundMusic.ChangeBackgroundMusic(BackgroundMusic.MusicPlace.City);
    }
}
