using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubButtonClickableItem : HubClickableItem {

    public GameObject BackgroundButtonLighting;

    public override void Click(RaycastHit hit)
    {
        Debug.Log("qqqq");
        this.gameObject.GetComponent<SceneTransitionBehavior>().StartTransition(gameObject.GetComponent<LevelOfDifficulty>().LevelDifficulty);
    }

    public override bool HighLightMaterial(float distance)
    {
        BackgroundButtonLighting.SetActive(true);
        BackgroundLighting.SetActive(true);
        return true;
    }

    public override void UnHighLightMaterial()
    {
        BackgroundButtonLighting.SetActive(false);
        BackgroundLighting.SetActive(false);
    }
}
