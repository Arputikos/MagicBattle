using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFinishPointsManager : MonoBehaviour
{
    public GenerateStartFinishPoints GenerateStartFinishPoints;
    public GameObject Quad;
    public MapGenerator MapGenerator;
    public GameObject Exit;

    GameObject startPoint;
    GameObject finishPoint;

    public void GenerateStartGinishPoints(LevelOfDifficulty.Level level)
    {
        GenerateStartFinishPoints.Generate(level, out startPoint, out finishPoint);
    }

    public void ShowMap()
    {
        Quad.SetActive(true);
        Renderer renderer = Quad.GetComponent<Renderer>();
        renderer.material = MapGenerator.GetMaterial();
    }

    public void HideMapShowExit()
    {
        Quad.SetActive(false);
        Destroy(startPoint);
        Exit.transform.position = new Vector3(finishPoint.transform.position.x,
                                                Exit.transform.position.y,
                                                finishPoint.transform.position.z);
        Destroy(finishPoint);
        Exit.SetActive(true);
    }

    public Vector3 GetStartPointPosition()
    {
        return startPoint.transform.position;
    }
    public Quaternion GetStartPointRotation()
    {
        return startPoint.transform.rotation;
    }
}
