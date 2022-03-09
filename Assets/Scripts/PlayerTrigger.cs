using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{

    public GunScript gun;

    // Start is called before the first frame update
    void Start()
    {
        if(gun == null)
        {
            Debug.LogError("You forgot to assign the gun here");
            gun = GameObject.Find("Gun").GetComponent<GunScript>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("AmmoPickup"))
        {
            Destroy(other.gameObject);
            gun.GetAmmo();
        }
    }

    //after ontriggerenter?
    //ontriggerstay 
    //do damage every three seconds for each enemy touching 
}
