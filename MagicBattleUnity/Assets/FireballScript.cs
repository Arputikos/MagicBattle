using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour {
    bool alive = false;
    public float startSpeed;
    Vector3 vel;
    //public GameObject handR;
	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame
    void Update () {
        this.transform.position += vel * Time.deltaTime;
	}

    public void Init(Vector3 initVelocity)
    {
        alive = true;
        vel = initVelocity.normalized * startSpeed;
    }

    public void Collided()
    {
        Destroy(this.gameObject);
    }
}
