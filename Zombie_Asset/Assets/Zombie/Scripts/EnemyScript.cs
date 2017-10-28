using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    GameObject player;
    public float speed;

    float eps = 0.1f;

    bool lives = true;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!lives)
            return;

        Vector3 diff = player.transform.position - this.transform.position;
        diff.y = this.transform.position.y;

        if (diff.magnitude >= eps)
        {
            
            this.transform.position += diff.normalized * speed * Time.deltaTime;
            Vector3 face = player.transform.position;
            face.y = this.transform.position.y;
            this.transform.LookAt(face);

            //if(this.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).IsName("attack"))
            if(this.GetComponentInChildren<Animator>().GetInteger("ggg") == 1)
            {
                this.GetComponentInChildren<Animator>().SetInteger("ggg", 0);
                //this.GetComponentInChildren<Animator>().Play("walk", 0, 0.0f);
            }
        }
        else
        {
            this.GetComponentInChildren<Animator>().SetInteger("ggg", 1);
            //at player
            //this.GetComponentInChildren<Animator>().Play("attack", 0, 0.0f);
        }



    }

    private void Die()
    {
        lives = false;
        this.GetComponentInChildren<Animator>().SetInteger("ggg", 2);
    }
}
