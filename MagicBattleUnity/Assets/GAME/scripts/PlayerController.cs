using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public GameObject fireballPrefab;
    public Transform handL, handR;

    public int MAX_LIVES;
    int lives;
    public GameObject HUD,bloodSplatter;
    float bloodSplatterAlpha = 0;

    GameObject Head;
	// Use this for initialization
	void Start () {
        Head = GameObject.FindGameObjectWithTag("Head");
        lives = MAX_LIVES;
    }
	
	// Update is called once per frame
	void Update () {
        if (lives <= 0)
            return;


    }

    public void Shoot()
    {
        if (lives <= 0)
            return;

        GameObject fire = GameObject.Instantiate(fireballPrefab, handR.transform.position, handR.transform.rotation);
        fire.GetComponent<FireballScript>().Init(handR.transform.forward);
    }

    public void Damage()
    {
        lives--;
        
        if (lives < 0)
            lives = 0;
        Debug.Log("lives:" + lives.ToString());

        Debug.Log(lives);
        bloodSplatterAlpha = 1.0f - (float)((double)lives / (double)MAX_LIVES);
        Color color = new Color(1, 1, 1, bloodSplatterAlpha);// bloodSplatter.GetComponent<Image>().color;
        //color.a = bloodSplatterAlpha;
        Debug.Log(color);
        bloodSplatter.GetComponent<Image>().color = color;
        
        if(lives <= 0)
            Die();
    }

    public void Die()
    {

    }
}
