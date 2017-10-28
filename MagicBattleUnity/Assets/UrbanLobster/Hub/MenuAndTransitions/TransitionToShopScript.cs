 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TransitionToShopScript : SceneTransitionBehavior
{ 
    public StartActionShopScript StartActionShopScript;
    public Transform transormToTeleport;
    public Config Config;

    void Start()
    {
        positionToTeleport = transormToTeleport.position;
        rotationToTeleport = transormToTeleport.rotation;
    }

    public override void StartTransition(LevelOfDifficulty.Level level)
    {
        var scenarioShopSettings = Config.GetScenarioShopSettings();
        ScenarioShopSettings.ShopDifficultyStruct shopDifficultyStruct = scenarioShopSettings.GetSettings(level);
        StartActionShopScript.SetProductCount(shopDifficultyStruct.ProductCount);
        StartActionShopScript.SetPrepareTime(shopDifficultyStruct.PrepareTime);

        ControllerTeleport.Teleport(positionToTeleport, rotationToTeleport, StartActionShopScript.StartAction);
        BackgroundMusic.ChangeBackgroundMusic(BackgroundMusic.MusicPlace.Shop);
    }

}
