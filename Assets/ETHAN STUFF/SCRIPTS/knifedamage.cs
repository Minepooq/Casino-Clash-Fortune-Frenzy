using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
public class knifedamage : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeBtwAttack = 0f;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public LayerMask enemyLayer;
    public float attackRange;
    public int Damage;
    public Animator animator;
    public static GameObject knife;
    public Sprite startknife;
    public GameObject swordselectionscreen;
    public GameObject player;
    public Animator enemyanimation;
    // Start is called before the first frame update

    private void Start()
    {
        knife = gameObject;
        knife.gameObject.GetComponent<SpriteRenderer>().sprite = startknife;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!swordselectionscreen.activeInHierarchy && mainmenu.istrue == false)
        {
            if (timeBtwAttack <= 0)
            {
                //if the user left clicks set the animator to "attack" phase
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    animator.SetTrigger("attack");


                    //if the sword overlaps with the enemy then deal x amount of damage with (Damage variable used in enemyhealth.cs)
                    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(new Vector3(attackPos.position.x, attackPos.position.y + 0.3f, attackPos.position.z), attackRange, enemyLayer);


                    for (int i = 0; i < enemiesToDamage.Length; i++)
                    {
                        enemiesToDamage[i].GetComponent<ENEMYAI>().TakeDamage(Damage);
                        

                    }
                    //time between attack (resets the timer here)
                    timeBtwAttack = startTimeBtwAttack;
                }


            }
            else
            {
                //if the time between attacks greater than 0 then - it until it is 0 then goes back up to
                //(if(timeBtwAttack <= 0) and allows user to re-attack
                if (timeBtwAttack > 0)
                {
                    timeBtwAttack -= Time.deltaTime;
                }


            }
        }
        

        
        




    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(new Vector3(attackPos.position.x, attackPos.position.y + 0.3f, attackPos.position.z), attackRange);
    }
}
