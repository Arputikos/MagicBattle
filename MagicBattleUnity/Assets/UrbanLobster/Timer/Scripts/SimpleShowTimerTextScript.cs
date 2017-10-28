using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleShowTimerTextScript : ShowTimerTextScript {

	public Text TextWithTimeLeft;

	public override void UpdateTime(int timeLeft){
		TextWithTimeLeft.text = ((int)timeLeft).ToString ();
	}

	public override void Deactivate(){
		TextWithTimeLeft.enabled = false;
	}


    public override void Activate()
    {
        TextWithTimeLeft.enabled = true;
    }

}
