using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int damage = 2;

    public int doesDouble = 0;

    Renderer rend;

    //option to randomize bullet damage?
    //option to make "critical hit" bullet damage?

    void Start()
    {
        rend = this.GetComponent<Renderer>();
        doesDouble = Random.Range(1, 6);
        if(doesDouble == 4)
        {
            Debug.Log("The Special Bullet has been shot");
            rend.material.color = Color.red;
            damage = damage * 2;
        }
    }
}
