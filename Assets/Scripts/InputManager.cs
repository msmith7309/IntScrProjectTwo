using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public GunScript gun;

    public bool debug = true;

    public bool waiting = false;

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
    }

    
    public void Fire(InputAction.CallbackContext context)
    {
        if(debug) Debug.Log("Left Mouse Button was held this frame.");
        //skip curly braces only one line
        if(gun != null)
        {
            StartCoroutine(Wait());
            if(!waiting)
            {
                gun.Fire();
            }
            
        }
    }

    IEnumerator Wait()
    {
        waiting = true;
        yield return new WaitForSeconds(0.1f);
        waiting = false; 
        Debug.Log("Firing is finished running again");
    }
}
