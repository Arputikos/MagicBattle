using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvePlane : MonoBehaviour
{
    public float currentR = 5f;
    public float currentA = 5f;
   // public float currentB = 10f;
    public float currentC = 1f;
    public float currentD = 1f;
    public float currentE = 1f;


    private float prevR;
    private float prevA;
    //private float prevB;
    private float prevC;
    private float prevD;
    private float prevE;
    Vector3[] vertStart;
    void Start()
    {
        prevR = currentR;
        prevA = currentA;
       // prevB = currentB;
        prevC = currentC;
        prevD = currentD;
        prevE = currentE;
        //  prevP = currentP;
        vertStart = (Vector3[])GetComponent<MeshFilter>().mesh.vertices.Clone();
        Generate();
    }

    // Update is called once per frame
    void Update()
    {
        if (prevR != currentR || prevA!=currentA /*|| prevB!=currentB*/
            || prevC != currentC || prevD != currentD || prevE != currentE)
        {
            Generate();
            prevR = currentR;
            prevA = currentA;
          //  prevB = currentB;
            prevC = currentC;
            prevD = currentD;
            prevE = currentE;
        }
    }

    private void Generate()
    {
        Vector3[] verts = (Vector3[])vertStart.Clone();
        if (verts == null)
            Debug.Log("aaa");
        //foreach (Vector3 vert in verts)
        for (int i = 0; i < verts.Length; i++)
        {
            float theta = (verts[i].x + 5) / currentA * Mathf.PI;
            float alpha = (verts[i].z + 5);// / currentB * Mathf.PI;
/*
            float x = currentR * Mathf.Cos(theta) * Mathf.Sin(alpha);
            float y = currentR * Mathf.Sin(theta)* Mathf.Sin(alpha);
            float z = currentR * Mathf.Cos(alpha);
            */

            float x = currentC *currentR * Mathf.Cos(theta);// * Mathf.Sin(alpha);
            float y = currentD * currentR * Mathf.Sin(theta);//* Mathf.Sin(alpha);
            float z = currentE * alpha;// currentR;// * Mathf.Cos(alpha);

            verts[i].x = x;
            verts[i].y = y;
            verts[i].z = z;

        }
        GetComponent<MeshFilter>().mesh.vertices = verts;
        GetComponent<MeshCollider>().sharedMesh = GetComponent<MeshFilter>().mesh;
    }
}
