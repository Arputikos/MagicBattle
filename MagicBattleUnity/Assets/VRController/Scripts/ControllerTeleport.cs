using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public delegate void VoidDelegate();
public class ControllerTeleport : MonoBehaviour
{
    public Camera cameraVR;

    float fadeTime;
    OVRScreenFade fadeEffect;

    void Start()
    {
        fadeEffect = cameraVR.GetComponent<OVRScreenFade>();
        if(fadeEffect == null)
        {
            Debug.Log("asd");
        }
        fadeTime = 0.4f;
    }

    public void Teleport(Vector3 toWhere, Quaternion? rotation, Action voidDelegate)
    {
        Debug.Log("TP");
        StartCoroutine(StartMovement(toWhere, rotation));
        StartCoroutine(FinishMovement(voidDelegate));
    }

    private IEnumerator StartMovement(Vector3 toWhere, Quaternion? rotation)
    {
        fadeEffect.fadeTime = fadeTime;
        fadeEffect.StartFadeOut();
        yield return new WaitForSeconds(fadeTime + 0.1f);
        transform.position = toWhere;
        if (rotation.HasValue)
        {
            transform.rotation = rotation.Value;
        }
    }

    private IEnumerator FinishMovement(Action voidDelegate)
    {
        yield return new WaitForSeconds(fadeTime + 0.1f);
        fadeEffect.fadeTime = fadeTime;
        fadeEffect.StartCoroutine("FadeIn");
        if (voidDelegate != null)
            voidDelegate.Invoke();
    }
}
