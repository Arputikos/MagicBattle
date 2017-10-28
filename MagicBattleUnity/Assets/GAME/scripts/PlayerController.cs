using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public GameObject fireballPrefab,iceballPrefab;
    public Transform handL, handR;

    public GameObject lightingL, lightingR;

    public int MAX_LIVES;
    public float MAX_LIGHTING_DIST;
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

        foreach (var x in GameObject.FindGameObjectsWithTag("boltstartr"))
        {
            x.transform.position = handR.transform.position;
        }
        foreach (var x in GameObject.FindGameObjectsWithTag("boltstartl"))
        {
            x.transform.position = handL.transform.position;
        }
        
        foreach (var x in GameObject.FindGameObjectsWithTag("boltendl"))
        {
            x.transform.position = GameObject.FindGameObjectWithTag("target").transform.position;
        }


        if (lightingR.activeSelf)
        {
            RaycastHit hit;
            Ray ray = new Ray();
            ray.direction = handR.transform.forward;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 diff = hit.point - handR.transform.position;
                //if (diff.magnitude <= MAX_LIGHTING_DIST)
                {
                    Debug.Log(hit.collider.gameObject.tag);
                    if (hit.collider.gameObject.transform.parent.CompareTag("Zombie"))
                        hit.collider.gameObject.GetComponent<EnemyScript>().Die();

                    foreach (var x in GameObject.FindGameObjectsWithTag("boltendr"))
                    {
                        x.transform.position = hit.point;
                    }
                }
                //else
                //    Lighting(false, false);//off
            }
        }
        if (lightingL.activeSelf)
        {
            RaycastHit hit;
            Ray ray = new Ray();
            ray.direction = handL.transform.forward;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 diff = hit.point - handL.transform.position;
                //if (diff.magnitude <= MAX_LIGHTING_DIST)
                {
                    Debug.Log(hit.collider.gameObject.tag);
                    if (hit.collider.gameObject.transform.parent.CompareTag("Zombie"))
                        hit.collider.gameObject.GetComponent<EnemyScript>().Die();

                    foreach (var x in GameObject.FindGameObjectsWithTag("boltendl"))
                    {
                        x.transform.position = hit.point;
                    }
                }
                //else
                //    Lighting(true, false);//off
            }
        }
    }

    public void Shoot(int num)
    {
        if (lives <= 0)
            return;

        switch (num)
        {
            case 0:
                GameObject fire = GameObject.Instantiate(fireballPrefab, handR.transform.position, handR.transform.rotation);
                fire.GetComponent<FireballScript>().Init(handR.transform.forward);
                break;
             case 1:
                GameObject ice = GameObject.Instantiate(iceballPrefab, handR.transform.position, handR.transform.rotation);
                ice.GetComponent<IceballScript>().Init(handR.transform.forward);
                break;
            case 2:
                GameObject f = GameObject.Instantiate(fireballPrefab, handL.transform.position, handL.transform.rotation);
                f.GetComponent<FireballScript>().Init(handL.transform.forward);
                break;
            case 3:
                GameObject i = GameObject.Instantiate(iceballPrefab, handL.transform.position, handL.transform.rotation);
                i.GetComponent<IceballScript>().Init(handL.transform.forward);
                break;
            //case 10:
            //    GameObject x = GameObject.Instantiate(lightingPrefab, handR.transform.position, handR.transform.rotation);
            //    x.GetComponent<IceballScript>().Init(handR.transform.forward);
            //    break;
            default:
                break;
        }
        
    }
    public void Lighting(bool left, bool on)
    {
        if (lives <= 0)
            return;

        if (left)
        {
            lightingL.SetActive(on);
        }
        else
        {
            lightingR.SetActive(on);
        }
    }

    public void Damage()
    {
        if (lives <= 0)
            return;

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

        if (lives <= 0)
        {
            Die();
            Lighting(true, false);
            Lighting(false, false);
        }
    }

    public void Die()
    {

    }
}
