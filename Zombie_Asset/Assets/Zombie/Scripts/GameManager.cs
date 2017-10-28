using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    public GameObject terrain;
    public GameObject player;
    public GameObject zombiePrefab;
    public float spawnSafeDistance;
    public float spawnTime;
    public int maxZombies;
    Vector3 terrainSize;

    float time = 0;
    
    ///private double terrainWidth;
    //private double terrainHeight;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        terrainSize = terrain.GetComponentInChildren<MeshRenderer>().bounds.size;
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if(time > spawnTime)
        {
            time = 0;
            Spawn();
        }
	}

    void Spawn()
    {
        //Vector3 position = new Vector3();
        if (GameObject.FindGameObjectsWithTag("Zombie").Length >= maxZombies) return;
        Vector3 pos = terrain.transform.position;
        do
        {
            pos.x = Random.Range(-terrainSize.x / 2, terrainSize.x / 2);
            pos.z = Random.Range(-terrainSize.z / 2, terrainSize.z / 2);
        } while ((pos - player.transform.position).magnitude < spawnSafeDistance);
        GameObject newZombie = Instantiate(zombiePrefab);
        
        newZombie.transform.position = pos;
    }


}
