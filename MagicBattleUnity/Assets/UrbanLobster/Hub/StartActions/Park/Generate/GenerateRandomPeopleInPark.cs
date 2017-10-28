using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class GenerateRandomPeopleInPark : GeneratePeopleInPark
{
    public EndActionParkScript EndActionParkScript;

    public List<PersonScript> People;
    public List<Transform> PeoplePositions;
    public int peopleCount;


    private void Start()
    {
        if (peopleCount > People.Count)
            peopleCount = People.Count;
    }

    public override void Generate()
    {
        Debug.Log("People count");
        List<int> personIndex = Enumerable.Range(0, People.Count).ToList();
        //List<int> positionIndex = Enumerable.Range(0, PeoplePositions.Count).ToList();

        int a;
        //int i;
        for (int i = 0; i < peopleCount; i++)
        {
            a = personIndex[Random.Range(0, personIndex.Count)];
            //b = positionIndex[Random.Range(0, positionIndex.Count)];
            //i = i;
            GameObject go;
            if (i == 0)
            {
                go = People[a].CreatePerson(PeoplePositions[i], true);
                ShowPhoto(People[a]);
            }
            else
                go = People[a].CreatePerson(PeoplePositions[i]);
            
            PeopleInThePark.AddPerson(go);
            personIndex.Remove(a);
            //positionIndex.Remove(b);
        }
    }
}
