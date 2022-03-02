using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int health = 100;
    ParticleSystem[] fires;

    public Animator uiAnim;

    // Start is called before the first frame update
    void Start()
    {
        fires = GetComponentsInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            health -= 5;
            if(health <= 0)
            {
                uiAnim.SetBool("EnemyIsDead", true);
                foreach(ParticleSystem fire in fires)
                {
                    fire.Stop();
                    Destroy(this.gameObject, 2);
                }
            }
        }
    }

}
