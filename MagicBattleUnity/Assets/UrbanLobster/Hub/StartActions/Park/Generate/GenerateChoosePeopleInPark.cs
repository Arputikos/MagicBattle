using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ChoosePersonInThePark
{
    public PersonScript personScript;
    public Transform transform;
}

public class GenerateChoosePeopleInPark : GeneratePeopleInPark
{
    public int choosen;
    public ChoosePersonInThePark[] People;

    public override void Generate()
    {
        if (choosen >= People.Length)
            choosen = People.Length - 1;

        for(int i=0; i< People.Length; i++)
        {
            GameObject go;
            var person = People[i];
            go = person.personScript.CreatePerson(person.transform);
            if(i==choosen)
             ShowPhoto(person.personScript);
            PeopleInThePark.AddPerson(go);
        }
    }
}
