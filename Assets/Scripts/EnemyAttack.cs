using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform player;

    public HealthScript playerHealth;

    public float attackInterval = 2;
    public int attackDamage = 5;

    public bool canAttack = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(this.transform.position, player.position) < 3)
        {
            if(canAttack)
            {
                playerHealth.health -= attackDamage;
                Debug.Log("Attack!");
                StartCoroutine(ResetAttack());
            }
        }
    }

    IEnumerator ResetAttack()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackInterval);
        canAttack = true;

    }
}
