using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GenerateStartFinishPoints : MonoBehaviour
{
    public List<GameObject> startPoints;
    public List<GameObject> finishPointsEasy;
    public List<GameObject> finishPointsMedium;
    public List<GameObject> finishPointsHard;

    public GameObject startPointPrefab;
    public GameObject finishPointPrefab;

    private int finishPointIndex;

    public void Generate(LevelOfDifficulty.Level level, out GameObject startPoint, out GameObject finishPoint)
    {
        startPoint = Instantiate(startPointPrefab, startPoints[Random.Range(0, startPoints.Count)].transform);
        switch (level)
        {
            case LevelOfDifficulty.Level.Easy:
                finishPointIndex = Random.Range(0, finishPointsEasy.Count);
                finishPoint = Instantiate(finishPointPrefab, finishPointsEasy[finishPointIndex].transform);
                break;
            case LevelOfDifficulty.Level.Medium:
                finishPointIndex = Random.Range(0, finishPointsMedium.Count);
                finishPoint = Instantiate(finishPointPrefab, finishPointsMedium[finishPointIndex].transform);
                break;
            case LevelOfDifficulty.Level.Hard:
                finishPointIndex = Random.Range(0, finishPointsHard.Count);
                finishPoint = Instantiate(finishPointPrefab, finishPointsHard[finishPointIndex].transform);
                break;
            default: throw new System.NotImplementedException();
        }
    }

}
