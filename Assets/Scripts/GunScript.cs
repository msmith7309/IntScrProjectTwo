using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{

    public Rigidbody bulletPrefab;

    public Transform bulletSpawn; 

    [Header("Bools")]
    public bool canShoot = true;
    public bool debug = false;

    [Header("Ammo Management")]
    public int totalAmmo = 90;
    public int clipSize = 10;
    public int clip = 0;

    public float fireRate = 0.1f;

    [Header("Audio")]
    public AudioClip fire;
    public AudioClip reload;
    public AudioClip getAmmo;
    public AudioClip outOfAmmo;
    public AudioClip noAmmo;


    //private variables

    private AudioSource aud;
    

    //attributes, google it later.
    [Range (10, 100)]
    public float bulletSpeed = 50;

    // Start is called before the first frame update
    void Start()
    {
        aud = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        UIManager.ammoText.text = "Ammo: " + clip + "/" + totalAmmo.ToString();
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
            aud.PlayOneShot(reload);
            totalAmmo -= (clipSize - clip);
            clip = clipSize;
        }
        else{
            clip = totalAmmo + clip;
            totalAmmo = 0;
            aud.PlayOneShot(outOfAmmo);
        }
    }

    public void Fire()
    {
        if(canShoot)
        {
            if(clip > 0)
            {
                aud.PlayOneShot(fire);
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

    public void GetAmmo()
    {
        totalAmmo += 90;
        aud.PlayOneShot(getAmmo);
    }

    IEnumerator CoolDown()
    {
        canShoot = false;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
}
