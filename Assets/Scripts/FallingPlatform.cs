//to do 
//reset platform after 10 sec
// wait 2 sec before falling



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public Rigidbody rb;

    Vector3 startPos;

    Quaternion startRot;

    public bool platformIsActive = false;

    public AnimationCurve curve;

    public float resetInterval = 3, hangTime = 0.3f, resetTimer = 3;

    public bool randomize = true;

    // Start is called before the first frame update
    void Start()
    {
        Randomize();

        rb = this.GetComponent<Rigidbody>();
        startRot = this.transform.rotation;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(!platformIsActive)
            {
                platformIsActive = true;
                Debug.Log(other.name + " has run into us");
                StartCoroutine(WaitToFall()); 
            }
            
        }
        
    }

    void Randomize()
    {
        if(randomize)
        {
            this.transform.Translate(Random.value - 0.5f, Random.value - 0.5f, Random.value - 0.5f);
            startPos = this.transform.position;
            resetInterval += Random.Range(-resetInterval/3, resetInterval/3);
            hangTime += Random.Range(-hangTime/3, hangTime/3);
            resetTimer += Random.Range(-resetTimer/3, resetTimer/3);
        }
    }

    IEnumerator WaitToFall()
    {
        yield return new WaitForSeconds (hangTime);
        rb.isKinematic = false;
        StartCoroutine(Reset());
        
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds (resetTimer);
        rb.isKinematic = true;
        
        Vector3 pointA = this.transform.position;
        Vector3 pointB = startPos;

        Quaternion rotA = this.transform.rotation;
        Quaternion rotB = startRot;

        float timer = 0;

        while(timer < 1)
        {
            this.transform.rotation = Quaternion.Lerp(rotA, rotB, curve.Evaluate(timer));
            this.transform.position = Vector3.Lerp(pointA, pointB, curve.Evaluate(timer));
            timer += Time.deltaTime / resetInterval;
            yield return null;
        }
        this.transform.position = startPos;
        this.transform.rotation = startRot;

        Randomize();

        platformIsActive = false;
    }
}
