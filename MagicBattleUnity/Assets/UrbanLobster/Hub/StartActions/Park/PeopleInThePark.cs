using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleInThePark : MonoBehaviour
{
    public EndActionParkScript EndActionParkScript;
    public ParkResultScript ParkResultScript;

    private List<GameObject> activatedPeople;
    // Use this for initialization
    void Start()
    {
        activatedPeople = new List<GameObject>();
    }

    public void AddPerson(GameObject person)
    {
        activatedPeople.Add(person);
        person.GetComponent<ParkClickableItem>().OnClicked += EndActionParkScript.EndAction;
        person.GetComponent<ParkClickableItem>().ClickedItemOk += ParkResultScript.ChoosenPersonOK;
    }

    public void DeactivatePeople()
    {
        foreach (GameObject go in activatedPeople)
            Destroy(go);
    }

    public List<GameObject> GetPeopleInPark()
    {
        return activatedPeople;
    }
    
}
