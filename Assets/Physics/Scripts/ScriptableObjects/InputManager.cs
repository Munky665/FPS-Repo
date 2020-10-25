using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "Input", menuName = "Input Manager")]
public class InputManager : ScriptableObject
{
    public KeyCode jump, attack, pause, interact, mouseGrab, sprint, grenade;

    public KeyCode CheckKey(string key)
    {
        switch(key)
        {
            case "Jump":
                return jump;
            case "Pause":
                return pause;
            case "Attack":       
                return attack;
            case "Interact":
                return interact;
            case "MouseGrab":
                return mouseGrab;
            case "Sprint":
                return sprint;
            case "Grenade":
                return grenade;
            default:
                return KeyCode.None;
        }
    }
}
