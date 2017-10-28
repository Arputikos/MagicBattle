using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaSineAnimation : MonoBehaviour
{
    public float min;
    public float max;

    public float speed = 1.0f;

    public Renderer Renderer;
    public Renderer Renderer1;

    Material targetMaterial;
    Material targetMaterial1;

    Color start;
    Color end;

    // Use this for initialization
    void Start()
    {
        //TODO A change materials in child
        targetMaterial = Renderer.material;
        targetMaterial1 = Renderer1.material;

        //Debug.Log(targetMaterial.color);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateColors();

        float alpha = Mathf.Sin(Time.fixedTime * speed);
        alpha = (alpha + 1) / 2.0f;

        targetMaterial.color = Color.Lerp(start, end, alpha);
        targetMaterial1.color = targetMaterial.color;
    }

    void UpdateColors()
    {
        start = new Color(targetMaterial.color.r, targetMaterial.color.g, targetMaterial.color.b, min);
        end = new Color(targetMaterial.color.r, targetMaterial.color.g, targetMaterial.color.b, max);
    }
}
