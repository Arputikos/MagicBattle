using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject fireballPrefab;
    public Transform handL, handR;

    GameObject Head;
	// Use this for initialization
	void Start () {
        Head = GameObject.FindGameObjectWithTag("Head");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Shoot()
    {
        GameObject fire = GameObject.Instantiate(fireballPrefab, handR.transform.position, handR.transform.rotation);
        fire.GetComponent<FireballScript>().Init(handR.transform.forward);
    }
}
