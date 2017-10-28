using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    GameObject playerHead;
    public float speed;

    public float minDist = 0.1f;
    public float DEAD_VISIBLE = 3.0f;

    bool lives = true;

    float dieTimer = 0;

    // Use this for initialization
    void Start ()
    {
        playerHead = GameObject.FindGameObjectWithTag("Head");
    }

    // Update is called once per frame
    void Update()
    {
        if (!lives)
        {
            dieTimer += Time.deltaTime;
            if(dieTimer > DEAD_VISIBLE)
            {
                Destroy(this.gameObject);
            }
            return;
        }

        Vector3 diff = playerHead.transform.position - this.transform.position;
        diff.y = this.transform.position.y;

        if (diff.magnitude >= minDist)
        {
            
            this.transform.position += diff.normalized * speed * Time.deltaTime;
            Vector3 face = playerHead.transform.position;
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
        if (!lives)
            return;

        lives = false;
        dieTimer = 0;
        this.GetComponentInChildren<Animator>().SetInteger("ggg", 2);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("fireball"))
        {
            other.gameObject.GetComponent<FireballScript>().Collided();
            Die();
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Die();
    //}
}
