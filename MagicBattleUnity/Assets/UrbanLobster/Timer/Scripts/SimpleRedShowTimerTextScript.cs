using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleRedShowTimerTextScript : ShowTimerTextScript {

	public Text TextWithTimeLeft;

	public override void UpdateTime(int timeLeft){

		TextWithTimeLeft.text = ((int)timeLeft).ToString ();
        if (timeLeft <= 3)
            TextWithTimeLeft.color = Color.red;
        else
            TextWithTimeLeft.color = Color.black;
    }

	public override void Deactivate(){
		TextWithTimeLeft.enabled = false;
	}

    public override void Activate()
    {
        TextWithTimeLeft.enabled = true;
    }
}
