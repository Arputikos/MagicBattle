using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassArrowScript : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        var rotationVector = player.transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(new Vector3(rotationVector.x, rotationVector.y, -rotationVector.y - 90 + rotationVector.z));
    }
}
