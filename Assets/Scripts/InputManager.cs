using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public GunScript gun;

    public bool debug = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var mouse = Mouse.current;
        if(mouse == null) return;

        if(mouse.leftButton.wasPressedThisFrame)
        {
            if(debug) Debug.Log("Left Mouse Button was pressed this frame.");
            //skip curly braces only one line
            if(gun != null)
            {
                gun.Fire();
            }
        }
    }
}
