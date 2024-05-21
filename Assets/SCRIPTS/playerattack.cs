using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class playerattack : MonoBehaviour
{
    public int playerhealth = 3;
    public AudioSource AudioSource;
    public AudioClip attackSound;
    public float timeBtwAttack = 0f;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public Transform playerdestroy;
    public LayerMask enemyLayer;
    public float attackRange;
    public int Damage;
    public Animator animator;
    public GameObject heart;
    public GameObject heart1;
    public GameObject heart2;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void TakeDamage(int Damage)
    {

        playerhealth -= Damage;




    }

    // Update is called once per frame
    void Update()
    {
        if (playerhealth == 4)
        {
            heart.SetActive(false);
        }
        if (playerhealth == 2)
        {
            heart1.SetActive(false);
        }
        if (playerhealth == 0)
        {
            heart2.SetActive(false);
        }
        if (playerhealth <= 0)
        {
            gameObject.SetActive(false);
        }
        
        
        if(timeBtwAttack <= 0) 
        {
            //if the user left clicks set the animator to "attack" phase
            if(Input.GetKeyDown(KeyCode.Mouse0)){
                animator.SetTrigger("attack");
                
                
                //if the sword overlaps with the enemy then deal x amount of damage with (Damage variable used in enemyhealth.cs)
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(new Vector3 (attackPos.position.x, attackPos.position.y + 0.3f, attackPos.position.z), attackRange, enemyLayer);
                
                
                for(int i = 0; i < enemiesToDamage.Length; i++) 
                {
                    enemiesToDamage[i].GetComponent<ENEMYAI>().TakeDamage(Damage);
                    
                    
                }
                //time between attack (resets the timer here)
                timeBtwAttack = 0.65f;
            }
            

        }
        else 
        {
            //if the time between attacks greater than 0 then - it until it is 0 then goes back up to
            //(if(timeBtwAttack <= 0) and allows user to re-attack
            if(timeBtwAttack > 0)
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
