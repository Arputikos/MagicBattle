using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour {
    bool alive = true;
    public float startSpeed;

    float time;
    public float TIME_TO_DESTROY;

    Vector3 vel;
    //public GameObject handR;
	// Use this for initialization
	void Start () {
    }

    // Update is called once per frame
    void Update () {
        if (!alive)
            return;

        if(time > TIME_TO_DESTROY)
        {
            Destroy(this.gameObject);
        }

        time += Time.deltaTime;
        this.transform.position += vel * Time.deltaTime;
    }

    public void Init(Vector3 initVelocity)
    {
        alive = true;
        vel = initVelocity.normalized * startSpeed;
        var sys = this.GetComponentsInChildren<ParticleSystem>(); //.Play();
        foreach (var x in sys)
        {
            x.Play();
        }
        time = 0;
    }

    public bool IsAlive()
    {
        return alive;
    }
    public void Collided()//with enemy
    {
        alive = false;
        Destroy(this.gameObject);
    }
}
