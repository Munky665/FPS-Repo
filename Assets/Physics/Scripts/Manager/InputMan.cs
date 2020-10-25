using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMan : MonoBehaviour
{
    public InputManager InputManager;
    public static InputMan instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }
    //check if key is down
    public bool CheckKeyDown(string key)
    {
        if (Input.GetKeyDown(InputManager.CheckKey(key)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //check if key triggered
    public bool CheckKey(string key)
    {
        if (Input.GetKey(InputManager.CheckKey(key)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //check if key is up
    public bool CheckKeyUp(string key)
    {
        if (Input.GetKeyUp(InputManager.CheckKey(key)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
