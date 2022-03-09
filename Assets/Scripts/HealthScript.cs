using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    enum healthType {Player, Enemy, Object};
    
    [SerializeField]
    healthType hType = healthType.Object;

    public int health = 100;

    public int numberOfParts;

    //[Tooltip("Check this box if this object is just an object (like a crate), not an enemy")]
    //public bool isObject = false;

    public AudioClip death;
    public AudioClip hit;
    private AudioSource aud;

    public Vector3 maxScale;
    public Vector3 minScale;

    public float timeElapsed = 0;
    public float timer = 3;
    private float TimeScale = 0.5f;

    private bool isDying = false;

    //todo randomize starting health
    // regnerate halth for enemies and player
    //for objects, break into smaller pices upon death

    void Start()
    {
        aud = this.gameObject.GetComponent<AudioSource>();
        aud.spatialBlend = 1;
        maxScale = this.transform.localScale;
    }

    void Update()
    {
        if(health <= 0 && !isDying)
        {
            Death();
        }
        if(hType == healthType.Player)
        {
            UIManager.playerHealthText.text = "Health: " + health.ToString();
        }
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
            if(hType == healthType.Enemy)
            {
                aud.PlayOneShot(hit);
            }
        }
            

        
    }

    void Death()
    {
        isDying = true;
        aud.PlayOneShot(death);
        if(hType == healthType.Object)
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
        else if(hType == healthType.Enemy)
        {
            StartCoroutine(GetSmallAndDie());
        }

        else if(hType == healthType.Player)
        {
            Application.LoadLevel(0);
        }
    }

    //IEnumerator Timer()
    //{
    //    float progress = 0;
    //    while(timeElapsed < 3f)
    //    {
    //        transform.localScale = Vector3.Lerp(maxScale, minScale, progress);
    //        progress += Time.deltaTime * TimeScale;
    //        yield return null;
    //    }
    //    if(timeElapsed >= 3f)
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}

    IEnumerator GetSmallAndDie()
    {
        float time = 4;
        float ObjStartSize = this.transform.localScale.y;
        float objectSize = this.transform.localScale.y;

        while(objectSize > 0.1f)
        {
            this.transform.localScale -= Vector3.one * (ObjStartSize / time) * Time.deltaTime;
            yield return new WaitForEndOfFrame();
            objectSize = this.transform.localScale.y;
        }
        Destroy(this.gameObject);
    }
}
