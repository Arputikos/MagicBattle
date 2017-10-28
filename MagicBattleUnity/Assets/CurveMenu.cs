using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveMenu : MonoBehaviour
{
    public float currentR = 5f;
    public float currentA = 10f; // Pi
    public float currentB = 5f;
    public float currentX = 1f;
    public float currentY = 1f;
    public float currentZ = 1f;

    public int width;
    public int height;

    private float prevR;
    private float prevA;
    private float prevB;
    private float prevX;
    private float prevY;
    private float prevZ;

    private List<Transform> transfStarts;
    private List<Vector3[]> vertStarts;
    //private Vector3[] vertStart;
    Vector3 mainPosition;

    void Start()
    {
        mainPosition = transform.position;

        prevR = currentR;
        prevA = currentA;
        prevB = currentB;
        prevX = currentX;
        prevY = currentY;
        prevZ = currentZ;

        Generate();
       // ReDraw();

        var cos = vertStarts[0];
    }

    void Update()
    {
        if (prevR != currentR || prevA != currentA || prevB != currentB
           || prevX != currentX || prevY != currentY || prevZ != currentZ)
        {
            ReDraw();
            prevR = currentR;
            prevA = currentA;
            prevB = currentB;
            prevX = currentX;
            prevY = currentY;
            prevZ = currentZ;
        }
    }

    public void ReDraw()
    {
        for (int j = 0; j < vertStarts.Count; j++)
        {
            Vector3[] verts = (Vector3[])vertStarts[j].Clone();
            if (verts == null)
                Debug.Log("vert null aaa");

            Vector3 currentPosition = transfStarts[j].transform.position;
            currentPosition -= mainPosition;

            float Rad = transfStarts[j].localScale.x;

            Vector3[] normals = transfStarts[j].GetComponent<MeshFilter>().mesh.normals;
            Debug.Log(normals.Length);
            for (int i = 0; i < normals.Length; i++)
                Debug.Log(normals[i]);

            for (int i = 0; i < verts.Length; i++)
            {
                float scale = transfStarts[j].localScale.x;

                float theta = ((verts[i].x * scale + currentPosition.x + currentB) / currentA) * Mathf.PI;

                theta += (2 * Mathf.PI - 10 / (currentA) * Mathf.PI) / 2;
                theta += Mathf.PI / 2;
                float alpha = verts[i].z;

                //??
                float x = currentX * (currentR - currentPosition.z) * Mathf.Cos(theta) - currentPosition.x;
                float y = currentY * (currentR - currentPosition.z) * Mathf.Sin(theta);
                float z = currentZ * alpha;

                verts[i].x = x / Rad;// + mainPosition.x;
                verts[i].y = y / Rad;// + mainPosition.y;
                verts[i].z = z;// + mainPosition.z;
            }
            transfStarts[j].GetComponent<MeshFilter>().mesh.vertices = verts;
            transfStarts[j].GetComponent<MeshCollider>().sharedMesh = transfStarts[j].GetComponent<MeshFilter>().mesh;
        }
    }

    int childNmber;
    private void Generate()
    {
        childNmber = 0;
        transfStarts = new List<Transform>();
        vertStarts = new List<Vector3[]>();
        GenerateRec(gameObject.transform);
        ReDraw();
    }
    private void GenerateRec(Transform child)
    {
        if (childNmber++ > 100)
        {
            Debug.Log("aj");
            return;
        }

        foreach (Transform grandchildchild in child.transform)
            GenerateRec(grandchildchild);

        if ((child.GetComponent<MeshFilter>() != null) && (child.GetComponent<PlaneMeshModifier>()!=null))
        {
            child.GetComponent<PlaneMeshModifier>().WidthHeight(width, height);
            child.GetComponent<PlaneMeshModifier>().Upgrade();
           // Debug.Log("lala");
            transfStarts.Add(child);
            vertStarts.Add((Vector3[])child.GetComponent<MeshFilter>().mesh.vertices.Clone());
            ///Debug.Log(child.GetComponent<MeshFilter>().mesh.vertices.Length);
        }
    }


}
