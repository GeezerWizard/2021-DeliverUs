using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls
{
    // For controlling keys better
    // Remove static for multiple instances of controllers
    public static KeyCode upKey = KeyCode.W;
    public static KeyCode altUpKey = KeyCode.UpArrow;
    public static KeyCode downKey = KeyCode.S;
    public static KeyCode altDownKey = KeyCode.DownArrow;
    public static KeyCode rightKey = KeyCode.D;
    public static KeyCode altRightKey = KeyCode.RightArrow;
    public static KeyCode leftKey = KeyCode.A;
    public static KeyCode altLeftKey = KeyCode.LeftArrow;
    public static KeyCode reverseKey = KeyCode.X;
    public static KeyCode altReverseKey = KeyCode.RightAlt;
    public static KeyCode runKey = KeyCode.LeftShift;
    public static KeyCode altRunKey = KeyCode.RightControl;
    public static KeyCode tootTootKey = KeyCode.F;
    public static KeyCode altTootTootKey = KeyCode.Question;
    public static KeyCode forkUp = KeyCode.Q;
    public static KeyCode forkDown = KeyCode.E;
    public static KeyCode altForkup = KeyCode.Comma;
    public static KeyCode altForkDown = KeyCode.Period;
    // Change and save through player prefs
}
