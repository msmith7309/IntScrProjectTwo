using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public int health = 100;

    public int numberOfParts;

    [Tooltip("Check this box if this object is just an object (like a crate), not an enemy")]
    public bool isObject = false;

    public AudioClip death;
    private AudioSource aud;

    //todo randomize starting health
    // regnerate halth for enemies and player
    //for objects, break into smaller pices upon death

    void Start()
    {
        aud = this.gameObject.GetComponent<AudioSource>();
        aud.spatialBlend = 1;
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            //health -= 1;        
            
            
            //let the velocity of the bullet define that

            //Debug.Log("Magnitude: " + other.relativeVelocity.magnitude);
            //health -= (int)(other.relativeVelocity.magnitude * 0.05f);

            //let the bullet define that

            health -= other.gameObject.GetComponent<BulletScript>().damage;

            if(health <= 0)
            {
                Death();
            }
        }
    }

    void Death()
    {
        if(isObject)
        {
            Destroy(this.GetComponent<Collider>());
            //change the number of parts based on the size of the object //DONE!
            //Randomize number of parts for objects
            if(this.gameObject.transform.localScale.x > 1f)
            {
                numberOfParts = Random.Range(12,20);
            }
            else
            {
                numberOfParts = Random.Range(3, 7);
            }

            

            for(int i = 0; i < numberOfParts; i++)
            {
                //have each part inherit bullet velocity
                //have each part be randomly placed inside of the object, instead of centered.
                GameObject part = GameObject.CreatePrimitive(PrimitiveType.Cube);
                //randomize color of part //DONE!
                part.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
                part.transform.localScale = Vector3.one * Random.Range(0.5f, 0.8f);
                part.transform.position = this.transform.position;
                part.transform.Translate(Random.Range(-0.5f, -0.5f), Random.Range(-0.5f, -0.5f), Random.Range(-0.5f, -0.5f));
                Destroy(this.gameObject);
                part.AddComponent<Rigidbody>();
            }
        }
        else
        {
            aud.PlayOneShot(death);
            this.gameObject.AddComponent<Rigidbody>();
            Destroy(this.gameObject, 5);
        }
    }
}
