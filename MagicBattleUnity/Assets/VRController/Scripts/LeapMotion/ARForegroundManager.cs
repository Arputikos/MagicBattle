using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;

public class ARForegroundManager : MonoBehaviour {
    public Renderer ARBackground;

    public List<GameObject> ForegroundObjects;

    public CapsuleHand HandLeft;
    public CapsuleHand HandRight;

    public int ForegroundRenderQueue = 3001;
    public int BackgroundRenderQueue = 3000;

    // Use this for initialization
    void Start () {
        //SetForeground();
        //SetBackground();
    }
	
	// Update is called once per frame
	void Update () {
        //SetForeground();
    }

    /**
     * TODO: Find better solution to set renderQueue
     * */
    private void SetForeground()
    {
        foreach (var game_object in ForegroundObjects)
        {
            var mesh_renderer = game_object.GetComponent<MeshRenderer>();
            if (mesh_renderer == null)
                continue;
            foreach (var material in mesh_renderer.materials)
            {
                material.renderQueue = ForegroundRenderQueue;
            }
        }

        if (HandLeft != null)
        {
            ///HandLeft.Material.renderQueue = Foreground;
            HandLeft.SphereMaterial.renderQueue = ForegroundRenderQueue;
        }
        if (HandRight != null)
        {
            //HandRight.Material.renderQueue = Foreground;
            HandRight.SphereMaterial.renderQueue = ForegroundRenderQueue;
        }
    }

    private void SetBackground()
    {
        ARBackground.material.renderQueue = BackgroundRenderQueue;
    }
}
