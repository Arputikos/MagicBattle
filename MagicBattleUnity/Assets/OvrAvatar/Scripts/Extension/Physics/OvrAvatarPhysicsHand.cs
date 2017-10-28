using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HandInteractionStatus
{
    Triggering, Holding, None
}

public struct HandComponents
{
    public OvrAvatarPhysicsHandComponent indexComponent;
    public OvrAvatarPhysicsHandComponent thumbComponent;
    public OvrAvatarPhysicsHandComponent fistComponent;
}

public struct HandBonesTransformations
{
    public Transform handBegin;
    public Transform grip;
    public Transform indexFingerBegin;
    public Transform indexFingerEnd;
    public Transform thumbFingerBegin;
    public Transform thumbFingerEnd;
}

public struct HandMomentum
{
    public Vector3 LinearVelocity;
    public Vector3 LinearAcceleration;
    public Vector3 AngularVelocity;
    public Vector3 AngularAcceleration;
}

public class OvrAvatarPhysicsHand : MonoBehaviour {
    private HandInteractionStatus status;

    private HandComponents components;

    private HandBonesTransformations transformations;

    private HandMomentum momentum;

    private float timeHolding;
    private GameObject gameObjectInHand;

    private List<GameObject> bannedGameObjects;

    public void Initialize(
        HandComponents handComponents,
        HandBonesTransformations transformations)
    {
        this.transformations = transformations;

        components = handComponents;

        status = HandInteractionStatus.None;

        timeHolding = 0;
        gameObjectInHand = null;

        momentum = new HandMomentum
        {
            LinearVelocity = new Vector3(),
            LinearAcceleration = new Vector3(),
            AngularVelocity = new Vector3(),
            AngularAcceleration = new Vector3()
        };

        bannedGameObjects = new List<GameObject>();

        DeactivateColliders();
    }

    public void UpdateHand()
    {
        UpdateIndexFinger();
        UpdateThumb();
        UpdateFist();

        if(gameObjectInHand != null)
        {
            timeHolding += Time.deltaTime;
            //gameObjectInHand.transform.position = transformations.handBegin.position;
            //gameObjectInHand.transform.rotation = transformations.handBegin.rotation;

            gameObjectInHand.transform.position = transformations.indexFingerBegin.position;
            gameObjectInHand.transform.rotation = transformations.indexFingerBegin.rotation;
            
        }
    }

    private void UpdateIndexFinger()
    {
        var indexBeginPosition = transformations.indexFingerBegin.localPosition;
        var indexEndPosition = transformations.handBegin.InverseTransformPoint(transformations.indexFingerEnd.position);

        var direction = indexEndPosition - indexBeginPosition;
        var directionHalf = (direction / 2);
        var middlePosition = indexBeginPosition + directionHalf;
        const int FINGER_LENGTH_TO_WIDTH_PROPORTION = 5;

        var indexFingerCollider = components.indexComponent.GetCollider();

        indexFingerCollider.direction = 0; // X
        indexFingerCollider.center = middlePosition;
        indexFingerCollider.radius = directionHalf.magnitude / FINGER_LENGTH_TO_WIDTH_PROPORTION;
        indexFingerCollider.height = direction.magnitude;
    }

    private void UpdateThumb()
    {
        var differencePosition = transformations.thumbFingerEnd.localPosition - transformations.thumbFingerBegin.localPosition;

        var differenceHalf = (differencePosition / 2);
        var middlePosition = transformations.thumbFingerBegin.localPosition + differenceHalf;
        const int FINGER_LENGTH_TO_WIDTH_PROPORTION = 4;

        var thumbFingerCollider = components.thumbComponent.GetCollider();

        thumbFingerCollider.direction = 2; // Z
        thumbFingerCollider.center = middlePosition;
        thumbFingerCollider.radius = differenceHalf.magnitude / FINGER_LENGTH_TO_WIDTH_PROPORTION;
        thumbFingerCollider.height = differencePosition.magnitude;
    }

    private void UpdateFist()
    {
        var middleFingerPosition = transformations.grip.localPosition;
        var handBeginPosition = transformations.handBegin.localPosition;

        var direction = (middleFingerPosition);
        var directionHalf = direction / 2.0f;
        var middlePosition = directionHalf;

        var fistCollider = components.fistComponent.GetCollider();

        fistCollider.center = middlePosition;
        fistCollider.radius = directionHalf.magnitude;
        fistCollider.height = directionHalf.magnitude;
    }

    public void ActivateColliders()
    {
        components.indexComponent.GetCollider().isTrigger = false;
        components.thumbComponent.GetCollider().isTrigger = false;
        components.fistComponent.GetCollider().isTrigger = false;

        var fistGameObjectInHand = components.fistComponent.GetGameObjectInHand();

        if(fistGameObjectInHand != null && !IsBanned(fistGameObjectInHand))
        {
            SetGameObjectInHand(fistGameObjectInHand);
            var rigidBody = gameObjectInHand.GetComponent<Rigidbody>();
            if (rigidBody)
            {
                rigidBody.isKinematic = true;
            }

            status = HandInteractionStatus.Holding;
        }
    }

    public void DeactivateColliders()
    {
        bannedGameObjects.Clear();

        components.indexComponent.GetCollider().isTrigger = true;
        components.thumbComponent.GetCollider().isTrigger = true;
        components.fistComponent.GetCollider().isTrigger = true;

        status = HandInteractionStatus.Triggering;
        
        if(gameObjectInHand != null)
        {
            var rigidBody = gameObjectInHand.GetComponent<Rigidbody>();
            if (rigidBody)
            {
                rigidBody.isKinematic = false;
            }

            rigidBody.velocity = momentum.LinearVelocity;
            rigidBody.AddForce(momentum.LinearAcceleration, ForceMode.Force); // mass is added automatically ?

            rigidBody.angularVelocity = momentum.AngularVelocity;
            
            var Q = rigidBody.transform.rotation * rigidBody.inertiaTensorRotation;
            var I = rigidBody.inertiaTensor;
            var angular_acceleration_body = Quaternion.Inverse(Q) * momentum.AngularAcceleration;
            var torque = Q * Vector3.Scale(I, angular_acceleration_body);

            Debug.Log(torque);
            rigidBody.AddTorque(torque);

            SetGameObjectInHand(null);
        }
    }

    private void SetGameObjectInHand(GameObject gameObject)
    {
        timeHolding = 0;
        gameObjectInHand = gameObject;
    }

    private bool IsBanned(GameObject gameObject) {
        return bannedGameObjects.Find(e => e == gameObject);
    }

    public void UpdateMomentum(
        Vector3 LinearVelocity, 
        Vector3 LinearAcceleration, 
        Vector3 AngularVelocity,
        Vector3 AngularAcceleration)
    {
        momentum.LinearVelocity = LinearVelocity;
        momentum.LinearAcceleration = LinearAcceleration;
        momentum.AngularVelocity = AngularVelocity;
        momentum.AngularAcceleration = AngularAcceleration;
    }

    public void AddBannedGameObject(GameObject gameObject)
    {
        bannedGameObjects.Add(gameObject);
    }

    public GameObject GetGameObjectInHand()
    {
        return gameObjectInHand;
    }

    public HandInteractionStatus GetStatus()
    {
        return status;
    }

    public float GetHoldingTime()
    {
        return timeHolding;
    }
}
