using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class enemyattack : MonoBehaviour
{
    
    public Transform attackPos;
    public LayerMask playerLayer;
    public float attackRange;
    public int Damage;
    private GameObject player;
    private float timer;
    public float startdist = 4;
    public float timerstart;

    

    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    
    // Update is called once per frame
    
    void Update()
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(new Vector3(attackPos.position.x, attackPos.position.y + 0.3f, attackPos.position.z), attackRange, playerLayer);

        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < startdist)
        {
            timer += Time.deltaTime;
            if (timer > timerstart)
            {
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<playerattack>().TakeDamage(Damage);
                    
                }
                //timeBtwAttack = timebtwattackstart;
                timer = 0;
                
            }
        }
        





    }
    
    
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(new Vector3(attackPos.position.x, attackPos.position.y + 0.3f, attackPos.position.z), attackRange);
    }

}
