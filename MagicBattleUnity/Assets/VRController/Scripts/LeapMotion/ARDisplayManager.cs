using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * A simple Detector Logic gate.
 * Listens to Pinch Detector for both hands.
 * If both hands are pinching, transition between AR/VR is made.
 * 
 * TODO: Leap Motion Detector Gate API for both hands
 * */
public class ARDisplayManager : MonoBehaviour {
    // AR is rendered on top of this background quad
    public Renderer ARBackground;

    private bool last_enabled;

    private bool left_hand_pinch_on;
    private bool right_hand_pinch_on;

    // Use this for initialization
    void Start()
    {
        if (ARBackground == null)
        {
            Debug.LogError("No ARBackground set");
        }
        last_enabled = false;
        ARBackground.enabled = last_enabled;

        left_hand_pinch_on = false;
        right_hand_pinch_on = false;
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void SwitchAR()
    {
        last_enabled = !last_enabled;
        ARBackground.enabled = last_enabled;

        print("SwitchAR");
    }

    public void ShowAR()
    {
        print("ShowAR");
    }

    public void HideAR()
    {
        print("HideAR");
    }

    public void ActiveLeftPinch()
    {
        left_hand_pinch_on = true;

        SwitchAR();
    }

    public void DeactiveLeftPinch()
    {
        left_hand_pinch_on = false;
    }

    public void ActiveRightPinch()
    {
        right_hand_pinch_on = true;
        SwitchAR();
    }

    public void DeactiveRightPinch()
    {
        right_hand_pinch_on = false;
    }
}
