using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingScript : MonoBehaviour {
    bool alive = true;
    public float startSpeed;

    float time;
    public float TIME_TO_DESTROY;

    public GameObject explosionPrefab;

    Vector3 vel;
    //public GameObject handR;
	// Use this for initialization
	void Start () {
    }

    // Update is called once per frame
    void Update () {
        if (!alive)
            return;

        if (this.transform.position.y < -4.0f)//TEMP
            Collided();

        if (time > TIME_TO_DESTROY)
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
        GameObject e = Instantiate(explosionPrefab, this.transform.position, this.transform.rotation);
        e.transform.parent = null;
        e.GetComponentInChildren<ParticleSystem>().Play();

        alive = false;
        Destroy(this.gameObject);
    }
}
