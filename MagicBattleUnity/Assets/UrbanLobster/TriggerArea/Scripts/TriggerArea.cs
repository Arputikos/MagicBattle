using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour {
    public GameObject player;

	// Use this for initialization
	void Start () {
        if (player == null){
            player = FindPlayer();
            if (!player)
                Debug.LogError("Player Controller not found");
        }
    }

	GameObject FindPlayer()
    {
        player = GameObject.Find("VRController");
        if (player)
            return player;

        player = GameObject.Find("FPSController");
        if (player)
            return player;        

        return null;
    }

	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter(Collider collider) {
        
        if(collider.gameObject != player)
            return;

        Debug.Log("Player Trigger!");
    }
}
