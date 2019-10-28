using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ControllerInput
{
    
    public static float GetJoystickLeftX() {
        return Input.GetAxis("LeftX");
    }

    public static float GetJoystickLeftY()
    {
        return Input.GetAxis("LeftY");
    }

    public static float GetJoystickRightX()
    {
        return Input.GetAxis("RightX");
    }

    public static float GetJoystickRightY()
    {
        return Input.GetAxis("RightY");
    }

    public static bool GetButtonA() {
        return Input.GetButtonDown("A");
    }

    public static bool GetButtonB()
    {
        return Input.GetButtonDown("B");
    }

    public static bool GetButtonX()
    {
        return Input.GetButtonDown("X");
    }

    public static bool GetButtonY()
    {
        return Input.GetButtonDown("Y");
    }

    public static bool GetButtonRB()
    {
        return Input.GetButtonDown("RB");
    }
}
