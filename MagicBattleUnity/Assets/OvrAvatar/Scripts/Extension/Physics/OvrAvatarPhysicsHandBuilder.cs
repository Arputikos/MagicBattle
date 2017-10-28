using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvrAvatarPhysicsHandBuilder  {
    public OvrAvatarPhysicsHand Build(
        GameObject ovrAvatarComponent,
        OvrAvatarPhysicsHandTypes.HandType type)
    {
        Debug.Log("AddPhysicsComponent: " + ovrAvatarComponent.name);

        var handGameObject = new GameObject();
        var hand = handGameObject.AddComponent<OvrAvatarPhysicsHand>();

        handGameObject.name = ovrAvatarComponent.name + "_physics";
        handGameObject.transform.SetParent(ovrAvatarComponent.transform);
        handGameObject.transform.localPosition = new Vector3(0, 0, 0);

        BuildComponents(hand, type, ovrAvatarComponent);

        return hand;
    }

    private void BuildComponents(
        OvrAvatarPhysicsHand hand,
        OvrAvatarPhysicsHandTypes.HandType type,
        GameObject ovrAvatarComponent)
    {
        var transformations = CreateHandTransformations(type, ovrAvatarComponent);

        hand.gameObject.transform.localPosition = transformations.handBegin.transform.localPosition;
        hand.gameObject.transform.localRotation = transformations.handBegin.transform.localRotation;

        var handComponents = new HandComponents
        {
            indexComponent = BuildIndexFinger(hand, transformations.indexFingerBegin, transformations.indexFingerEnd),
            thumbComponent = BuildThumb(hand, transformations.thumbFingerBegin, transformations.thumbFingerEnd),
            fistComponent = BuildFist(hand, transformations.handBegin, transformations.grip)
        };

        hand.Initialize(handComponents, transformations);
    }

    private HandBonesTransformations CreateHandTransformations(
        OvrAvatarPhysicsHandTypes.HandType type,
        GameObject ovrAvatarComponent)
    {
        HandBonesTransformations transformations = new HandBonesTransformations();

        if (type == OvrAvatarPhysicsHandTypes.HandType.Left)
        {
            transformations.handBegin = ovrAvatarComponent.transform.Find(OvrAvatarPhysicsHandNames.GetLeftHandBeginName());
            transformations.grip = ovrAvatarComponent.transform.Find(OvrAvatarPhysicsHandNames.GetLeftHandGripName());
            transformations.indexFingerBegin = ovrAvatarComponent.transform.Find(OvrAvatarPhysicsHandNames.GetLeftHandIndexFingerBeginName());
            transformations.indexFingerEnd = ovrAvatarComponent.transform.Find(OvrAvatarPhysicsHandNames.GetLeftHandIndexFingerEndName());
            transformations.thumbFingerBegin = ovrAvatarComponent.transform.Find(OvrAvatarPhysicsHandNames.GetLeftHandThumbFingerBeginName());
            transformations.thumbFingerEnd = ovrAvatarComponent.transform.Find(OvrAvatarPhysicsHandNames.GetLeftHandThumbFingerEndName());
        }
        else if (type == OvrAvatarPhysicsHandTypes.HandType.Right)
        {
            transformations.handBegin = ovrAvatarComponent.transform.Find(OvrAvatarPhysicsHandNames.GetRightHandBeginName());
            transformations.grip = ovrAvatarComponent.transform.Find(OvrAvatarPhysicsHandNames.GetRightHandGripName());
            transformations.indexFingerBegin = ovrAvatarComponent.transform.Find(OvrAvatarPhysicsHandNames.GetRightHandIndexFingerBeginName());
            transformations.indexFingerEnd = ovrAvatarComponent.transform.Find(OvrAvatarPhysicsHandNames.GetRightHandIndexFingerEndName());
            transformations.thumbFingerBegin = ovrAvatarComponent.transform.Find(OvrAvatarPhysicsHandNames.GetRightHandThumbFingerBeginName());
            transformations.thumbFingerEnd = ovrAvatarComponent.transform.Find(OvrAvatarPhysicsHandNames.GetRightHandThumbFingerEndName());
        }

        return transformations;
    }

    private OvrAvatarPhysicsHandComponent BuildIndexFinger(OvrAvatarPhysicsHand hand, 
        Transform indexFingerBegin1, Transform indexFingerEnd1)
    {
        var indexFingerGameObject = new GameObject();
        indexFingerGameObject.transform.SetParent(hand.gameObject.transform);
        indexFingerGameObject.name = hand.gameObject.name + "_index";
        indexFingerGameObject.transform.localPosition = new Vector3(0, 0, 0);
        indexFingerGameObject.transform.localRotation = Quaternion.identity;

        var indexComponent = indexFingerGameObject.AddComponent<OvrAvatarPhysicsHandComponent>();
        var indexFingerCollider = indexFingerGameObject.AddComponent<CapsuleCollider>();

        return indexComponent;
    }

    private OvrAvatarPhysicsHandComponent BuildThumb(OvrAvatarPhysicsHand hand,
        Transform thumbFingerBegin, Transform thumbFingerEnd)
    {
        var newGameObject = new GameObject();
        newGameObject.transform.SetParent(hand.gameObject.transform);
        newGameObject.name = hand.gameObject.name + "_thumb";
        newGameObject.transform.localPosition = new Vector3(0, 0, 0);
        newGameObject.transform.localRotation = Quaternion.identity;

        var thumbComponent = newGameObject.AddComponent<OvrAvatarPhysicsHandComponent>();
        var thumbFingerCollider = newGameObject.AddComponent<CapsuleCollider>();

        return thumbComponent;
    }

    private OvrAvatarPhysicsHandComponent BuildFist(OvrAvatarPhysicsHand hand,
        Transform handBegin, Transform middleFinger)
    {
        var fistGameObject = new GameObject();
        fistGameObject.transform.SetParent(hand.gameObject.transform);
        fistGameObject.name = hand.gameObject.name + "_fist";
        fistGameObject.transform.localPosition = new Vector3(0, 0, 0);
        fistGameObject.transform.localRotation = Quaternion.identity;

        var fistComponent = fistGameObject.AddComponent<OvrAvatarPhysicsHandComponent>();
        var fistCollider = fistGameObject.AddComponent<CapsuleCollider>();

        return fistComponent;
    }
}
