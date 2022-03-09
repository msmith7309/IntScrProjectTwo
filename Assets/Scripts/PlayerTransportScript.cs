using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransportScript : MonoBehaviour
{
    public Vector3 playerPos;

    public GameObject enemy;

    public bool enemyIsSeen = true;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.Find("Enemy");
    }

    // Update is called once per frame
    void Update()
    {

        //if(enemyIsSeen)
        //{
        //    enemy.SetActive(true);
        //}
        //else if(!enemyIsSeen)
        //{
        //    enemy.SetActive(false);
        //}
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("CheckPoint"))
        {
            playerPos = this.transform.position;
            Debug.Log("Should be disappeared");
            //if(enemyIsSeen)
            //{
            //    enemyIsSeen = false;
            //}
        }

        if(other.gameObject.CompareTag("Kills you"))
        {
            Application.LoadLevel(0);
            Debug.Log("Should be dead");
        }
        if(other.gameObject.CompareTag("Falling Platform"))
        {
            Debug.Log("Should be seen");
            //enemyIsSeen = true;
            
        }
    }
}
