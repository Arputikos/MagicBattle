using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    PlayerController player;
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
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!lives)
        {
            dieTimer += Time.deltaTime;
            if(dieTimer > DEAD_VISIBLE)
            {
                Destroy(this.gameObject.transform.parent.gameObject);
            }
            return;
        }

        Vector3 diff = playerHead.transform.position - this.transform.position;
        diff.y = 0;

        if (diff.magnitude >= minDist)
        {
            this.transform.position += diff.normalized * speed * Time.deltaTime;
            Vector3 face = playerHead.transform.position;
            face.y = this.transform.position.y;
            this.transform.LookAt(face);

            //if(this.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).IsName("attack"))
            if(this.GetComponentInChildren<Animator>().GetInteger("ggg") == 1)//attack and should walk
            {
                this.GetComponentInChildren<Animator>().SetInteger("ggg", 0);//attack
                //this.GetComponentInChildren<Animator>().Play("walk", 0, 0.0f);
            }
        }
        else
        {
            this.GetComponentInChildren<Animator>().SetInteger("ggg", 1);//attack
            if(this.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).length == 0.5)//jest w polowie
            {
                PlayerController player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
                player.Damage();
            }
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
        if (!lives)
            return;

        if(other.CompareTag("fireball"))
        {
            if(other.gameObject.GetComponent<FireballScript>().IsAlive())//fireball not used
                Die();
            other.gameObject.GetComponent<FireballScript>().Collided();
        }
    }

    public void TakeDamage()//called by animation frame
    {
        player.Damage();
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Die();
    //}
}
