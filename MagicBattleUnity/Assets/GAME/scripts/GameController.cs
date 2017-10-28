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

        if(Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            player.GetComponent<PlayerController>().Shoot();
        }
    }
}
