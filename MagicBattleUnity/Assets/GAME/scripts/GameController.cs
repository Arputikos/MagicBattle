using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        HandleInput();

    }

    void HandleInput()
    {
        //A = button0
        //B = 1
        //X = 2
        //Y = 3
        //debug
        //foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
        //{
        //    if (Input.GetKeyDown(kcode))
        //        Debug.Log("KeyCode down: " + kcode);
        //}

       // if (Input.GetKeyDown(KeyCode.JoystickButton10))
       // {
       //     player.GetComponent<PlayerController>().Lighting(false, true);
       // }
       //else if (Input.GetKeyUp(KeyCode.JoystickButton10))
       // {
       //     player.GetComponent<PlayerController>().Lighting(false, false);
       // }
        if (Input.GetAxis("Oculus_GearVR_LThumbstickY") > 0)
        {
            player.GetComponent<PlayerController>().Lighting(true, true);
            //player.GetComponent<PlayerController>().Lighting(true, true);
        }
        else
            player.GetComponent<PlayerController>().Lighting(true, false);

        if (Input.GetAxis("Oculus_GearVR_RThumbstickY") > 0)
        {
            player.GetComponent<PlayerController>().Lighting(false, true);
            //player.GetComponent<PlayerController>().Lighting(true, true);
        }
        else
            player.GetComponent<PlayerController>().Lighting(false, false);

        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            player.GetComponent<PlayerController>().Shoot(0);
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            player.GetComponent<PlayerController>().Shoot(1);
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            player.GetComponent<PlayerController>().Shoot(2);
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton3))
        {
            player.GetComponent<PlayerController>().Shoot(3);
        }
    }
}
