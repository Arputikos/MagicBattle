using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvrAvatarPhysicsHandNames : MonoBehaviour {
    public const string HAND_LEFT_NAME = "hand_left";
    public const string HAND_RIGHT_NAME = "hand_right";

    public static string GetLeftHandBeginName()
    {
        return "hand_left_renderPart_0/hands:l_hand_world/hands:b_l_hand";
    }

    public static string GetLeftHandGripName()
    {
        return "hand_left_renderPart_0/hands:l_hand_world/hands:b_l_hand/hands:b_l_grip";
    }

    public static string GetLeftHandMiddleName()
    {
        return "hand_left_renderPart_0/hands:l_hand_world/hands:b_l_hand/hands:b_l_middle1";
    }

    public static string GetLeftHandIndexFingerBeginName()
    {
        return "hand_left_renderPart_0/hands:l_hand_world/hands:b_l_hand/hands:b_l_index1";
    }

    public static string GetLeftHandIndexFingerEndName()
    {
        return "hand_left_renderPart_0/hands:l_hand_world/hands:b_l_hand/hands:b_l_index1/hands:b_l_index2/hands:b_l_index3";
    }

    public static string GetLeftHandThumbFingerBeginName()
    {
        return "hand_left_renderPart_0/hands:l_hand_world/hands:b_l_hand/hands:b_l_thumb1";
    }

    public static string GetLeftHandThumbFingerEndName()
    {
        return "hand_left_renderPart_0/hands:l_hand_world/hands:b_l_hand/hands:b_l_thumb1/hands:b_l_thumb2/hands:b_l_thumb3";
    }

    public static string GetRightHandBeginName()
    {
        return "hand_right_renderPart_0/hands:r_hand_world/hands:b_r_hand";
    }

    public static string GetRightHandGripName()
    {
        return "hand_right_renderPart_0/hands:r_hand_world/hands:b_r_hand/hands:b_r_grip";
    }

    public static string GetRightHandMiddleName()
    {
        return "hand_right_renderPart_0/hands:r_hand_world/hands:b_r_hand/hands:b_r_middle1";
    }

    public static string GetRightHandIndexFingerBeginName()
    {
        return "hand_right_renderPart_0/hands:r_hand_world/hands:b_r_hand/hands:b_r_index1";
    }

    public static string GetRightHandIndexFingerEndName()
    {
        return "hand_right_renderPart_0/hands:r_hand_world/hands:b_r_hand/hands:b_r_index1/hands:b_r_index2/hands:b_r_index3";
    }

    public static string GetRightHandThumbFingerBeginName()
    {
        return "hand_right_renderPart_0/hands:r_hand_world/hands:b_r_hand/hands:b_r_thumb1";
    }

    public static string GetRightHandThumbFingerEndName()
    {
        return "hand_right_renderPart_0/hands:r_hand_world/hands:b_r_hand/hands:b_r_thumb1/hands:b_r_thumb2/hands:b_r_thumb3";
    }
}
