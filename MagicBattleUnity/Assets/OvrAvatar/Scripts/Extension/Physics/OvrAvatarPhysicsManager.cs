using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvrAvatarPhysicsManager {
    OvrAvatarPhysicsHand leftHand;
    OvrAvatarPhysicsHand rightHand;

    public OvrAvatarPhysicsManager() {
        leftHand = null;
        rightHand = null;
    }

    public void AddPhysicsComponent(GameObject ovrAvatarComponent,
        OvrAvatarPhysicsHandTypes.HandType type)
    {
        var builder = new OvrAvatarPhysicsHandBuilder();
        var hand = builder.Build(ovrAvatarComponent, type);
        
        if(type == OvrAvatarPhysicsHandTypes.HandType.Left)
        {
            leftHand = hand;
        }else if(type == OvrAvatarPhysicsHandTypes.HandType.Right)
        {
            rightHand = hand;
        }
    }

    public void Update()
    {
        if (leftHand == null || rightHand == null)
            return;

        UpdateHands();
        UpdateMomentums();
        UpdateTriggers();
        UpdateFixHoldingOneObject();
    }

    private void UpdateHands()
    {
        leftHand.UpdateHand();
        rightHand.UpdateHand();
    }

    private void UpdateMomentums()
    {
        leftHand.UpdateMomentum(
            OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch),
            OVRInput.GetLocalControllerAcceleration(OVRInput.Controller.LTouch),
            OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.LTouch),
            OVRInput.GetLocalControllerAngularAcceleration(OVRInput.Controller.LTouch));
        rightHand.UpdateMomentum(
            OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch),
            OVRInput.GetLocalControllerAcceleration(OVRInput.Controller.RTouch),
            OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.RTouch),
            OVRInput.GetLocalControllerAngularAcceleration(OVRInput.Controller.RTouch));
    }

    private void UpdateTriggers()
    {
        UpdateTrigger(leftHand, OVRInput.Axis1D.PrimaryHandTrigger);
        UpdateTrigger(rightHand, OVRInput.Axis1D.SecondaryHandTrigger);
    }

    private bool UpdateTrigger(OvrAvatarPhysicsHand hand, OVRInput.Axis1D input)
    {
        var hand_trigger = OVRInput.Get(input);
        if (hand_trigger > 0)
        {
            hand.ActivateColliders();
            return true;
        }
        else
        {
            hand.DeactivateColliders();
            return false;
        }
    }

    private void UpdateFixHoldingOneObject()
    {
        if (leftHand.GetGameObjectInHand() != null &&
            leftHand.GetGameObjectInHand() == rightHand.GetGameObjectInHand())
        {
            var holdingGameObject = leftHand.GetGameObjectInHand();
            var leftTimeHolding = leftHand.GetHoldingTime();
            var rightTimeHolding = rightHand.GetHoldingTime();

            if (leftTimeHolding < rightTimeHolding)
            {
                rightHand.DeactivateColliders();
                rightHand.AddBannedGameObject(holdingGameObject);
            }
            else
            {
                leftHand.DeactivateColliders();
                leftHand.AddBannedGameObject(holdingGameObject);
            }
        }

    }
}
