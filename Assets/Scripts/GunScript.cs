using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public bool debug = false;

    public Rigidbody bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        if(debug) Debug.Log("PEW!");
        //Create bullet prefab copy
        Rigidbody bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.transform.Translate(0, 0, 1);
        bullet.AddRelativeForce(Vector3.forward * 20, ForceMode.Impulse);
    }
}
