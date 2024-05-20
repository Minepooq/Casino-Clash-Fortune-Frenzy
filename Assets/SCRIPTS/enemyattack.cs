using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class enemyattack : MonoBehaviour
{
    public int playerhealth = 4;

    public float timeBtwAttack = 2f;
    public Transform attackPos;
    public LayerMask playerLayer;
    public float attackRange;
    public int Damage;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (timeBtwAttack <= 0)
        {
           
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(new Vector3(attackPos.position.x, attackPos.position.y + 0.3f, attackPos.position.z), attackRange, playerLayer);

            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<playerattack>().TakeDamage(Damage);

            }
            timeBtwAttack = 2f;



        }
        else
        {
            if (timeBtwAttack > 0)
            {
                timeBtwAttack -= Time.deltaTime;
            }


        }





    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(new Vector3(attackPos.position.x, attackPos.position.y + 0.3f, attackPos.position.z), attackRange);
    }

}
