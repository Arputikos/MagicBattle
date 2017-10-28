using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvrAvatarPhysicsHandComponent : MonoBehaviour {

    private GameObject gameObjectInHand;

    // Use this for initialization
    void Start () {
        gameObjectInHand = null;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        gameObjectInHand = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        gameObjectInHand = null;
    }

    public GameObject GetGameObjectInHand()
    {
        return gameObjectInHand;
    }

    public CapsuleCollider GetCollider()
    {
        return GetComponent<CapsuleCollider>();
    }
}
