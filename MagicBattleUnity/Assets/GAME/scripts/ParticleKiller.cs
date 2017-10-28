using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleKiller : MonoBehaviour {

    float time = 0;
    float totalTime = 5.0f;
    float beg = 0;
	// Use this for initialization
	void Start () {
        float beg = this.GetComponentInChildren<Light>().intensity;
        time = 0;
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        this.GetComponentInChildren<Light>().intensity = this.GetComponentInChildren<Light>().intensity * (totalTime-(float)time) / (float)totalTime ;
        ////TODO
        if (time > totalTime)//dont deastroy now
        {
            Destroy(this.gameObject);
        }
            //   // Destroy(this.gameObject);
            //}
            //this.GetComponentInChildren<Light>().intensity = beg * (totalTime - (float)time ) / (float)totalTime;
        }
}
