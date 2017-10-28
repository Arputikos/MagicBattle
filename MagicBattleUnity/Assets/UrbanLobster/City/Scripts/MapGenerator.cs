using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public Shader GUIShader;

    RenderTexture renderTexture;
    Camera mapCamera;
    Material outMaterial;

    private void Start()
    {
        renderTexture = new RenderTexture(512, 512, 24);

        mapCamera = gameObject.AddComponent<Camera>();
        mapCamera.enabled = true;
        mapCamera.orthographic = true;
        mapCamera.orthographicSize = 200;
        mapCamera.targetTexture = renderTexture;

        if (GUIShader == null)
            throw new System.Exception("GUIShader not selected");
        outMaterial = new Material(GUIShader)
        {
            mainTexture = renderTexture
        };

        outMaterial.renderQueue = -1;
       // mapCamera.enabled = false;

    }

    public Material GetMaterial()
    {
        return outMaterial;
    }
}
