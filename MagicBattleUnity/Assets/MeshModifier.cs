using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshModifier : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Vector3[] vert = GetComponent<MeshFilter>().mesh.vertices;
        for (int i = 0; i < vert.Length; i++)
        {
            Debug.Log(i + "vert " + vert[i]);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
