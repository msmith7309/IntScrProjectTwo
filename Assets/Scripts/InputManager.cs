using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public GunScript gun;

    public bool debug = true;

    public AudioListener listener;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var mouse = Mouse.current;
        if(mouse == null) return;

        var keyboard = Keyboard.current;
        if(keyboard == null) return;

        if(keyboard.rKey.wasPressedThisFrame)
        {
            if(gun != null)
            {
                if(gun.clip != gun.clipSize)
                {
                    gun.Reload();
                }
                
            }
        }

        if(mouse.leftButton.isPressed)
        {
            if(debug) Debug.Log("Left Mouse Button was held this frame.");
            //skip curly braces only one line
            if(gun != null)
            {
                gun.Fire();

            }
        }
        //restart game
        if(keyboard.digit7Key.wasPressedThisFrame)
        {
            Application.LoadLevel(0);
        }
        //pause game
        if(keyboard.digit8Key.wasPressedThisFrame)
        {
            if(Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
        //quit game
        if(keyboard.digit9Key.wasPressedThisFrame)
        {
            Application.Quit(0);
        }
        //mute game, needs AudioListener variable from player camera.
        if(keyboard.digit9Key.wasPressedThisFrame)
        {
            if(AudioListener.volume == 1)
            {
                AudioListener.volume = 0;
            }
            else
            {
                AudioListener.volume = 1;
            }
        }
        if(keyboard.leftCtrlKey.isPressed)
        {
            if(keyboard.qKey.wasPressedThisFrame)
            {
                Application.Quit();
            }
        }
    }
}
