using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public bool debug = false;

    public Rigidbody bulletPrefab;

    public Transform bulletSpawn; 

    public bool canShoot = true;


    //private variables

    public int totalAmmo = 90;

    public int clipSize = 10;
    public int clip = 0;

    public float fireRate = 0.1f;

    //attributes, google it later.
    [Range (10, 100)]
    public float bulletSpeed = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reload()
    {
        if(clip == clipSize)
        {
            if(debug) Debug.Log("Clip is already full.");
            return;
        }

        if(totalAmmo + clip >= clipSize)
        {
            totalAmmo -= (clipSize - clip);
            clip = clipSize;
        }
        else{
            clip = totalAmmo + clip;
            totalAmmo = 0;
        }
    }

    public void Fire()
    {
        if(canShoot)
        {
            if(clip > 0)
            {
                clip -= 1;
                if(debug) Debug.Log("PEW!");
                //Create bullet prefab copy
                Rigidbody bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
                bullet.AddRelativeForce(Vector3.forward * bulletSpeed, ForceMode.Impulse);

                StartCoroutine(CoolDown());
            }
            else if(clip <= 0)
            {
                clip = 0;
                Debug.Log("Out of Ammo :(");
            }
        }
        
    }

    IEnumerator CoolDown()
    {
        canShoot = false;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
}
