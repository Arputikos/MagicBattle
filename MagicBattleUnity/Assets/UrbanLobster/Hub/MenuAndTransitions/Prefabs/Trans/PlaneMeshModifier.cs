using UnityEngine;
using System.Collections;

public class PlaneMeshModifier : MonoBehaviour
{
    private int width = 10;
    private int height = 10;

    public Material material;

    private Vector3[] vertices;
    private int[] triangles;

    private int oldWidth;
    private int oldHeight;

    void Start()
    {
        Vector3[] normals = GetComponent<MeshFilter>().mesh.normals;
        Debug.Log(normals.Length);
        for (int i = 0; i < normals.Length; i++)
            Debug.Log(normals[i]);

        oldHeight = height;
        oldWidth = width;
       // Upgrade();
       // Generate();
    }
    void Update()
    {
        if (width < 1)
            width = 1;
        if (height < 1)
            height = 1;
        if (oldWidth != width || oldHeight != height)
        {
            oldWidth = width;
            oldHeight = height;
            Upgrade();
           // curveMenu.Generate();
        }
    }

    public void Upgrade()
    {
        vertices = new Vector3[(width + 1) * (height + 1)];
        triangles = new int[6 * width * height];
        float w = 10 / (float)(width);
        float h = 10 / (float)(height);

        int vertNum = 0;
        for (int j = height; j >= 0; j--)
            for (int i = width; i >= 0; i--)
                vertices[vertNum++] = new Vector3(i * w - 5, 0, j * h - 5);

        int triangNum = 0;
        for (int i = 0; i < width; i++)
            for (int j = 0; j < height; j++)
            {
                triangles[triangNum++] = CountNr(i, j);
                triangles[triangNum++] = CountNr(i, j + 1);
                triangles[triangNum++] = CountNr(i + 1, j + 1);

                triangles[triangNum++] = CountNr(i, j);
                triangles[triangNum++] = CountNr(i + 1, j + 1);
                triangles[triangNum++] = CountNr(i + 1, j);
            }

        Mesh mesh = new Mesh();
        Vector2[] uvs = new Vector2[vertices.Length];
        for (int i = 0; i < uvs.Length; i++)
            uvs[i] = new Vector2(1 - vertices[i].x / 10 - (float)0.5, 1 - vertices[i].z / 10 - (float)0.5);

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;

        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshCollider>().sharedMesh = mesh;
        if (material != null)
            GetComponent<Renderer>().material = material;

        /* CurveMenu cm = GetComponentInParent<CurveMenu>();
         if (cm != null)
             cm.Generate();
         else
             Debug.Log("null cm");*/
    }
    private int CountNr(int i, int j)
    {
        return i + j * (width + 1);
    }
    private void Generate()
    {
        vertices = new Vector3[(width + 1) * (height + 1)];
        triangles = new int[6 * width * height];

        int vertNum = 0;
        for (int j = height; j >= 0; j--)
            for (int i = width; i >= 0; i--)
                vertices[vertNum++] = new Vector3(i - 5, 0, j - 5);

        int triangNum = 0;
        for (int i = 0; i < width; i++)
            for (int j = 0; j < height; j++)
            {
                triangles[triangNum++] = CountNr(i, j);
                triangles[triangNum++] = CountNr(i, j + 1);
                triangles[triangNum++] = CountNr(i + 1, j + 1);

                triangles[triangNum++] = CountNr(i, j);
                triangles[triangNum++] = CountNr(i + 1, j + 1);
                triangles[triangNum++] = CountNr(i + 1, j);
            }

        Mesh mesh = new Mesh();
        Vector2[] uvs = new Vector2[vertices.Length];
        for (int i = 0; i < uvs.Length; i++)
            uvs[i] = new Vector2(1 - vertices[i].x / 10 - (float)0.5, 1 - vertices[i].z / 10 - (float)0.5);

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;

        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshCollider>().sharedMesh = mesh;
        if (material != null)
            GetComponent<Renderer>().material = material;

        // save mesh
         var mf = GetComponent<MeshFilter>();
         if (mf)
         {
             var savePath = "Assets/" + "PlaneMesh" + ".asset";
             Debug.Log("Saved Mesh to:" + savePath);
             //UnityEditor.AssetDatabase.CreateAsset(mf.mesh, savePath);
         }
    }

    public void WidthHeight(int _width, int _height)
    {
        width = _width;
        height = _height;
    }
}
